using System;

namespace VulkanStructUpdater
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 2) 
            {
                Console.WriteLine("Usage: vsu <VSU File> <vulkan_core.h path>");
                return;
            }

            Console.WriteLine("Parsing VSU...");
            var targetStructs = VSUParser.Parse(args[0]);
            Console.WriteLine("Parsing vulkan_core.h ...");
            var structsLoaded = VulkanCoreStruct.Load(args[1]);

            Console.WriteLine("\n\n\nParsing finished, beginning main process...");

            VulkanCoreStruct GetVulkanStructure(string name)
            {
                foreach (var s in structsLoaded)
                {
                    if (s.Name.Contains(name)) return s;
                }
                throw new("Could not find struct with name " + name);
            }

            List<string> lines = new();
            foreach (var targetStruct in targetStructs)
            {
                Console.WriteLine("Porting " + targetStruct + "...");
                // Get the VulkanCore struct
                var vk = GetVulkanStructure(targetStruct);

                lines.Add("internal unsafe struct " + vk.Name + " {");
                foreach (var l in vk.RawCode)
                {
                    lines.Add("\tinternal " + CPPCSPorter.Port(l));
                }
                lines.Add("}");
            }

            File.WriteAllLines("structs.txt", lines);
        }
    }
}