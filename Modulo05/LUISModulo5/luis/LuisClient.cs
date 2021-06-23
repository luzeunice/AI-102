using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;

namespace LUISModulo5.luis
{
    class LuisClient
    {
        private static readonly string API_KEY = "3882d2f2b4f1498ca6312471721d0a00";
        private static readonly string ENDPOINT = "https://westus.api.cognitive.microsoft.com/";

        public static LUISRuntimeClient Cliente { get; private set; }

        static LuisClient() { InitLuis(); }
        private static void InitLuis() {
            if (Cliente==null) {
                var credentials = new ApiKeyServiceClientCredentials(API_KEY);
                Cliente = new LUISRuntimeClient(credentials) { Endpoint=ENDPOINT};
            }
        }

    }
}
