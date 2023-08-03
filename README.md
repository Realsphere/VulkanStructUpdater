# VulkanStructUpdater
A simple Application to port C++ Vulkan structures to C# structures.

We are currently using this in our Vulkan Renderer for the Pulse Game engine.

# Usage

## Command
```
vsu <.vsu file example below> <vulkan_core.h path>
```

## VSU File
The VSU file is really just a list of the names of the Structs you want to port (without the "Vk" at the beginning)
```
DescriptorSetAllocateInfo
SpecializationInfo
PipelineShaderStageCreateInfo
```

# Why VSU?

We had the choice of porting all the Vulkan C++ structs to C#, or develop an Application to do it for us. We have decided to develop VSU to make the progress a lot faster and more efficient.
