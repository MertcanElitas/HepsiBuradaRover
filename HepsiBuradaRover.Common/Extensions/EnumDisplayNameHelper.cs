using HepsiBuradaRover.Common.Attributes;
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
        public static IList<EnumInformationDto> GetValues<T>() where T : Enum
        {
            var enumInformatios = new List<EnumInformationDto>();

            var enumValues = Enum.GetValues(typeof(T)).Cast<T>()
                           .ToList();

            foreach (var enumValue in enumValues)
            {
                var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

                var descriptionAttributes = fieldInfo.GetCustomAttributes(
                    typeof(CustomDisplayAttribute), false) as CustomDisplayAttribute[];

                string description = string.Empty;

                if (descriptionAttributes != null && descriptionAttributes.Any())
                    description = descriptionAttributes[0].Name;

                enumInformatios.Add(new EnumInformationDto()
                {
                    IntValue = enumValue.GetHashCode(),
                    Name = enumValue.ToString(),
                    Description = description
                });
            }
            return enumInformatios;
        }
    }
}
