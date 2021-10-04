using HepsiBuradaRover.Bussines.Interfaces;
using HepsiBuradaRover.Bussines.Services;
using HepsiBuradaRover.Common.DataTransferObejcts;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HepsiBuradaRover.Test
{
    public class RoverTest
    {
        private readonly IRoverService _roverService;
        private readonly IPlateauService _plateauService;

        public RoverTest()
        {
            _plateauService = new PlateauService();
            _roverService = new RoverService(_plateauService);
        }

        [Fact]
        public void RoverMoveCommandTest()
        {
            #region " ArrangeData "

            var roverList = ArrangeRoverData();
            var plateauInput = "5 5";

            string firstOutput = "1 3 N";
            string secondOutput = "5 1 E";
            string thirdOutput = "3 2 S";

            #endregion
            #region " Act "

            var result = _roverService.ExecuteRoverCommands(roverList, plateauInput);

            #endregion
            #region " Asserts "

            Assert.Equal(firstOutput, result[0]);
            Assert.Equal(secondOutput, result[1]);
            Assert.Equal(thirdOutput, result[2]);

            #endregion
        }

        [Fact]
        public void ValidatePlateauBoundaryInputTest()
        {
            #region " ArrangeData "

            var firstInput = "5 5";
            var secondInput = "1 7";
            var thirdInput = "1 8 9";
            var fourthInput = "1 8 n";

            #endregion
            #region " Act "

            var firstResult = _plateauService.ValidatePlateauBoundaryInput(firstInput);
            var secondResult = _plateauService.ValidatePlateauBoundaryInput(secondInput);
            var thirdResult = _plateauService.ValidatePlateauBoundaryInput(thirdInput);
            var fourthResult = _plateauService.ValidatePlateauBoundaryInput(fourthInput);

            #endregion
            #region " Assert "

            Assert.True(firstResult);
            Assert.True(secondResult);
            Assert.False(thirdResult);
            Assert.False(fourthResult);

            #endregion
        }

        [Fact]
        public void ValidateRoverPositionInputTest()
        {
            #region " ArrangeData "

            var firstInput = "1 2 N";
            var secondInput = "A B C";
            var thirdInput = "4 2 F";
            var fourthInput = "4 5 S";

            var plateauService = new PlateauService();
            var roverService = new RoverService(plateauService);

            #endregion
            #region " Act "

            var firstResult = _roverService.ValidateRoverPositionInput(firstInput);
            var secondResult = _roverService.ValidateRoverPositionInput(secondInput);
            var thirdResult = _roverService.ValidateRoverPositionInput(thirdInput);
            var fourthResult = _roverService.ValidateRoverPositionInput(fourthInput);

            #endregion
            #region " Assert "

            Assert.True(firstResult);
            Assert.False(secondResult);
            Assert.False(thirdResult);
            Assert.True(fourthResult);

            #endregion
        }

        [Fact]
        public void ValidateRoverMoveInputTest()
        {
            #region " ArrangeData "

            var firstInput = "LRLMRLMMRRML";
            var secondInput = "SLMAX";
            var thirdInput = "RMLLLRRM";
            var fourthInput = "MERTCAN";

            #endregion
            #region " Act "

            var firstResult = _roverService.ValidateRoverMoveInput(firstInput);
            var secondResult = _roverService.ValidateRoverMoveInput(secondInput);
            var thirdResult = _roverService.ValidateRoverMoveInput(thirdInput);
            var fourthResult = _roverService.ValidateRoverMoveInput(fourthInput);

            #endregion
            #region " Assert "

            Assert.True(firstResult);
            Assert.False(secondResult);
            Assert.True(thirdResult);
            Assert.False(fourthResult);

            #endregion
        }

        private List<RoverDto> ArrangeRoverData()
        {
            #region " ArrangeData "

            var roverDtoFirst = new RoverDto()
            {
                Order = 1,
                MoveInput = "LMLMLMLMM",
                PositionInput = "1 2 N"
            };

            var roverDtoSecond = new RoverDto()
            {
                Order = 2,
                MoveInput = "MMRMMRMRRM",
                PositionInput = "3 3 E"
            };

            var roverDtoThird = new RoverDto()
            {
                Order = 3,
                MoveInput = "MRMLMRMRM",
                PositionInput = "1 1 N"
            };

            #endregion

            var result = new List<RoverDto>
            {
                roverDtoFirst,
                roverDtoSecond,
                roverDtoThird
            };

            return result;
        }
    }
}
