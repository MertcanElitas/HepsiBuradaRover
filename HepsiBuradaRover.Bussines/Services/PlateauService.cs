using HepsiBuradaRover.Bussines.Interfaces;
using HepsiBuradaRover.Common.Constants;
using HepsiBuradaRover.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaRover.Bussines.Services
{
    public class PlateauService : IPlateauService
    {
        public Plateau GeneratePlateau(string plateauSizeInput)
        {
            var plateauSizeItems = plateauSizeInput.Split(' ');

            int width = int.Parse(plateauSizeItems[0]);
            int height = int.Parse(plateauSizeItems[1]);

            var plateau = new Plateau()
            {
                Height = height,
                Width = width,
            };

            return plateau;
        }

        public bool ValidatePlateauInput(string plateauSizeInput)
        {
            if (!string.IsNullOrWhiteSpace(plateauSizeInput))
            {
                var plateauSizeItems = plateauSizeInput.Split(' ');

                if (plateauSizeItems.Length == HepsiBuradaConstants.MaxPlateauInputItemCount)
                {
                    int width;
                    int height;

                    var widthParseResult = int.TryParse(plateauSizeItems[0], out width);
                    var heightParseReuslt = int.TryParse(plateauSizeItems[1], out height);

                    if (widthParseResult && heightParseReuslt)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
