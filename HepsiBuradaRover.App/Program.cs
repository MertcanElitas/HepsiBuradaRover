using HepsiBuradaRover.Bussines.Interfaces;
using System;
using Microsoft.Extensions.DependencyInjection;
using HepsiBuradaRover.Domain.Domains;
using System.Collections.Generic;

namespace HepsiBuradaRover.App
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            #region " Dependency Injection "

            var provider = DependencyResolver.Resolve();

            var roverService = provider.GetService<IRoverService>();
            var plateauService = provider.GetService<IPlateauService>();

            #endregion


            var plateau = InitializePlateau(plateauService);
            var rovers = InitializeRover(roverService, plateau);
        }

        private static Plateau InitializePlateau(IPlateauService plateauService)
        {
            Plateau model = null;

            while (model == null)
            {
                Console.WriteLine("Plateau grid size :");
                var plateauInput = Console.ReadLine();

                model = plateauService.GeneratePlateau(plateauInput);
            }

            return model;
        }
        private static List<Rover> InitializeRover(IRoverService roverService, Plateau plateau)
        {
            var isContinueInsertRover = true;
            List<Rover> rovers = new List<Rover>();

            while (isContinueInsertRover)
            {
                Console.WriteLine("Please Enter Rover position :");
                var roverPositionInput = Console.ReadLine();

                Console.WriteLine("Please Enter Rover command :");
                var roverMoveInput = Console.ReadLine();

                var rover = roverService.GenerateRover(roverPositionInput, roverMoveInput, plateau);

                if (rover == null)
                    Console.WriteLine("There is a problem :");
                else
                    rovers.Add(rover);

                Console.WriteLine("Do you want to insert rover ? (Y)");
                var addAnotherRoverInput = Console.ReadLine();

                if (addAnotherRoverInput.ToUpper() != "Y")
                {
                    isContinueInsertRover = false;
                }
            }

            return rovers;
        }
    }
}
