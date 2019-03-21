using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Core.Interfaces;
using MyApp.Data;
using Remotion.Linq.Clauses.ResultOperators;

namespace MyApp.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider provider;

        public CommandInterpreter(IServiceProvider provider)
        {
            this.provider = provider;
        }
        public string Read(string[] args)
        {
            var tpeStr = args[0];
            var cmdArgs = args.Skip(1).ToArray();
            var cmdType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name == tpeStr + "Command");

            var constructor = cmdType?
                .GetConstructors()
                .FirstOrDefault();

            var @params = constructor?
                .GetParameters()
                .Select(x => x.ParameterType)
                .ToArray();

            var services = @params?.Select(this.provider.GetService)
                .ToArray();
            var command = (ICommand)Activator.CreateInstance(cmdType,services);
            var result = command.Execute(cmdArgs);
            return result;


        }
    }
}