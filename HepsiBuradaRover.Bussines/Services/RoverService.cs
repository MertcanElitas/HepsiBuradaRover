using HepsiBuradaRover.Bussines.Concretes;
using HepsiBuradaRover.Bussines.Interfaces;
using HepsiBuradaRover.Common.Constants;
using HepsiBuradaRover.Common.DataTransferObejcts;
using HepsiBuradaRover.Common.Enumaration;
using HepsiBuradaRover.Common.Extensions;
using HepsiBuradaRover.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HepsiBuradaRover.Bussines.Services
{
    public class RoverService : IRoverService
    {
        private readonly IPlateauService _plateauService;

        public RoverService(IPlateauService plateauService)
        {
            _plateauService = plateauService;
        }

        public List<string> ExecuteRoverCommands(List<RoverDto> roverList, string plateauBoundaryInput)
        {
            List<Rover> rovers = new List<Rover>();

            foreach (var roverDto in roverList)
            {
                var roverPosition = roverDto.PositionInput.Split(' ');

                var xCoordinate = int.Parse(roverPosition[0]);
                var yCoordinate = int.Parse(roverPosition[1]);
                var directionValue = roverPosition[2];

                var directionType = (RoverDirectionType)EnumDisplayNameHelper.GetValues<RoverDirectionType>()
                                    .FirstOrDefault(x => x.Description == directionValue)
                                    .IntValue;

                var plateau = _plateauService.GeneratePlateau(plateauBoundaryInput);
                var moveCommands = GetRoverCommandList(roverDto.MoveInput);

                var rover = new Rover()
                {
                    Direction = directionType,
                    XCoordinate = xCoordinate,
                    YCoordinate = yCoordinate,
                    Plateau = plateau,
                    MoveCommands = moveCommands,
                    Order = roverDto.Order
                };

                rovers.Add(rover);
            }

            ExecuteMoveCommand(rovers);

            var result = rovers.OrderBy(x => x.Order)
                       .Select(x => x.ToString())
                       .ToList();

            return result;
        }

        public bool ValidateRoverPositionInput(string positionInput)
        {
            if (!string.IsNullOrWhiteSpace(positionInput))
            {
                var roverPosition = positionInput.Split(' ');

                if (roverPosition != null &&
                    roverPosition.Any() &&
                    roverPosition.Count() == HepsiBuradaConstants.MaxRoverPositonInputItemCount)
                {
                    int xCoordinate;
                    int yCoordinate;

                    var xCoordinateParseResult = int.TryParse(roverPosition[0], out xCoordinate);
                    var yCoordinateParseResult = int.TryParse(roverPosition[1], out yCoordinate);

                    var directionValue = roverPosition.LastOrDefault();

                    var directionTypes = EnumDisplayNameHelper.GetValues<RoverDirectionType>()
                                         .Where(x => x.IntValue != RoverDirectionType.Null.GetHashCode())
                                         .ToList();

                    if (!string.IsNullOrWhiteSpace(directionValue))
                    {
                        var directionType = directionTypes.FirstOrDefault(x => x.Description == directionValue.ToUpper());

                        if (directionType != null && yCoordinateParseResult && xCoordinateParseResult)
                        {
                            return true;
                        }
                    }
                }

            }

            return false;
        }

        public bool ValidateRoverMoveInput(string moveInput)
        {
            if (!string.IsNullOrWhiteSpace(moveInput))
            {
                var moveInputTypes = EnumDisplayNameHelper.GetValues<MoveIInputType>()
                                     .Where(x => x.IntValue != MoveIInputType.Null.GetHashCode())
                                     .ToList();

                var moveInputTypeCharList = moveInputTypes.Select(x => Convert.ToChar(x.Description)).ToList();

                var moveInputArray = moveInput.ToCharArray();

                if (moveInputArray.Any(x => !moveInputTypeCharList.Contains(x)))
                    return false;

                return true;
            }

            return false;
        }

        private void ExecuteMoveCommand(List<Rover> rovers)
        {
            foreach (var rover in rovers)
            {
                foreach (var command in rover.MoveCommands)
                {
                    if (rover.OutOfBoundary)
                        break;

                    switch (command)
                    {
                        case MoveIInputType.Left:
                            using (var leftMove = new TurnLeftMovement())
                                leftMove.Execute(rover);
                            break;
                        case MoveIInputType.Right:
                            using (var rightMove = new TurnRightMovement())
                                rightMove.Execute(rover);
                            break;
                        case MoveIInputType.Move:
                            using (var forwardMove = new ForwardMovement())
                                forwardMove.Execute(rover);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private List<MoveIInputType> GetRoverCommandList(string moveInput)
        {
            var moveInputTypes = EnumDisplayNameHelper.GetValues<MoveIInputType>()
                                     .Where(x => x.IntValue != MoveIInputType.Null.GetHashCode())
                                     .ToList();

            var moveInputArray = moveInput.ToCharArray();

            var result = new List<MoveIInputType>();

            foreach (var moveInputItem in moveInputArray)
            {
                var moveInputEnum = (MoveIInputType)moveInputTypes
                                   .FirstOrDefault(x => Convert.ToChar(x.Description) == moveInputItem)
                                   .IntValue;

                result.Add(moveInputEnum);
            }

            return result;
        }
    }
}
