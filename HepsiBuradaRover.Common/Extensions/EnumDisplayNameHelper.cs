using HepsiBuradaRover.Common.DataTransferObejcts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaRover.Common.Extensions
{
    public static class EnumDisplayNameHelper
    {
        public static IList<EnumInformationDto> GetValues<T>() where T :Enum
        {
            var enumInformatios = new List<EnumInformationDto>();

            var enumFields = typeof(T).GetType().GetFields(BindingFlags.Static | BindingFlags.Public);
            foreach (FieldInfo fieldInfo in enumFields)
            {
                var name = fieldInfo.Name;

                enumInformatios.Add(new EnumInformationDto()
                {
                    Name = name
                });
            }
            return enumInformatios;
        }
    }
}
