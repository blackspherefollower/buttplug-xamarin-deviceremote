using System;

using DeviceRemote.Models;

namespace DeviceRemote.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Device.Name;
            Item = item;
        }
    }
}
