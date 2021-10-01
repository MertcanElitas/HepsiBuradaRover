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
            Plateau model = null;

            if (!string.IsNullOrWhiteSpace(plateauSizeInput))
            {
                var plateauSizeItems = plateauSizeInput.Split(' ');

                if (plateauSizeItems.Length == HepsiBuradaConstants.MaxPlateauInputItemCount)
                {
                    int width;
                    if (int.TryParse(plateauSizeItems[0], out width))
                    {
                        int height;
                        if (int.TryParse(plateauSizeItems[1], out height))
                        {
                            model = new Plateau()
                            {
                                Height = height,
                                Width = width,
                            };
                        }
                    }

                }
            }

            return model;
        }
    }
}
