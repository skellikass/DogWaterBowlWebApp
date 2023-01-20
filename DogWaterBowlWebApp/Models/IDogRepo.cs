using System.Data.Common;

namespace DogWaterBowlWebApp.Models
{
    public interface IDogRepo
    {
        public IEnumerable<Dog> GetAllDogs();
        public Dog GetDog(int id);
        public void EditDog(Dog dogToEdit);
        public void AddDog(Dog dogToAdd);
        public void DeleteDog(Dog dogToDelete);
        
    }
}
