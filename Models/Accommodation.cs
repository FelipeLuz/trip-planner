using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trip_planner.Models;

[Table("Accommodation")]
public class Accommodation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccommodationID { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Location { get; set; }

    [Required]
    public string Type { get; set; }

    [Required]
    public double PricePerNight { get; set; }

    public string Description { get; set; }
}