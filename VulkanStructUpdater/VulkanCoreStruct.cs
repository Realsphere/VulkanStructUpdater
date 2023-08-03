using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VulkanStructUpdater
{
    internal struct VulkanCoreStruct
    {
        public string Name;
        public List<string> RawCode;

        public static List<VulkanCoreStruct> Load(string vkCore)
        {
            string SubstringTFNS(string input)
            {
                int index = 0;
                if (string.IsNullOrWhiteSpace(input)) return input;
                while (input[index] == ' ')
                {
                    if (index + 1 > input.Length) break;
                    index++;
                }
                if (index == -1) return input;
                return input.Substring(index);
            }

            List<VulkanCoreStruct> result = new();
            VulkanCoreStruct current = new();
            bool inCoreStruct = false;
            foreach (var rawline in File.ReadAllLines(vkCore))
            {
                string line = SubstringTFNS(rawline);
                if (line.StartsWith("#")) continue;
                if (string.IsNullOrWhiteSpace(line)) continue;
                if(inCoreStruct && line.StartsWith("}"))
                {
                    result.Add(current);
                    inCoreStruct = false;
                    current = new();
                }
                if (inCoreStruct)
                {
                    current.RawCode.Add(line);
                    Console.WriteLine("\tDetected Field \"" + line.Split(" ").Last().Substring(0, line.Split(" ").Last().Length - 1) + "\"");
                }
                if(!inCoreStruct)
                {
                    if(line.StartsWith("typedef struct")) 
                    {
                        current.Name = line.Substring(("typedef struct ").Length);
                        current.Name = current.Name.Split(" {")[0];
                        current.RawCode = new();
                        inCoreStruct = true;
                        Console.WriteLine("Detected struct \"" + current.Name + "\"");
                    }
                }
            }
            Console.WriteLine("Detected " + result.Count + " structs");
            return result;
        }
    }
}
