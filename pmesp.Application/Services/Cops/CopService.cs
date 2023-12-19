using AutoMapper;
using pmesp.Application.DTOs.Cops;
using pmesp.Application.Interfaces.Cop;
using pmesp.Domain.Interfaces.ICop;
using System.Collections.Generic;
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

    public Task<ResultService<CopDTO>> PostAsync(CopDTO entity)
    {
        throw new System.NotImplementedException();
    }


    /*
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

    public async Task Update(CopDTO entity)
    {
        var cop = _mapper.Map<Cop>(entity);
        await _repository.UpdateAsync(cop);
    }
    */
}
