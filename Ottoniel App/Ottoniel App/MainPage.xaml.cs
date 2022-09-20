using Ottoniel_App.Models;
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

        private async void Enviar_Puesto(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PuestoMenu());
        }

        private async void Enviar_Empleado(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmpleadoMenu());
        }

        private async void Enviar_Telefono(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TelefonoMenu());
        }

        private async void Enviar_Reloj_marcador(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Reloj_marcadorMenu());
        }

        private async void Enviar_tipo_entrada(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new tipo_entradaMenu());
        }

        private async void Enviar_Especial(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EspecialMenu());
        }
    }
}
