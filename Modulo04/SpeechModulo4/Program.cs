using System;
using SpeechModulo4.speech;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace SpeechModulo4
{
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = SpeechClient.cliente;
            Console.WriteLine("Habla en micrófono");
            getText(cliente);
            Console.ReadKey();
           
            
        }

        private static async void getText(SpeechConfig cliente) {
            var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
            var speechRecognizer = new SpeechRecognizer(cliente, "es-MX", audioConfig);
            var respuesta =await  speechRecognizer.RecognizeOnceAsync();
            
            Console.WriteLine($"texto: {respuesta.Text}");
        }
    }
}
