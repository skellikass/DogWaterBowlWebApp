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
        public IActionResult UpdateDogToDatabase(Dog dogToUpdate, IFormFile picture)
        {
            //if (picture.ContentType != "image/jpeg" && picture.ContentType != "image/png")
            //{
            //    ViewData["error"] = "Invalid file type. Please upload a jpeg or png image.";
            //    return View();
            //}
            try
            {
                if (picture != null && picture.Length > 0)
                {
                    dogToUpdate.Picture = new byte[picture.Length];
                    picture.OpenReadStream().Read(dogToUpdate.Picture, 0, (int)picture.Length);
                    Console.WriteLine(picture);
                    Console.WriteLine(dogToUpdate);
                    //--OR--
                    //using (var memoryStream = new MemoryStream())
                    //{
                    //    picture.CopyTo(memoryStream);
                    //    dogToUpdate.Picture = memoryStream.ToArray();
                    //}
                }
                repo.EditDog(dogToUpdate);
                ViewData["success"] = "Changes saved successfully!";
                Console.WriteLine("success");
            }
            catch (Exception ex)
            {
                ViewData["error"] = "Oh no! Something went wrong. Please try again or contact web support." + ex.Message;
                Console.WriteLine("error");
            }
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

    //[HttpPost]
    //public async Task<IActionResult> UploadPicture(Dog dog, IFormFile picture)
    //{
    //    if (picture != null && picture.Length > 0)
    //    {
    //        dog.Picture = new byte[picture.Length];
    //        picture.OpenReadStream().Read(dog.Picture, 0, (int)picture.Length);
    //    }
    //    using (var connection = new MySqlConnection("dogwaterbowl"))
    //    {
    //        connection.Open();
    //        using (var command = new MySqlCommand("UPDATE dogs SET Picture = @picture", connection))
    //        {
    //            command.Parameters.AddWithValue("@picture", dog.Picture);
    //            command.ExecuteNonQuery();
    //            return RedirectToAction("Index");
    //        }
    //    }
    //}
}

