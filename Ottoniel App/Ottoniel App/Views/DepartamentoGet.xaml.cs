

using Ottoniel_App.Models;
using Newtonsoft.Json;
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
    public partial class DepartamentoGet : ContentPage

        
    {
        private string url = "https://desfrlopez.me/nosorio/api/departamento/";
        public DepartamentoGet()
        {
            InitializeComponent();
            getDepartamento();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            getDepartamento();
        }

        private async Task getDepartamento()
        {
            using (var httpClient = new HttpClient())
            {

                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    List<Departamento> contenido = JsonConvert.DeserializeObject<List<Departamento>>(content);

                    string tempRes = "";

                    for (int i = 0; i < contenido.Count; i++)
                    {

                        tempRes = tempRes + "id_departamento: " + contenido[i].id_departamento + " nombre: " + contenido[i].nombre + "\n";

                    }

                    resultado.Text = tempRes;
                }
                else
                {
                    resultado.Text = "Carga Fallida de Departamentos";
                }




            }
        }
    }
}