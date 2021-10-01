using HepsiBuradaRover.Bussines.Interfaces;
using HepsiBuradaRover.Common.Constants;
using HepsiBuradaRover.Common.Enumaration;
using HepsiBuradaRover.Common.Extensions;
using HepsiBuradaRover.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaRover.Bussines.Services
{
    public class RoverService : IRoverService
    {
        public Rover GenerateRover(string positionInput, string moveInput,Plateau plateau)
        {
            Rover model = null;

            var roverPosition = positionInput.Split(' ');

            if (roverPosition != null &&
                roverPosition.Any() &&
                roverPosition.Count() == HepsiBuradaConstants.MaxRoverPositonInputItemCount)
            {
                var xCoordinate = int.Parse(roverPosition[0]);
                var yCoordinate = int.Parse(roverPosition[1]);

                var directionValue = roverPosition.LastOrDefault();

                //Check Enum List
                //Todo Custom Attributes
                var directionTypes = EnumDisplayNameHelper.GetValues<RoverDirectionType>();

                if (!string.IsNullOrWhiteSpace(directionValue))
                {
                    var directionType = directionTypes.FirstOrDefault(x => x.Description == directionValue.ToUpper());

                    if (directionType != null)
                    {
                        model = new Rover()
                        {
                            Direction = (RoverDirectionType)directionType.IntVaue,
                            XCoordinate = xCoordinate,
                            YCoordinate = yCoordinate,
                            MoveInput = moveInput,
                            Plateau=plateau
                        };
                    }
                }
            }

            return model;
        }
    }
}
