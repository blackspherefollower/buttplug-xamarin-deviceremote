using System;
using System.Collections.Generic;
using Buttplug.Client;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DeviceRemote.Models;

namespace DeviceRemote.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage(ButtplugClientDevice device)
        {
            InitializeComponent();

            Item = new Item
            {
                Device = device,
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }
    }
}