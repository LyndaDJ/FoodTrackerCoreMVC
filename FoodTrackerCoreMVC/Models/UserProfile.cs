namespace FoodTrackerCoreMVC.Models
{
    public class UserProfile
    {
        public int UserprofileId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Dateofbirth { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double Goalweight { get; set; }
        public virtual User User { get; set; }
        public int UserId { get; set; }
    }
}
