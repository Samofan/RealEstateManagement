using System;
using System.Threading.Tasks;
using CliFx;
using RealEstateManagementCLI.Commands;

namespace RealEstateManagementCLI
{
    public class RealEstateManagementApplication
    {
        public static async Task<int> Main() =>
            await new CliApplicationBuilder()
                .AddCommandsFromThisAssembly()
                .Build()
                .RunAsync();
    }
}