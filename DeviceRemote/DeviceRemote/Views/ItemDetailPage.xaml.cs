using System;
using System.Collections.Generic;
using Buttplug.Client;
using Buttplug.Core.Messages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DeviceRemote.Models;
using DeviceRemote.ViewModels;

namespace DeviceRemote.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemDetailPage : ContentPage
	{
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Item
            {
                Device = new ButtplugClientDevice(0, "TestDev", new Dictionary<string, MessageAttributes>())
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}