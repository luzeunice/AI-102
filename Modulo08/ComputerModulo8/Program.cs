using System;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using System.Linq;
using ComputerModulo8.computer;
using System.IO;
namespace ComputerModulo8

{
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = ComputerClient.clienteComputer;
            Console.WriteLine("Escribe url de imagen local: ");
            var url = Console.ReadLine();
            DescribeImage(cliente, url);

            Console.ReadKey();
           
        }

        private async static void DescribeImage(ComputerVisionClient cliente, String url) {
            var imgStream = new FileStream(url, FileMode.Open, FileAccess.Read, FileShare.Read);
            var result = await cliente.DescribeImageInStreamAsync(imgStream, language:"es");
            var captions = result.Captions;
            var tags = result.Tags;
            Console.WriteLine("-.-.-.Descripción general de la imagen-.-.-.");
            Console.WriteLine($"Descripción de imagen: {captions[0].Text}");
            Console.WriteLine($"Score: {captions[0].Confidence}");
            Console.WriteLine($"-.-.-.Etiquetas.--.-.-.-.");
            tags.ToList().ForEach(t => Console.WriteLine($"tag: {t}")) ;
            
        
        }
    }
}
