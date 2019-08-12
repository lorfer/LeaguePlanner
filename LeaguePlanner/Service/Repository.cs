using Prism.Services;
using LeaguePlanner.Models;
using Realms;
using System.Collections.Generic;
using System.Linq;

namespace LeaguePlanner.Service
{
    class Repository
    {
        public Repository()
        {
            //var instance = Realm.GetInstance();
            //instance.CreateObject(User,)
        }

        public int AutoIncrement()
        {
            var instance = Realm.GetInstance();
            int count = (int)instance.All<User>().ToList().Count;
            return count += 1;
        }

     
        public List<User> GetUsers()
        {
            var instance = Realm.GetInstance();
            var users = instance.All<User>().ToList();
            return users;
        }

        public bool UserExist(User user)
        {
            foreach (var item in GetUsers())
            {
                if (item.UserName == user.UserName)
                {
                    return true;
                }
            }
            return false;

        }

        public bool UserExist(string userName, string passWorld)
        {
            foreach (var item in GetUsers())
            {
                if (item.UserName == userName && item.PassWorld == passWorld)
                {
                    return true;
                }
            }
            return false;
        }
        public void InsertUser(User user)
        {
            var instance = Realm.GetInstance();

            instance.Write(() =>
            {

                instance.Add(user);


            });
        }



    }
}
