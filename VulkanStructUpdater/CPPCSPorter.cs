using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulkanStructUpdater
{
    internal class CPPCSPorter
    {
        public static string Port(string toPort)
        {
            // more to add maybe later
            string result = toPort;
            result = result.Replace("const", "");
            result = result.Replace("char*", "IntPtr");
            result = result.Replace("char**", "IntPtr");
            return result;
        }
    }
}
