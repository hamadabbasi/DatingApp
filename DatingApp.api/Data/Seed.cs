using System.Collections.Generic;
using System.Linq;
using DatingApp.api.Models;
using Newtonsoft.Json;

namespace DatingApp.api.Data
{
    public class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if(!context.Users.Any())
            {
            var SeedUsers = System.IO.File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(SeedUsers);
            foreach(var user in users)
            {
                byte[] passwordHash,passwordSalt;
                CreatePassword("Password", out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();
                context.Users.Add(user);
            }
            context.SaveChanges();
            }
        }

        private static void CreatePassword(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
          using(var hmac = new System.Security.Cryptography.HMACSHA512())
          {
              passwordSalt = hmac.Key;
              passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
          }
        }
    }
}