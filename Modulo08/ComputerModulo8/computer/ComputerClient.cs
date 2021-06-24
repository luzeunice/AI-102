using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerModulo8.computer
{
    class ComputerClient
    {
        public static ComputerVisionClient clienteComputer { get; set; }
        private static string endpoint = "https://computerenvef.cognitiveservices.azure.com/";
        private static string apiKey = "c335ea0982e543719821285136e137f4";
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
