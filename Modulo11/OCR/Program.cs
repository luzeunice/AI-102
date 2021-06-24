using System;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.IO;
using System.Threading;
using OCR.computer;

namespace OCR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-.-.-.Bienvenido a OCR-.-.");
            Console.WriteLine("Escribe url imagen: ");
            var url = Console.ReadLine();
            var cliente = ComputerClient.Cliente;
            getTexto(cliente, url);
            Console.ReadKey();

        }


        private async static void getTexto(ComputerVisionClient cliente, string url) {
            var streamImg = new FileStream(url, FileMode.Open, FileAccess.Read, FileShare.Read);

            var text = await cliente.ReadInStreamAsync(streamImg, language: "es");
            var operacion = text.OperationLocation;
            Thread.Sleep(2000);

            const int numero = 36;
            Console.WriteLine("Operation Location");
            Console.WriteLine(operacion.Substring(operacion.Length - numero));
            var operationId = operacion.Substring(operacion.Length - numero);

            //extraer el texto
            ReadOperationResult results;
            Console.WriteLine("Extrayendo de url: ");
            Console.WriteLine();

            do {
                results = await cliente.GetReadResultAsync(Guid.Parse(operationId));
            } while ((results.Status == OperationStatusCodes.Running) || (results.Status == OperationStatusCodes.NotStarted));

            //Deplegando texto encontrado en imagen

            Console.WriteLine();
            var textUrl = results.AnalyzeResult.ReadResults;

            foreach (var res in textUrl) {
                foreach (var linea in res.Lines) {
                    Console.WriteLine(linea.Text);
                }
            }
            Console.WriteLine();



        }

    }
}
