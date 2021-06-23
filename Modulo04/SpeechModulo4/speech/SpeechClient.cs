using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CognitiveServices.Speech;

namespace SpeechModulo4.speech
{
    class SpeechClient
    {
        private static readonly string API_KEY = "4f8b983472c24d16912049b22dccb42c";
        private static readonly string ENDPOINT = "https://eastus.api.cognitive.microsoft.com/sts/v1.0/issuetoken";
        public static SpeechConfig cliente { get; private set; }
        static SpeechClient() { InitSpeech(); }

        private static void InitSpeech() {
            if (cliente == null) {
                cliente = SpeechConfig.FromEndpoint(new Uri(ENDPOINT), API_KEY);
            }
        }
        

    }
}
