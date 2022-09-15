using Newtonsoft.Json;
using Ottoniel_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ottoniel_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DepartamentoDelete : ContentPage
    {
        private string url = "https://desfrlopez.me/nosorio/api/departamento";
        public DepartamentoDelete()
        {
            InitializeComponent();
        }

        private async Task borrarDepartamentoAsync()
        {
            using (var httpClient = new HttpClient())
            {

                url = url + "/" + idForm.Text; // mandamos de parametro de url del id a modificar

                var response = await httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    
                    var content = await response.Content.ReadAsStringAsync();

                    
                    resultado.Text = "se borro esa mierda";

                    //Departamento contenido = JsonConvert.DeserializeObject<Departamento>(content);
                    
                }
                else
                {
                    resultado.Text = "Borrado Fallido";
                }
                idForm.Text = "";
            }
        }

    private void Eliminar(object sender, EventArgs e)
        {
            borrarDepartamentoAsync();
        }

        
    }
}