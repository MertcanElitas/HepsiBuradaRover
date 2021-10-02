using HepsiBuradaRover.Common.DataTransferObejcts;
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
        List<string> GenerateRover(List<RoverDto> roverList, string plateauInput);

        bool ValidateRoverPositionInput(string positionInput);

        bool ValidateRoverMoveInput(string moveInput);
    }
}
