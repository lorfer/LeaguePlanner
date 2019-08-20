using Prism.Services;
using LeaguePlanner.Models;
using Realms;
using System.Collections.Generic;
using System.Linq;
using Realms.Exceptions;
using System.Collections.ObjectModel;

namespace LeaguePlanner.Service
{
    class Repository
    {
        Realm instance = Realm.GetInstance();


        public int AutoIncrement()
        {
            int count = (int)instance.All<User>().ToList().Count;
            return count += 1;
        }


        public List<User> GetUsers()
        {
            var users = instance.All<User>().ToList();
            return users;
        }

        public bool UserExist(User user, string type)
        {
            switch (type)
            {
                case "exist":
                    foreach (var item in GetUsers())
                    {
                        if (item.UserName == user.UserName)
                        {
                            return true;
                        }
                    }
                    return false;

                case "valid":
                    foreach (var item in GetUsers())
                    {
                        if (item.UserName == user.UserName && item.PassWorld == user.PassWorld)
                        {
                            return true;
                        }
                    }
                    return false;


                default:
                    return false;
            }


        }


        public void InsertUser(User user)
        {
            try
            {
                instance.Write(() =>
                {

                    instance.Add(user);


                });
            }
            catch (RealmException e)
            {

            }

        }


        public ObservableCollection<Player> GetPlayers()
        {
            try
            {
                var players = (ObservableCollection<Player>)instance.All<Player>();
                return players;

            }
            catch (RealmException)
            {

                throw;
            }



        }
        public void InsertPlayer(Player player)
        {
            try
            {
                instance.Write(() =>
                {

                    instance.Add(player);


                });
            }
            catch (RealmException e)
            {

            }

        }



    }
}
