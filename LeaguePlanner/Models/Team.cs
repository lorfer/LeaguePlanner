using Realms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LeaguePlanner.Models
{
    class Team:RealmObject
    {

        public string TeamId { get; set; } = Guid.NewGuid().ToString();
        public string TeamName { get; set; }
        public int MinPlayer { get; set; }
        public IList<Player>Players { get; set; }

    }
}
