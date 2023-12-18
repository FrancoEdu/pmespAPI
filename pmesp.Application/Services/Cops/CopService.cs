using AutoMapper;
using pmesp.Application.DTOs.Cops;
using pmesp.Application.Interfaces.Cop;
using pmesp.Domain.Entities.Cops;
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
    private IMapper _mapper;

    public CopService(ICopRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task Add(CopDTO entity)
    {
        var cop = _mapper.Map<Cop>(entity);

        // Mapenando a pwd para pwdHash e Salt
        if(cop != null )
        {
            using var hmac = new HMACSHA512();
            byte[] pwdHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(entity.Password));
            byte[] pwdSalt = hmac.Key;

            cop.AlterarSenha(pwdHash, pwdSalt);
        }

        await _repository.CreateAsync(cop);
    }

    public async Task Delete(string id)
    {
        var cop = _repository.GetByIdAsync(id).Result;
        await _repository.DeleteAsync(cop);
    }

    public async Task<IEnumerable<CopDTO>> GetAll()
    {
        var cops = await _repository.GetAllAsync();
        var copsDTO = _mapper.Map<IEnumerable<CopDTO>>(cops);
        return copsDTO;
    }

    public async Task<CopDTO> GetById(string id)
    {
        var cop = await _repository.GetByIdAsync(id);
        var copDTO = _mapper.Map<CopDTO>(cop);
        return copDTO;
    }

    public async Task Update(CopDTO entity)
    {
        var cop = _mapper.Map<Cop>(entity);
        await _repository.UpdateAsync(cop);
    }
}
