using System;
using System.Collections.Generic;
using System.Linq;
using Mock4Net.Core;

namespace NetTelegraph.Test
{
    internal static class CommonUtils
    {
        internal static void PrintResult(IEnumerable<Request> request)
        {
            WriteConsoleLog(request.FirstOrDefault()?.Body);
            WriteConsoleLog(request.FirstOrDefault()?.Url);
        }

        private static void WriteConsoleLog(string text)
        {
            Console.WriteLine(DateTime.Now.ToLocalTime() + " " + text);
        }
    }
}
