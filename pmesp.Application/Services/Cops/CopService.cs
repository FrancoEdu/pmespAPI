﻿using AutoMapper;
using pmesp.API.Models.Logins;
using pmesp.API.Models.Tokens;
using pmesp.Application.DTOs.Bandits;
using pmesp.Application.DTOs.Cops;
using pmesp.Application.DTOs.Logins;
using pmesp.Application.Interfaces.Cop;
using pmesp.Domain.Entities.Cops;
using pmesp.Domain.Entities.Cops.Account;
using pmesp.Domain.Interfaces.ICop;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace pmesp.Application.Services.Cops;

public class CopService : ICopService
{
    private readonly ICopRepository _repository;
    private readonly IAuthenticate _authenticateService;
    private IMapper _mapper;

    public CopService(IAuthenticate authenticateService,ICopRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
        _authenticateService = authenticateService;
    }


    public async Task<ResultService<ICollection<CopDTO>>> GetAllAsync()
    {
        var cops = await _repository.GetAllAsync();
        var copsDTO = _mapper.Map<ICollection<CopDTO>>(cops);
        return ResultService.Ok<ICollection<CopDTO>>(copsDTO, "Lista de policiais");
    }

    
    public async Task<ResultService<CopDTO>> GetByIdAsync(string id)
    {
        var cop = await _repository.GetByIdAsync(id);
        return cop == null ?
            ResultService.Fail<CopDTO>("Não encontramos um policial com esse Id") :
            ResultService.Ok<CopDTO>(_mapper.Map<CopDTO>(cop), "Policial encontrado");
    }
    public async Task<ResultService<CopDTO>> DeleteByIdAsync(string id)
    {
        var cop = await _repository.GetByIdAsync(id);

        if(cop == null)
        {
            return ResultService.Fail<CopDTO>("Não encontramos um policial com esse Id");
        }

        await _repository.DeleteAsync(cop);
        return ResultService.Ok<CopDTO>(_mapper.Map<CopDTO>(cop), "Policial excluído");
    }

    public async Task<ResultService<CopDTO>> PostAsync(CopDTO entity)
    {
        if(entity == null)
        {
            return ResultService.Fail<CopDTO>("O objeto deve ser enviado...");
        }

        var result = new CopDTOValidator().Validate(entity);

        if (!result.IsValid)
        {
            return ResultService.RequestError<CopDTO>("Problema de validade de atributos", result);
        }
        
        var emailAlreadyExists = await _authenticateService.UserExists(entity.Email);

        if (emailAlreadyExists)
        {
            return ResultService.Fail<CopDTO>("Já existe um policial atribuido ao email passado...");
        }

        var cop = _mapper.Map<Cop>(entity);

        // Mapenando a pwd para pwdHash e Salt
        if (cop != null)
        {
            using var hmac = new HMACSHA512();
            byte[] pwdHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(entity.Password));
            byte[] pwdSalt = hmac.Key;

            cop.AlterarSenha(pwdHash, pwdSalt);
        }

        var copObject = await _repository.CreateAsync(cop);
        return ResultService.Ok<CopDTO>(_mapper.Map<CopDTO>(copObject), "Policial cadastrado com sucesso");
    }

    public async Task<ResultService<TokenDTO>> LoginAsync(LoginDTO credentials)
    {
        var result = await ValidateCopLogin(credentials);
        if (result.Success)
        {
            var cop = await _authenticateService.GetCopByEmail(credentials.Email);
            var token = _authenticateService.GenerateToken(cop.Id, cop.Email);
            var tokenDTO = new TokenDTO
            {
                TokenJWT = token,
            };
            return ResultService.Ok<TokenDTO>(tokenDTO, "Credenciais válidas");
        }
        return ResultService.Fail<TokenDTO>($"{result.Message}");
    }

    public async Task<ResultService<LoginDTO>> ValidateCopLogin(LoginDTO credentials)
    {
        if (credentials == null)
        {
            return ResultService.Fail<LoginDTO>("Objeto enviado nulo");
        }

        var result = new LoginValidator().Validate(credentials);
        if (!result.IsValid)
        {
            return ResultService.RequestError<LoginDTO>("", result);
        }

        var exists = await _authenticateService.UserExists(credentials.Email);
        if (!exists)
        {
            return ResultService.Fail<LoginDTO>("O email informado não existe em nenhum cadastro...");
        }

        var auth = await _authenticateService.AuthenticateAsync(credentials.Email, credentials.Password);
        if (!auth)
        {
            return ResultService.Fail<LoginDTO>("Credenciais inválidas...");
        }

        return ResultService.Ok<LoginDTO>(credentials, "Cresenciais válidas");
    }
}
