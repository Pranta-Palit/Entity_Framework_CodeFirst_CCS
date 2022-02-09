using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace WebRole1.Programs
{
    public class GenerateLog
    {
        [Conditional("TRACE")]
        public static void LogMethodCall(params object[] callingMethodParamValues)
        {
            var method = new StackFrame(skipFrames: 1).GetMethod();
            var methodParams = method.GetParameters();
            var methodCalledBy = new StackFrame(skipFrames: 2).GetMethod();

            var methodCaller = "";
            if (methodCalledBy != null)
            {
                methodCaller = $"{methodCalledBy.DeclaringType.Name}.{methodCalledBy.Name}()";
            }

            if (methodParams.Length == callingMethodParamValues.Length)
            {
                List<string> paramList = new List<string>();
                foreach (var param in methodParams)
                {
                    paramList.Add($"{param.Name}={callingMethodParamValues[param.Position]}");
                }

                Log(method.Name, string.Join(", ", paramList), methodCaller);

            }
            else
            {
                Log(method.Name, "/* Please update to pass in all parameters */", methodCaller);
            }


        }

        private static void Log(string methodName, string parameterList, string methodCaller)
        {
            string myLogFile = @"F:\Visual Studio Workstation\Game Workspace\CCS\AzureCloudService1\AzureCloudService1\WebRole1\Programs\generatedLog.txt";
            File.AppendAllText(myLogFile, $"{DateTime.Now.ToString("hh:mm:ss.fffff")}\t{methodCaller} -> {methodName}({parameterList})\n");
        }
    }
}