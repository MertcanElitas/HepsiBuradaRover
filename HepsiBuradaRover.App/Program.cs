using HepsiBuradaRover.Bussines.Interfaces;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using HepsiBuradaRover.Common.DataTransferObejcts;
using System.Linq;

namespace HepsiBuradaRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            //var aa = Enum.GetValues(typeof(Test)).Cast<Test>()
            //                .ToList();



            #region " Dependency Injection "

            var provider = DependencyResolver.Resolve();

            var roverService = provider.GetService<IRoverService>();
            var plateauService = provider.GetService<IPlateauService>();

            #endregion

            var plateauInput = InitializePlateau(plateauService);
            var roverInputs = InitializeRover(roverService);

            var roverMoveResults = roverService.GenerateRover(roverInputs, plateauInput);

            foreach (var item in roverMoveResults)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        #region " UI Operations "

        private static string InitializePlateau(IPlateauService plateauService)
        {
            string plateauInput = null;
            bool isInsertPlateauInput = true;

            while (isInsertPlateauInput)
            {
                Console.WriteLine("Plateau grid size :");
                plateauInput = Console.ReadLine();

                var isValidPlateauInputResult = plateauService.ValidatePlateauInput(plateauInput);

                isInsertPlateauInput = !isValidPlateauInputResult;

                if (!isValidPlateauInputResult)
                {
                    Console.WriteLine($"You have entered wrong data, please check : {plateauInput}");
                    continue;
                }
            }

            return plateauInput;
        }

        private static List<RoverDto> InitializeRover(IRoverService roverService)
        {
            var isContinueInsertRover = true;
            int order = 1;
            List<RoverDto> rovers = new List<RoverDto>();

            while (isContinueInsertRover)
            {
                string roverPositionInput = string.Empty;
                string roverMoveInput = string.Empty;

                bool isContinueInsertRoverPosition = true;
                bool isContinueInsertRoverMoveInput = true;

                while (isContinueInsertRoverPosition)
                {
                    Console.WriteLine("Please Enter Rover Position :");
                    roverPositionInput = Console.ReadLine();

                    var isValidRoverPosition = roverService.ValidateRoverPositionInput(roverPositionInput);

                    isContinueInsertRoverPosition = !isValidRoverPosition;

                    if (!isValidRoverPosition)
                    {
                        Console.WriteLine($"You have entered wrong data, please check : {roverPositionInput}");
                        continue;
                    }
                }

                while (isContinueInsertRoverMoveInput)
                {
                    Console.WriteLine("Please Enter Rover Move Input :");
                    roverMoveInput = Console.ReadLine();

                    var isValidRoverMoveInput = roverService.ValidateRoverMoveInput(roverMoveInput);

                    isContinueInsertRoverMoveInput = !isValidRoverMoveInput;

                    if (!isValidRoverMoveInput)
                    {
                        Console.WriteLine($"You have entered wrong data, please check : {roverMoveInput}");
                        continue;
                    }
                }

                var dto = new RoverDto()
                {
                    MoveInput = roverMoveInput,
                    PositionInput = roverPositionInput,
                    Order = order++
                };

                rovers.Add(dto);

                Console.WriteLine("Do you want to insert rover ? (Y)");
                var isInsertRoverInput = Console.ReadLine();

                if (isInsertRoverInput.ToUpper() != "Y")
                {
                    isContinueInsertRover = false;
                }
            }

            return rovers;
        }

        #endregion
    }

    public enum Test
    {
        mertcan = 1,
        gamze = 2,
        Mine = 3,
        Ahmet = 4
    }
}
