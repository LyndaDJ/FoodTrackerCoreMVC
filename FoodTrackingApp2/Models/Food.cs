using System.ComponentModel.DataAnnotations;

namespace FoodTrackingApp2.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        public MealType Meal { get; set; }
        public string Carbohydrate { get; set; }
        public string Protein { get; set; }
        public string Fat { get; set; }
        public string Snacks { get; set; }
    }
}
