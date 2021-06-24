using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;

namespace OCR.computer
{
    class ComputerClient
    {
        private static readonly string APIKEY = "f8d5bad6a1ac4e6ba2d685435258b2ea";
        private static readonly string ENDPOINT = "https://compvisionleao.cognitiveservices.azure.com/";
        public static ComputerVisionClient Cliente { get; private set; }

        static ComputerClient() { InitComputer(); }

        private static void InitComputer() {
            var credenciales = new ApiKeyServiceClientCredentials(APIKEY);
            Cliente = new ComputerVisionClient(credenciales) { Endpoint=ENDPOINT};
        }

        
    }
}
