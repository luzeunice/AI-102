using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerModulo8.computer
{
    class ComputerClient
    {
        public static ComputerVisionClient clienteComputer { get; set; }
        private static string endpoint = "https://compvisionleao.cognitiveservices.azure.com/";
        private static string apiKey = "f8d5bad6a1ac4e6ba2d685435258b2ea";
        static ComputerClient()
        {
            Console.WriteLine("inicializando Cliente Computer");
            InicializeComputerClient();
        }

        private static void InicializeComputerClient()
        {
            var credentials = new ApiKeyServiceClientCredentials(apiKey);
            clienteComputer = new ComputerVisionClient(credentials)
            { Endpoint = endpoint };
        }

    }
}
