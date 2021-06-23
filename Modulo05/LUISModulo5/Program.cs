using System;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime;
using Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.Models;
using LUISModulo5.luis;
using Newtonsoft.Json.Linq;

namespace LUISModulo5
{
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = LuisClient.Cliente;
            Console.WriteLine("-.-.-.-.Prueba de LUIS en C#-.-.-.-.-.");
            Console.WriteLine("Escribe una intención: ");
            var mensaje = Console.ReadLine();
            GetPrediction(cliente, mensaje);
            Console.ReadKey();
            

            
        }

        private async static void GetPrediction(LUISRuntimeClient cliente, string mensaje) {
            var kbLUIS = "30018600-f54e-46ce-a650-954172c06484";
            var request = new PredictionRequest { 
              Query= mensaje
            };
            var result = await cliente.Prediction.GetSlotPredictionAsync(Guid.Parse(kbLUIS), slotName:"Staging", request);
            var prediction = result.Prediction;
            switch (prediction.TopIntent) {
                case "EnviaCorreo":
                    Console.WriteLine("La intención es enviar correo");
                    var entities = prediction.Entities;
                    var correo = entities["Correo"];
                    Console.WriteLine($"Enviando correo a {((JArray)correo)[0]}");
                    break;
                default:
                    Console.WriteLine("No se cuál es la intención del usuario");
                    break;
            }

        }


    }
}
