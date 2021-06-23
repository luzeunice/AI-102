using System;
using System.Collections.Generic;
using System.Text;
using Azure.AI.TextAnalytics;
using Azure;
using CognitiveServices.Key;

namespace CognitiveServices.Cognitive
{
    /*
     * Esta clase se conecta al servicio cognitivo azure. 
     * Información necesaria: 
     * ENDPOIN
     * APIKEY
     */
    class TextClient
    {
        private static readonly string ENDPOINT = "https://cognitiveleao.cognitiveservices.azure.com/";
        //private static readonly string API_KEY = "66ddbbcdb57c4a999cf69ce68f252708";

        /* Atributo necesario para obtener el servicio cognitivo fuera de la clase*/
        public static TextAnalyticsClient Text { get; private set; }
        /* private set: nadie fuera de estas llaves puede modificar el set 
         * get:cualquiera fuera de las llaves puede llamar el get
         */

        /* Constructor : Es utilizado para inicializar los atributos de una clase*/
        static TextClient() { InitText(); }
        /*Metodo que nos ayuda a conectar el servicio cognitivo con la clase*/
        private static void InitText()
        {
            if (Text == null) {
                var API_KEY = KeyClient.Secret.GetSecret("cognitiveleaok1").Value.Value;
                var credential = new AzureKeyCredential(API_KEY);
                Text = new TextAnalyticsClient(new Uri(ENDPOINT), credential);
            }
        }

    }
}
