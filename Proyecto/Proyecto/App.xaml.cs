using Proyecto.Views;
using ProyectoClase2.Data;
using System;
using Xamarin.Forms;

namespace Proyecto
{

    public partial class App : Application
    {
        public static DataBaseContext Context { get; set; }
        public App()
        {
            InitializeComponent();
            InitializeDataBase();



            MainPage = new NavigationPage(new HomePage());
        }

        public void InitializeDataBase()
        {
            var folderApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = System.IO.Path.Combine(folderApp, "ToDo.db3");
            Context = new DataBaseContext(dbPath);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
