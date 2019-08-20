
using Realms;

namespace LeaguePlanner.Models
{
    public class Player:RealmObject
    {
        [PrimaryKey]
        public int Id{ get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }

        public float? Heith { get; set; }
        public float? Weith { get; set; }

    }
    
}
