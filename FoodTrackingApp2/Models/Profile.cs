using System.ComponentModel.DataAnnotations;

namespace FoodTrackingApp2.Models
{
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        [Display(Name = "Goal Weight")]
        public double Goalweight { get; set; }
    }
}
