using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaRover.Common.Attributes
{
    public class CustomDisplayAttribute : Attribute
    {
        public string Name { get; private set; }


        public CustomDisplayAttribute(string name)
        {
            Name = name;
        }
    }
}
