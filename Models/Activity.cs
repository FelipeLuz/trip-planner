using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trip_planner.Models;

[Table("Activity")]
public class Activity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ActivityID { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Type { get; set; }

    [Required]
    public string Location { get; set; }
	
	[Required]
    public double Price { get; set; }

    public string Description { get; set; }
}