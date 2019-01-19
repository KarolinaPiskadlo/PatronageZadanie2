using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatronageZadanie2.Models
{
    public class ConferenceRoomDTO
    {
        public string Name { get; set; }
        public int Area { get; set; }
        public int Capacity { get; set; }
        public bool WifiAcces { get; set; }
    }
}
