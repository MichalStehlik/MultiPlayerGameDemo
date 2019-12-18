using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiPlayerGameDemo.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Player1Id { get; set; }
        public string Player2Id { get; set; }
        public int Turn { get; set; }
    }
}
