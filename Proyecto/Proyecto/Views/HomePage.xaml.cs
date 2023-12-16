using Proyecto;
using Proyecto.Models;
using Proyecto.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadItems();
        }

        private async void LoadItems()
        {
            var items = await App.Context.GetItemsAsync();
            lista_tareas.ItemsSource = items;
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmación", "¿Esta seguro de eliminar el elemento?", "Si", "No"))
            {
                var item = (ToDoItem)(sender as MenuItem).CommandParameter;
                var result = await App.Context.DeleteItemAsync(item);
                if (result == 1)
                {
                    LoadItems();
                }
            }

        }

        private async void ListaTareas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedTask = e.Item as ToDoItem;
            if (selectedTask != null)
            {
                await Navigation.PushAsync(new EditPage(selectedTask));
            }

            // Deselecciona el elemento de la lista
            ((ListView)sender).SelectedItem = null;
        }
    }
}