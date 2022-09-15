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
    public partial class DepartamentoPut : ContentPage
    {

        private string url = "https://desfrlopez.me/nosorio/api/departamento";

        public DepartamentoPut()
        {
            InitializeComponent();
        }

        private async Task actualizarPersonaAsync()
        {
            using (var httpClient = new HttpClient())
            {

                Departamento x = new Departamento()
                {
                    id_departamento = int.Parse(idForm.Text),
                    nombre = nombreForm.Text,
                    
                };
                url = url + "/" + x.id_departamento; // mandamos de parametro de url del id a modificar
                var body = x.ToJson();
                HttpContent c = new StringContent(body, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, c);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    resultado.Text = "Actulizacion Exitosa";
                }
                else
                {
                    resultado.Text = "Actulizacion Fallida";
                }

                nombreForm.Text = "";
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            actualizarPersonaAsync();
        }
    }
}