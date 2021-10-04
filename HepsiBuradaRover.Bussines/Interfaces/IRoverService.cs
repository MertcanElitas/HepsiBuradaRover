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
        /// <summary>
        /// This method calculates its new location with the commands declared to the rover.
        /// </summary>
        /// <param name="roverList"></param>
        /// <param name="plateauBoundaryInput"></param>
        /// <returns></returns>
        List<string> ExecuteRoverCommands(List<RoverDto> roverList, string plateauBoundaryInput);

        /// <summary>
        /// This method checks the accuracy of the coordinate data entered by the user.
        /// </summary>
        /// <param name="positionInput"></param>
        /// <returns></returns>
        bool ValidateRoverPositionInput(string positionInput);

        /// <summary>
        /// This method checks the accuracy of the motion commands entered by the user.
        /// </summary>
        /// <param name="moveInput"></param>
        /// <returns></returns>
        bool ValidateRoverMoveInput(string moveInput);
    }
}
