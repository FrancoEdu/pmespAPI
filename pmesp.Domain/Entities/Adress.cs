using pmesp.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace pmesp.Domain.Entities;

public class Adress : BaseEntity
{
    [StringLength(100)]
    public string? AdressOne { get; set; }
    [StringLength(100)]
    public string? Neighborhood { get; set; }
    [StringLength(100)]
    public string? ZipCode { get; set; }
    [StringLength(100)]
    public string? City { get; set; }
    [StringLength(100)]
    public string? Country { get; set; }
    [StringLength(100)]
    public string? State { get; set; }
    [StringLength(100)]
    public int? Number { get; set; }
}
