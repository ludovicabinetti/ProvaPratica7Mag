using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProvaPratica7Mag.GestioneSpese.Factory;

namespace ProvaPratica7Mag.GestioneSpese
{
    class FileManager
    {

        // metodo statico per la gestione di un nuovo file all'interno di una directory
        // esso dovrà essere assegnato all'evento Created del FileWatcher,
        // pertanto ne deve rispettare la firma
        public static void HandleNewTextFile(object sender, FileSystemEventArgs e)
        {
            List<Expense> expenses = OpenAndReadFile(e.Name, e.FullPath);

            decimal amount;

            // iterazione sulle Expenses estratte per calcolare il rimborso
            foreach (Expense exp in expenses)
            {
                // se l'amount non è uguale a 0 restituisco true, altrimenti false
                bool approved = RefundFactory.CalculateRefund(exp.Category, exp.Amount) != 0;

                // scrittura su file dell'esito del rimborso
                WriteOnFile(exp.Details(approved));
            }

        }

        // metodo che apre e legge un file di testo
        public static List<Expense> OpenAndReadFile(string fileName, string filePath)
        {
            try
            {
                // stream reader per leggere il contenuto del file
                using StreamReader reader = File.OpenText(filePath);

                List<Expense> expenses = new List<Expense>(); // lista in cui appendere le Expenses create
                string line;

                // lettura riga per riga il file finché non ci sono più righe
                // per ogni riga si crea una Expense
                while ((line = reader.ReadLine()) != null && line != "")
                    expenses.Add(Expense.CreateExpenseFromFile(line));

                reader.Close(); // chiusura del flusso 

                return expenses;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        public static void WriteOnFile(string line)
        {
            try
            {
                using StreamWriter writer = File.CreateText(@"C:\Users\ludovica.binetti\source\repos\ProvaPratica7Mag\ProvaPratica7Mag.GestioneSpese\Files\spese_elaborate.txt");
                writer.WriteLine(line); // scrittura su file della stringa passata
                writer.Close(); // chiusura dello stream
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
