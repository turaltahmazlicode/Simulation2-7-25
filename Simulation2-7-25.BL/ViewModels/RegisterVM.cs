﻿using System.ComponentModel.DataAnnotations;

namespace Simulation2_7_25.BL.ViewModels;
public class RegisterVM
{
    [Required, MinLength(2), MaxLength(30)]
    public string Name { get; set; }

    [Required, MinLength(2), MaxLength(40)]
    public string Surname { get; set; }

    [Required]
    public string Username { get; set; }

    [Required, DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required, DataType(DataType.Password)]
    public string Password { get; set; }

    [Required, DataType(DataType.Password), Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
}
