using pmesp.Domain.Validations;

namespace pmesp.Domain.Entities;

public class RG
{
    public string Id { get; private set; }
    public string Number { get; private set; }
    public string Sender {  get; private set; }
    public string Uf {  get; private set; }
    public DateTime SenderDate { get; private set; }
    public string BanditId { get; set; }
    public Bandit Bandit { get; set; }

    public RG(string number, string sender, string uf, DateTime senderDate)
    {
        ValidateDomain(number, sender, uf, senderDate);
    }

    public void Update(string number, string sender, string uf, DateTime senderDate)
    {
        ValidateDomain(number, sender, uf, senderDate);
    }

    
    public void ValidateDomain(string number, string sender, string uf, DateTime senderDate)
    {
        DomainExceptionValidation.When(number.Length > 15, "O rg precisa ter no máximo 15 caracteres");
        Number = number;
        Sender = sender;
        Uf = uf; 
        SenderDate = senderDate;
    }
}
