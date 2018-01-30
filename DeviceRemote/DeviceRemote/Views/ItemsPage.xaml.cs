using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buttplug.Client;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DeviceRemote.Models;
using DeviceRemote.Views;
using DeviceRemote.ViewModels;

namespace DeviceRemote.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsPage : ContentPage
	{
        ItemsViewModel viewModel;
	    private ButtplugWSClient _client;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
            _client = new ButtplugWSClient("Xamarin test");
            _client.DeviceAdded += async (s, a) =>
            {
                await Navigation.PushModalAsync(new NavigationPage(new NewItemPage(a.Device)));
            };
            _client.Connect(new Uri("wss://192.168.0.8/buttplug"), true).Wait();
            _client.StartScanning().Wait();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}