using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using pmesp.Application.DTOs.Addresses;
using pmesp.Application.DTOs.RGs;
using pmesp.Application.DTOs.Tattoos;

namespace pmesp.Application.DTOs.Bandits;

public class BanditDTO
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string? Description { get; set; }
    public string CPF { get; set; }
    public DateTime? Birthday { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Surname { get; set; }
    public float? Weight { get; set; }
    public float? Height { get; set; }
    public string? PrincipalPhoto { get; set; }
    public string? ExtensionPhoto { get; set; }
    public string? Nationality { get; set; }
    public string? Naturalness { get; set; }
    public string? MaritalStatus { get; set; }
    public string? CriminalSituation { get; set; }
    public string? ORCRIM { get; set; }
    public string? CrimeFunction { get; set; }
    public string? Profession { get; set; }
    public string? CriminalRG { get; set; }
    public string? ChainRegistration { get; set; }
    public string? OperationPhone { get; set; }
    public string? WhatsApp { get; set; }
    public string? PixEmail { get; set; }
    public string? PixPhone { get; set; }
    public string? PixCPF { get; set; }
    public ICollection<RGsDTO> RGs { get; set; }
    public ICollection<TattooDTO> Tattoos { get; set; }
    public ICollection<AddressDTO> Addresses { get; set; }
}
