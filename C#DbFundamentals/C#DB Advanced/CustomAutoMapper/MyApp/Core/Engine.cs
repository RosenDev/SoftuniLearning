using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Interfaces;
using MyApp.Data;

namespace MyApp.Core
{
    public class Engine:IEngine
    {
        private readonly IServiceProvider provider;
        public Engine(IServiceProvider provider)
        {
            this.provider = provider;
        }
        public void Run()
        {
            var splitSymbols = new[] { " ", " - ", ", ", "|" };
            while (true)
            {
            
                var input = Console.ReadLine()?
                    .Split(splitSymbols[0],StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (input?[0].ToLower()=="exit")
                {
                    Stop();
                    
                }
                var interpreter = provider.GetService<ICommandInterpreter>();
                using (var context= provider.GetService<SampleDbContext>())
                {
                    Console.WriteLine(interpreter.Read(input));
                  
                }
            }
        }

        private void Stop()
        {
            
            
            Environment.Exit(0);
        }
    }
}