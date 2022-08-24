using System;
using Microsoft.Extensions.Configuration;

namespace Persistence.Extensions
{
    public static class EnviromentVariableExtensions
    {
        public static string GetConnectionStringFromEnviroment(this IConfiguration configuration, string name = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Environment.GetEnvironmentVariable("ConnectionStringRentACarProject");
            }
            else
            {
                return Environment.GetEnvironmentVariable(name); ;
            }
        }
    }
}

