using System.ComponentModel.DataAnnotations;

namespace Simulation2_7_25.BL.ViewModels;
public class LoginVM
{
    [Required]
    public string EmailOrUsername { get; set; }

    [Required, DataType(DataType.Password)]
    public string Password { get; set; }

    public bool Remember { get; set; }
}
