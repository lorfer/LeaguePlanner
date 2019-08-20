using System;
using System.Collections.Generic;
using System.Text;
using Realms;
namespace LeaguePlanner.Models
{
    class User : RealmObject
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset Date { get; set; }

        [PrimaryKey]
        public string UserName { get; set; }
        public string PassWorld { get; set; }

    }
}
