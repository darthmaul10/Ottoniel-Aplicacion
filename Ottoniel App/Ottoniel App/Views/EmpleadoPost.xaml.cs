using Ottoniel_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ottoniel_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpleadoPost : ContentPage
    {

        private string url = "https://desfrlopez.me/nosorio/api/empleado/";
        public EmpleadoPost()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            crearEmpleadoAsync();
        }

        private async Task crearEmpleadoAsync()
        {
            using (var httpClient = new HttpClient())
            {
                Empleado dep = new Empleado()
                {
                    nombre = nombreForm.Text,
                    fecha_nacimiento = fechaForm.Text,
                    id_puesto = int.Parse(idForm.Text),
                    nacionalidad = naciForm.Text,
                };

                var body = dep.ToJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado.Text = "Insercion Exitosa";
                }
                else
                {
                    resultado.Text = "Insercion Fallida";
                }

                nombreForm.Text = "";
            }
        }

    }
}