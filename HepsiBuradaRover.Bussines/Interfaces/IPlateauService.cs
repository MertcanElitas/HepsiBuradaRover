using HepsiBuradaRover.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaRover.Bussines.Interfaces
{
    public interface IPlateauService
    {
        /// <summary>
        /// This method create a new plateau instance.
        /// </summary>
        /// <param name="plateauInput"></param>
        /// <returns></returns>
        Plateau GeneratePlateau(string plateauInput);

        /// <summary>
        /// This method checks the accuracy of the plateau boundary entered by the user.       
        /// </summary>
        /// <param name="plateauSizeInput"></param>
        /// <returns></returns>
        bool ValidatePlateauBoundaryInput(string plateauSizeInput);
    }
}
