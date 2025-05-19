using System.ComponentModel.DataAnnotations;

namespace Simulation2_7_25.DAL.Models;
public class Profession : BaseEntity
{
    [Required, MinLength(2), MaxLength(30)]
    public string Title { get; set; }

    public ICollection<Doctor>? Doctors { get; set; }
}
