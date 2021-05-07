using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProvaPratica7Mag.GestioneSpese.Handlers;

namespace ProvaPratica7Mag.GestioneSpese
{
    enum Category
    {
        Travel,
        Accomodation,
        Food,
        Other
    }

    enum ApprovalLevel
    {
        Manager,
        OperationalManager,
        CEO,
        None
    }
    class Expense
    {
        public DateTime Date { get; }
        public Category Category { get; }
        public string Description { get; }
        public decimal Amount { get; }
        public bool ApprovalStatus { get; }
        public ApprovalLevel ApprovalLevel { get; }
        public int Refund { get; }

        public Expense(DateTime date, Category category, string descrition, decimal amount,
            bool approvalStatus, ApprovalLevel approvalLevel)
        {
            Date = date;
            Category = category;
            Description = descrition;
            Amount = amount;
            ApprovalStatus = approvalStatus;
            ApprovalLevel = approvalLevel;
        }

        // metodo che crea una spesa a partire da una riga del file
        // -- analizza il contenuto della riga
        // -- definisce approval level sulla base dell'importo
        // -- definisce approval status sulla base di approval level
        // -- restituisce una Expense
        public static Expense CreateExpenseFromFile(string line)
        {

            // manipolazione della riga e sua analisi
            string[] values = line.Split(";");

            DateTime date = new DateTime(2020, 02, 02); // valore arbitrario
            if (DateTime.TryParse(values[0], out DateTime d))
                date = d;

            Category category = Category.Other; // valore arbitrario
            if (Category.TryParse(values[1], out Category c))
                category = c;

            string description = values[2];

            decimal amount = 0; // valore arbitrario
            if (decimal.TryParse(values[3], out decimal a))
                amount = a;

            var manager = SetExpenseChain(); // primo elemento della catena

            ApprovalLevel approvalLevel = manager.Handle(amount);

            bool approvalStatus = false;

            if (approvalLevel != ApprovalLevel.None)
                approvalStatus = true;

            // creazione di una Expense
            return new Expense(date, category, description, amount, approvalStatus, approvalLevel);
        }

        // metodo per definire la catena
        public static AbstractHandler SetExpenseChain()
        {
            // inizializzazione di un handler
            var manager = new ManagerHandler();
            var operationalManager = new OperationalManager();
            var ceo = new CeoHandler();

            manager.SetNext(operationalManager).SetNext(ceo);

            return manager;
        }

        public string Details(bool approved)
        {
            if (approved)
                return $"{Date};{Category};{Description};APPROVED;{ApprovalLevel};{Refund}";
            else
                return $"{Date};{Category};{Description};REJECTED;-;-";
        }
    }
}
