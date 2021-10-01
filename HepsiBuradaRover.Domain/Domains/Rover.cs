using HepsiBuradaRover.Common.Enumaration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaRover.Domain.Domains
{
    public class Rover
    {

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public RoverDirectionType Direction { get; set; }
        public string MoveInput { get; set; }

        public Plateau Plateau { get; set; }
    }
}
