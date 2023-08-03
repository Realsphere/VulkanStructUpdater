using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulkanStructUpdater
{
    internal class VSUParser
    {
        public static List<string> Parse(string input)
        {
            return File.ReadAllLines(input).ToList();
        }
    }
}
