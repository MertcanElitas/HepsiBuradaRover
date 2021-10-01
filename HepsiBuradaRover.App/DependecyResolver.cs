using HepsiBuradaRover.Bussines.Interfaces;
using HepsiBuradaRover.Bussines.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiBuradaRover.App
{
    public static class DependencyResolver
    {
        public static IServiceProvider Resolve()
        {
            ServiceProvider provider = new ServiceCollection()
                                      .AddScoped<IRoverService, RoverService>()
                                      .AddScoped<IPlateauService, PlateauService>()
                                      .BuildServiceProvider();

            return provider;
        }
    }
}
