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
    public partial class PuestoDelete : ContentPage
    {
        private string url = "https://desfrlopez.me/nosorio/api/puesto";
        public PuestoDelete()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            borrarPuestoAsync();
        }

        private async Task borrarPuestoAsync()
        {
            using (var httpClient = new HttpClient())
            {

                url = url + "/" + idForm.Text; // mandamos de parametro de url del id a modificar

                var response = await httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {

                    var content = await response.Content.ReadAsStringAsync();


                    resultado.Text = "se borro";

                    //Departamento contenido = JsonConvert.DeserializeObject<Departamento>(content);

                }
                else
                {
                    resultado.Text = "Borrado Fallido";
                }
                idForm.Text = "";
            }
        }
    }
}