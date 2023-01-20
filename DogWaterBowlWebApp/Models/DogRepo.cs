using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;
using System.Text;
using System.Text.Unicode;

namespace DogWaterBowlWebApp.Models
{
    public class DogRepo : IDogRepo
    {
        private readonly IDbConnection _connection;

        public DogRepo(IDbConnection connection)
        {
            _connection = connection;
        }

        public void AddDog(Dog dogToAdd)
        {
            _connection.Execute("UPDATE dogs SET Name = @name, Amount = @amount, TimeInterval = @timeInterval, Picture = (SELECT @picture) WHERE DogID = @id",
                new { name = dogToAdd.Name, amount = dogToAdd.Amount, timeInterval = dogToAdd.TimeInterval, picture = dogToAdd.Picture, id = dogToAdd.DogID });
        }

        public void DeleteDog(Dog dogToDelete)
        {
            _connection.Execute("UPDATE dogs SET Name = null, Amount = null, TimeInterval = null, Picture = null WHERE DogID = @id;",
                new { id = dogToDelete.DogID });
        }

        public void EditDog(Dog dogToEdit)
        {
            _connection.Execute("UPDATE dogs SET Name = @name, Amount = @amount, TimeInterval = @timeInterval, Picture = (SELECT @picture) WHERE Name = @name",
                new { name = dogToEdit.Name, amount = dogToEdit.Amount, timeInterval = dogToEdit.TimeInterval, picture = dogToEdit.Picture });
        }

        public IEnumerable<Dog> GetAllDogs()
        {
            return _connection.Query<Dog>("SELECT * FROM dogs;");
        }

        public Dog GetDog(int id)
        {
            return _connection.QuerySingle<Dog>("SELECT * FROM dogs WHERE DogID = @id", new { id = id });
        }
        


    }
}
