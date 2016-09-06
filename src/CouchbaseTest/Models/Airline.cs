using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CouchbaseTest.Models
{
    public class Airline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Callsign { get; set; }
        public string Icao { get; set; }
    }
}
