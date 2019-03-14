using System;
using System.Linq;
using System.Reflection;
using BillsPaymentSystem.App.Interfaces;
using BillsPaymentSystem.Data;

namespace BillsPaymentSystem.App.Core
{
    public class CommandInterpreter:ICommandInterpreter
    {
        private const string Sullfix = "Command";
        public string Read(string[] args,BillsPaymentSystemContext context)
        {
            try
            {
                var cmd = args[0];
                var cmdArgs = args.Skip(1).ToArray();
                var type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == cmd + Sullfix);
                if (type == null)
                {
                    throw new ArgumentNullException("Type not found");
                }
                var cmdInstance = Activator.CreateInstance(type, context);
                var result = ((ICommand)cmdInstance).Execute(cmdArgs);
                return result;
            }
            catch (ArgumentNullException e)
            {
                return e.ParamName;

            }
          
        }
    }
}