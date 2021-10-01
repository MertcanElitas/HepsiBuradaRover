using HepsiBuradaRover.Common.Enumaration;
using HepsiBuradaRover.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaRover.Bussines.Helper
{
    public static class RoverMoveHelper
    {
        public static void Move(Rover rover)
        {
            switch (rover.Direction)
            {
                case RoverDirectionType.North:
                    rover.YCoordinate = rover.YCoordinate + 1;
                    break;
                case RoverDirectionType.South:
                    rover.YCoordinate = rover.YCoordinate + 1;
                    break;
                case RoverDirectionType.West:
                    rover.XCoordinate = rover.XCoordinate - 1;
                    break;
                case RoverDirectionType.East:
                    rover.XCoordinate = rover.XCoordinate + 1;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        public static void TurnRight(Rover rover)
        {
            switch (rover.Direction)
            {
                case RoverDirectionType.North:
                    rover.Direction = RoverDirectionType.East;
                    break;
                case RoverDirectionType.South:
                    rover.Direction = RoverDirectionType.West;
                    break;
                case RoverDirectionType.West:
                    rover.Direction = RoverDirectionType.North;
                    break;
                case RoverDirectionType.East:
                    rover.Direction = RoverDirectionType.South;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        public static void TurnLeft(Rover rover)
        {
            switch (rover.Direction)
            {
                case RoverDirectionType.North:
                    rover.Direction = RoverDirectionType.West;
                    break;
                case RoverDirectionType.South:
                    rover.Direction = RoverDirectionType.East;
                    break;
                case RoverDirectionType.West:
                    rover.Direction = RoverDirectionType.South;
                    break;
                case RoverDirectionType.East:
                    rover.Direction = RoverDirectionType.North;
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
