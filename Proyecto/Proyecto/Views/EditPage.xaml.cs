using Proyecto.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proyecto.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        private ToDoItem _taskToEdit;

        public ToDoItem TaskToEdit
        {
            get { return _taskToEdit; }
            set
            {
                if (_taskToEdit != value)
                {
                    _taskToEdit = value;
                    OnPropertyChanged(nameof(TaskToEdit));
                }
            }
        }

        public EditPage(ToDoItem task)
        {
            InitializeComponent();
            TaskToEdit = task;

            BindingContext = this; // Esto permite el uso de Binding
        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                TaskToEdit.Name = nombre.Text;
                TaskToEdit.Description = descripcion.Text;
                TaskToEdit.State = estadoPicker.SelectedItem.ToString();

                var result = await App.Context.UpdateItemAsync(TaskToEdit);

                if (result == 1)
                {
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo actualizar la tarea", "Aceptar");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }
        }
    }
}
