using System;
using CognitiveServices.Cognitive;

namespace CognitiveServices
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Obteniendo idioma usando el servicio cognitivo*/
            /*Conectando servicio cognitivo*/
            var servicio = TextClient.Text;

            /*Obteniendo texto de la consola*/
            Console.WriteLine("Escribe texto: ");
            var texto = Console.ReadLine();

            /*Ejecutando detección de idioma*/
            var resultado = servicio.DetectLanguage(texto);

            /*Imprimiendo resultado*/
            Console.WriteLine($"idioma:{resultado.Value.Name}");
            Console.WriteLine($"ISO6391:{resultado.Value.Iso6391Name}");
            Console.WriteLine($"Score:{resultado.Value.ConfidenceScore}");
            Console.ReadKey();
        }
    }
}
