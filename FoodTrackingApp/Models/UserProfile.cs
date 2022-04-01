using System.ComponentModel.DataAnnotations;

namespace FoodTrackingApp.Models
{
    public class UserProfile
    {
        public int UserprofileId { get; set; }

        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        public string Lastname { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        [Display(Name = "Goal Weight")]
        public double Goalweight { get; set; }

        public UserProfile()
        {

        }
    }

}
