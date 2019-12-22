using App01_ConsultarCEP.Servico;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App01_ConsultarCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BOTAO_Clicked;
        }

        private void BOTAO_Clicked(object sender, EventArgs e)
        {
            if (!IsValidCep(CEP.Text))
            {
                DisplayAlert("ERRO", "Cep inválido.", "OK");
                return;
            }
            var endereco = ViaCepServico.BuscarEnderecoViaCEP(CEP.Text);

            RESULTADO.Text = JsonConvert.SerializeObject(endereco);

        }
        private bool IsValidCep(string cep)
        {
            bool valido = true;

            if (string.IsNullOrWhiteSpace(cep))
                valido = false;

            if (cep.Length != 8)
                valido = false;

            if (!int.TryParse(cep, out var num))
                valido = false;

            return valido;
        }

    }
}
