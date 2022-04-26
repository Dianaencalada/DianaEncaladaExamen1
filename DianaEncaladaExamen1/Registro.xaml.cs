using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DianaEncaladaExamen1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        const decimal decMonto = 1800;

        decimal decPagoMensual;

        decimal decInteres;

        public Registro()
        {
            InitializeComponent();
        }

        public Registro(string strUser, string strPass)
        {
            if (strUser.Equals("estudiante2021") && strPass.Equals("uisrael2021"))
            {
                InitializeComponent();
                LblUser.Text = strUser;
            }
            else
            {
                _ = DisplayAlert("ERROR", "Usuario o Clave Incorrectos!", "OK");
            }
        }

        private void BtnCalcular_Clicked(object sender, EventArgs e)
        {
            decInteres = decMonto * 5 / 100;

            decPagoMensual = ((decMonto - decimal.Parse(TxtMontoInicial.Text)) / 3) + decInteres;

            TxtPagoMensual.Text = decimal.Round(decPagoMensual, 2).ToString();


        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            decimal decMonto = (decPagoMensual * 3) + decimal.Parse(TxtMontoInicial.Text);

            await Navigation.PushAsync(new Resumen(LblUser.Text, TxtNombre.Text, decMonto));
        }
    }
}


