using HepsiBuradaRover.Common.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaRover.Common.Enumaration
{
    public enum MoveIInputType
    {
        Null = 0,

        [CustomDisplay("L")]
        Left = 1,

        [CustomDisplay("R")]
        Right = 2,

        [CustomDisplay("M")]
        Move = 3
    }
}
