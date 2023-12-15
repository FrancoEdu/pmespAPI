using pmesp.Domain.Entities.Common;
using pmesp.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace pmesp.Domain.Entities;

public class RG : BaseEntity
{
    public string Number { get; private set; }
    public string? Sender {  get; private set; }
    public string? Uf {  get; private set; }
    public DateTime? SenderDate { get; private set; }
    public Guid PersonId { get; set; }
    public Bandit Person { get; set; }

    public RG(Guid id, string number, string? sender, string? Uf, DateTime? senderDate, Guid banditId) : base(id)
    {
        ValidateDomain(number, sender, Uf, senderDate, banditId);
    }

    
    public void ValidateDomain(string number, string? sender, string? uf, DateTime? senderDate, Guid banditId)
    {
        DomainExceptionValidation.When(banditId == Guid.Empty, "É necessário passar o Id do portador desse RG");
        DomainExceptionValidation.When(number.Length > 15, "O rg precisa ter no máximo 15 caracteres");
        PersonId = banditId;
        Number = number;
        Sender = sender;
        Uf = uf; 
        SenderDate = senderDate;
    }
}
