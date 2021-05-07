using System;
using System.IO;

namespace ProvaPratica7Mag.GestioneSpese
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(FileManager.OpenAndReadFile("prova.txt", 
            //    @"C:\Users\ludovica.binetti\source\repos\ProvaPratica7Mag\ProvaPratica7Mag.GestioneSpese\Files\prova.txt"));

            FileSystemWatcher fsw = new FileSystemWatcher();

            // specifica del nome della directory da tenere sotto controllo
            fsw.Path = @"C:\Users\ludovica.binetti\source\repos\ProvaPratica7Mag\ProvaPratica7Mag.GestioneSpese\Files\";
            fsw.Filter = "spese.txt"; // specifica del nome e tipo di file che si è interessati a monitorare 
            fsw.NotifyFilter = NotifyFilters.FileName; // richiesta del tipo di notifiche da ricevere
            fsw.EnableRaisingEvents = true; // abilitazione delle notifiche

            // associazione del delegate all'evento
            fsw.Created += FileManager.HandleNewTextFile;

            Console.WriteLine("--- Press 'q' to close the application ---");
            while (Console.Read() != 'q') ;

        }
    }
}
