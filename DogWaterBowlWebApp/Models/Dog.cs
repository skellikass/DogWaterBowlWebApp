using System.ComponentModel.DataAnnotations;

namespace DogWaterBowlWebApp.Models
{
    public class Dog
    {
        public byte[] Picture { get; set; }
        public int DogID { get; set; }

        [Required]
        public string Name { get; set; }
        public double Amount { get; set; }
        public int TimeInterval { get; set; }
    }
}
