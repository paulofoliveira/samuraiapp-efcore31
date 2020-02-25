using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        private static SamuraiContext context = new SamuraiContext();
        private static void Main(string[] args)
        {
            context.Database.EnsureCreated();
            GetSamurais("Antes de adicionar:");
            AddSamurai();
            GetSamurais("Depois de adicionar:");
            Console.Write("Pressione qualquer tecla para finalizar...");
            Console.ReadKey();
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Paulo" };
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = context.Samurais.ToList();

            Console.WriteLine($"{text}: Quantidade de samurais é {samurais.Count}");

            foreach (var samurai in samurais)            
                Console.WriteLine(samurai.Name);
            
        }

    }
}
