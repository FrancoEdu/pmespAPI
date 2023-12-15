using pmesp.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace pmesp.Domain.Entities;

public class RG : BaseEntity
{
    [StringLength(20)]
    public string Number { get; set; }
    [StringLength(50)]
    public string? Sender {  get; set; }
    [StringLength(2)]
    public string? Uf {  get; set; }
    public DateTime? SenderDate { get; set; }
    public Guid BanditId { get; set; }
    public Bandit bandit { get; set; }
}
