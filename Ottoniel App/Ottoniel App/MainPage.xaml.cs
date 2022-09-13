using Ottoniel_App.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ottoniel_App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Enviar_Departamento(object sender, EventArgs e)
        {
            await Navigation.PushAsync( new DepartamentoMenu());
        }
    }
}
