using HepsiBuradaRover.Common.Enumaration;
using HepsiBuradaRover.Common.Extensions;
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
        public List<MoveIInputType> MoveCommands { get; set; }
        public int Order { get; set; }
        public bool OutOfBoundary { get; set; }
        public string ErrorMessage { get; set; }

        public Plateau Plateau { get; set; }

        public override string ToString()
        {
            if (OutOfBoundary)
                return ErrorMessage;

            string newPosition = $"{XCoordinate} {YCoordinate} {Direction.GetEnumDescriptionValue()}";

            return newPosition;
        }
    }
}
