using DogWaterBowlWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Tls;

namespace DogWaterBowlWebApp.Controllers
{
    public class DogController : Controller
    {
        private readonly IDogRepo repo;

        public DogController(IDogRepo repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var dogs = repo.GetAllDogs();
            return View(dogs);
        }
        public IActionResult ViewDog(int id)
        {
            var dog = repo.GetDog(id);
            return View(dog);
        }
        public IActionResult EditDog(int id)
        {
            Dog dog = repo.GetDog(id);
            if (dog == null)
            {
                return View("Dog Not Found");
            }
            return View(dog);
        }
        [HttpPost]
        public IActionResult UpdateDogToDatabase(Dog dogToUpdate, IFormFile picture)
        {
            if (picture != null && picture.Length > 0)
            {
                dogToUpdate.Picture = new byte[picture.Length];
                picture.OpenReadStream().Read(dogToUpdate.Picture, 0, (int)picture.Length);
                //--OR--
                //using (var memoryStream = new MemoryStream())
                //{
                //    picture.CopyTo(memoryStream);
                //    dogToUpdate.Picture = memoryStream.ToArray();
                //}
            }
            else
            {
                var currentDog = repo.GetDog(dogToUpdate.DogID);
                dogToUpdate.Picture = currentDog.Picture;
            }
            repo.EditDog(dogToUpdate);
            return RedirectToAction("Index", new { id = dogToUpdate.DogID });
        }
        public IActionResult AddDog(int id)
        {
            Dog dog = repo.GetDog(id);
            return View(dog);
        }
        [HttpPost]
        public IActionResult AddDogToDatabase(Dog dogToAdd, IFormFile picture)
        {
            if (picture != null && picture.Length > 0)
            {
                dogToAdd.Picture = new byte[picture.Length];
                picture.OpenReadStream().Read(dogToAdd.Picture, 0, (int)picture.Length);
            }
            repo.AddDog(dogToAdd);
            return RedirectToAction("Index", new { id = dogToAdd.DogID });
        }
        public IActionResult DeleteDog(Dog dogToDelete)
        {
            repo.DeleteDog(dogToDelete);
            return RedirectToAction("Index");
        }


    }
}

