using System;
using Buttplug.Client;

namespace DeviceRemote.Models
{
    public class Item
    {
        public ButtplugClientDevice Device;
        public string Id => "" + Device.Index;
        public string Name => Device.Name;
        public string Description => Device.Name;
    }
}