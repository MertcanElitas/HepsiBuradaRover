using HepsiBuradaRover.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaRover.Bussines.Interfaces
{
    public interface IRoverService
    {
        Rover GenerateRover(string positionInput, string moveInput, Plateau plateau);
    }
}
