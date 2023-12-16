﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pmesp.Application.DTOs;

public class BanditDTO
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [StringLength(30, ErrorMessage = "O nome não pode ultrapassar os 30 caracteres")]
    public string Name { get; set; }
    [StringLength(255, ErrorMessage = "A descrição não pode ultrapassar os 255 caracteres")]
    public string Description { get; set; }
    [StringLength (14, ErrorMessage = "O CPF não pode ultrapssar caracteres")]
    public string CPF { get; set; }
    public DateTime Birthday { get; set; }
    [StringLength(12, ErrorMessage = "O telefone não pode ultrapassar os 12 caracteres")]
    public string Phone { get; set; }
    [EmailAddress(ErrorMessage = "O email não tem o formato correto")]
    public string Email { get; set; }
    public string Surname { get; set; }
    public float Weight { get; set; }
    public float Height { get; set; }
    public ICollection<RGsDTO>? RGs { get; set; }
}