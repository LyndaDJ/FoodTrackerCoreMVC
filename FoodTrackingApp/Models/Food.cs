using System.ComponentModel.DataAnnotations;

namespace FoodTrackingApp.Models
{
    public class Food
    {
        public int Id { get; set; }

        [Display(Name ="Created Date")]
        public DateTime CreatedDate { get; set; }
        public MealType Meal { get; set; }
        public string Carbohydrate { get; set; }
        public string Protein { get; set; }
        public string Fat { get; set; }
        public string Snacks { get; set; }
        

        public Food()
        {

        }
    }

}
