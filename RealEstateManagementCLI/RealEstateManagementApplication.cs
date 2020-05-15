using System;
using System.Threading.Tasks;
using CliFx;

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