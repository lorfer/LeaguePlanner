
using Realms;
using System;

namespace LeaguePlanner.Models
{
    public class Player:RealmObject
    {
        [PrimaryKey]
        public string PlayerId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Position { get; set; }
        public float? Heith { get; set; }
        public float? Weith { get; set; }

    }
    
}
