using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HepsiBuradaRover.Common.Attributes;

namespace HepsiBuradaRover.Common.Enumaration
{
    public enum RoverDirectionType
    {
        Null = 0,

        [CustomDisplay("N")]
        North = 1,

        [CustomDisplay("E")]
        East = 2,

        [CustomDisplay("S")]
        South = 3,

        [CustomDisplay("W")]
        West = 4


    }

}
