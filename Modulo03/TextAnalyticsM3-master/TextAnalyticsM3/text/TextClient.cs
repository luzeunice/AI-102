using System;
using System.Collections.Generic;
using System.Text;
using Azure.AI.TextAnalytics;
using Azure;

namespace TextAnalyticsM3.text
{
    class TextClient
    {
        private static readonly string API_KEY = "66ddbbcdb57c4a999cf69ce68f252708";
        private static readonly string ENDPOINT = "https://cognitiveleao.cognitiveservices.azure.com/";
        public static TextAnalyticsClient text { get; private set; }

        static TextClient() { InitClient(); }

        private static void InitClient() {
            if (text == null) {
                var credentials = new AzureKeyCredential(API_KEY);
                text = new TextAnalyticsClient(new Uri(ENDPOINT), credentials);
            }
        }
    }
}
