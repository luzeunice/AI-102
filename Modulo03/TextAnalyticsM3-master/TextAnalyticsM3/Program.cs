using System;
using Azure.AI.TextAnalytics;
using TextAnalyticsM3.text;
using System.Linq;
namespace TextAnalyticsM3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-.-.-.Operaciones TextAnalytics-.-.-.");
            Console.WriteLine("Opciones:\n1.-DetectLanguage\n2.-KeyPhrases\n3.-LinkedEntities\n4.-NamedEntities\n5.-DetectSentiment");
            Console.WriteLine("Selecciona opción: ");
            int opc = int.Parse(Console.ReadLine());
            var cliente = TextClient.text;
            
            var mensaje = "";
            while (opc != 6) {
                switch (opc) {
                    case 1:
                        Console.WriteLine("-.-.-.-.DETECT LANGUAJE-.-.-.-.");
                        Console.WriteLine("Escribe mensaje: ");
                        mensaje = Console.ReadLine();
                        getLenguaje(mensaje, cliente);
                        Console.WriteLine("Selecciona opción: ");
                        opc = int.Parse(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("-.-.-.-.KEY PHRASES-.-.-.-.");
                        Console.WriteLine("Escribe mensaje: ");
                        mensaje = Console.ReadLine();
                        getKeyPhrases(mensaje, cliente);
                        Console.WriteLine("Selecciona opción: ");
                        opc = int.Parse(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("-.-.-.LINKED ENTITIES-.-.-.-.");
                        Console.WriteLine("Escribe mensaje: ");
                        mensaje = Console.ReadLine();
                        getEntitiesKB(mensaje,cliente);
                        Console.WriteLine("Selecciona opción: ");
                        opc = int.Parse(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("-.-.-.-.NAMED ENTITIES-.-.-.-.");
                        Console.WriteLine("Escribe mensaje: ");
                        mensaje = Console.ReadLine();
                        getEntitiesNamed(mensaje,cliente);
                        Console.WriteLine("Selecciona opción: ");
                        opc = int.Parse(Console.ReadLine()) ;
                        break;
                    case 5:
                        Console.WriteLine("-.-.-.-.DETECT SENTIMENT-.-.-.-.");
                        Console.WriteLine("Escribe mensaje: ");
                        mensaje = Console.ReadLine();
                        getSentiment(mensaje, cliente);
                        Console.WriteLine("Selecciona opción: ");
                        opc = int.Parse(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("OPCIÓN INVÁLIDA!!!!!!!");
                        Console.WriteLine("Selecciona opción: ");
                        opc = int.Parse(Console.ReadLine());
                        break;
                }
            }
        }

        private static void getLenguaje(string mensaje, TextAnalyticsClient client) {
            var lenguaje = client.DetectLanguage(mensaje);
            Console.WriteLine($"Idioma: {lenguaje.Value.Name}");
            Console.WriteLine($"ISO6391: {lenguaje.Value.Iso6391Name}");
            Console.WriteLine($"Score: {lenguaje.Value.ConfidenceScore}");
        }

        private static void getKeyPhrases(String mensaje, TextAnalyticsClient client) {
            var idioma = client.DetectLanguage(mensaje).Value.Iso6391Name;
            var keyphrases = client.ExtractKeyPhrases(mensaje, idioma);

            var lista = keyphrases.Value;
            Console.WriteLine("Frases clave de oración");
            lista.ToList().ForEach(t => Console.WriteLine($"{t}"));
        }

        private static void getEntitiesKB(String mensaje, TextAnalyticsClient client) {
            var idioma = client.DetectLanguage(mensaje).Value.Iso6391Name;
            var entities = client.RecognizeLinkedEntities(mensaje, idioma);
            Console.WriteLine("-.-.-.Entidades de BD conocida-.-.");
            entities.Value.ToList()
                .ForEach(t => {
                    Console.WriteLine($"Nombre: {t.Name}");
                    Console.WriteLine($"Matches: {t.Matches}");
                    Console.WriteLine($"Lenguaje: {t.Language}");
                    Console.WriteLine($"Id: {t.DataSourceEntityId}");
                    Console.WriteLine($"DataSource: {t.DataSource}");
                    Console.WriteLine($"Url: {t.Url}");
                    Console.WriteLine();

                }) ;
        }

        private static void getEntitiesNamed(String mensaje, TextAnalyticsClient cliente) {
            var idioma = cliente.DetectLanguage(mensaje).Value.Iso6391Name;
            var entities = cliente.RecognizeEntities(mensaje, idioma);
            Console.WriteLine("-.-.-.Entidades nombradas -.-.-.-.");
            entities.Value.ToList()
                .ForEach(t=> {
                    Console.WriteLine($"Text: {t.Text}");
                    Console.WriteLine($"Category: {t.Category}");
                    Console.WriteLine($"Subcategory: {t.SubCategory}");
                    Console.WriteLine($"Score: {t.ConfidenceScore}");
                    Console.WriteLine();
                });
        }

        private static void getSentiment(string mensaje, TextAnalyticsClient cliente)
        {
            var idioma = cliente.DetectLanguage(mensaje).Value.Iso6391Name;
            var sentiment = cliente.AnalyzeSentiment(mensaje, idioma);
            Console.WriteLine("-.-.-.-.Sentiment Análisis-.-.-.-.-.");
           
            Console.WriteLine($"Sentiment: {sentiment.Value.Sentiment}");
            Console.WriteLine("-.-.-.Confidence Scores-.-.-.-.");
            Console.WriteLine($"positive: {sentiment.Value.ConfidenceScores.Positive}");
            Console.WriteLine($"neutral: {sentiment.Value.ConfidenceScores.Neutral}");
            Console.WriteLine($"negative: {sentiment.Value.ConfidenceScores.Positive}");
            Console.WriteLine("-.-.-.Sentencias.-.-.-.--.");
            sentiment.Value.Sentences.ToList()
                .ForEach(t=> {
                    Console.WriteLine($"sentiment: {t.Sentiment}");
                    Console.WriteLine($"Text: {t.Text}");
                    Console.WriteLine("-.-.Confidence Scores-.-.-.");
                    Console.WriteLine($"positive: {t.ConfidenceScores.Positive}");
                    Console.WriteLine($"neutral: {t.ConfidenceScores.Neutral}");
                    Console.WriteLine($"Negative: {t.ConfidenceScores.Negative}");
                });

            Console.WriteLine();
        }
    }
}
