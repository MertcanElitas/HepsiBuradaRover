using HepsiBuradaRover.Bussines.Helper;
using HepsiBuradaRover.Bussines.Interfaces;
using HepsiBuradaRover.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaRover.Bussines.Concretes
{
    public class ForwardMovement : IMoveable, IDisposable
    {

        public void Execute(Rover rover)
        {
            RoverMoveHelper.Move(rover);
            CheckRoverOutOfBound(rover);
        }

        public void CheckRoverOutOfBound(Rover rover)
        {
            var roverXCoordinate = rover.XCoordinate;
            var roverYCoordinate = rover.YCoordinate;

            var plateauWidth = rover.Plateau.Width;
            var plateauHeight = rover.Plateau.Height;


            if ((roverXCoordinate > plateauWidth || roverXCoordinate < 0) ||
                (roverYCoordinate > plateauHeight || roverYCoordinate < 0))
            {
                rover.OutOfBoundary = true;
                rover.ErrorMessage = "I am sorry out of the plateau";
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
