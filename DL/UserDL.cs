using Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class UserDL : IUserDL
    {
        CoffeeShopContext _CoffeeShopContext;

        public UserDL(CoffeeShopContext CoffeeShopContext)
        {
            _CoffeeShopContext = CoffeeShopContext;

        }
        //string path = "C:\\Users\\This_user\\Documents\\לימודים\\Web Api\\Project1\\UsersFile.txt";
        public async Task<Users> getUser(string login, string password)
        {
            //using (StreamReader reader = System.IO.File.OpenText(path))
            //{
            //    string currentUser;
            //    while ((currentUser = reader.ReadLine()) != null)
            //    {
            //        User user = JsonConvert.DeserializeObject<User>(currentUser);
            //        if (user.Email == login && user.Password == password)
            //            return user;
            //    }
            //}
            //return null;
            Users user = await _CoffeeShopContext.Users.Where(data => data.Email.Equals(login) && data.Password.Equals(password)).FirstOrDefaultAsync();
            return user;
        }



        public async Task createUser(Users user)
        {
            //string userJson = JsonConvert.SerializeObject(user);
            //System.IO.File.AppendAllText(path, userJson + Environment.NewLine);
            await _CoffeeShopContext.Users.AddAsync(user);
            await _CoffeeShopContext.SaveChangesAsync();
        }

        public async Task updateDetails(int id, Users userToUpdate)
        {

            //    string textToReplace = "";
            //    using (StreamReader reader = System.IO.File.OpenText(path))
            //    {
            //        string currentUser;
            //        while ((currentUser = reader.ReadLine()) != null)
            //        {

            //            User user = JsonConvert.DeserializeObject<User>(currentUser);
            //            if (user.Email == email && user.Password == password)
            //                textToReplace = currentUser;
            //        }
            //    }

            //    if (textToReplace != string.Empty)
            //    {
            //        string text = System.IO.File.ReadAllText(path);
            //        text = text.Replace(textToReplace, JsonConvert.SerializeObject(userToUpdate));
            //        System.IO.File.WriteAllText(path, text);
            //    }

            Users user = await _CoffeeShopContext.Users.FindAsync(id);
            if(user==null)
            {
                return;
            }
            userToUpdate.UserId = id;
            _CoffeeShopContext.Entry(user).CurrentValues.SetValues(userToUpdate);
            await _CoffeeShopContext.SaveChangesAsync();
        }
    }
}
