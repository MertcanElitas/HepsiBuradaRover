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
    public class TurnRightMovement : IMoveable,IDisposable
    {
      
        public void Execute(Rover rover)
        {
            RoverMoveHelper.TurnRight(rover);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
