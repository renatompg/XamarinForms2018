using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCepServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            WebClient wc = new WebClient();
            var content = wc.DownloadString(string.Format(EnderecoURL, cep));
            return JsonConvert.DeserializeObject<Endereco>(content);
        }
    }
}
