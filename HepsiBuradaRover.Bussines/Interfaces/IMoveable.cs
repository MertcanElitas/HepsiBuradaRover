using HepsiBuradaRover.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaRover.Bussines.Interfaces
{
    public interface IMoveable
    {
        void Execute(Rover rover);
    }
}
