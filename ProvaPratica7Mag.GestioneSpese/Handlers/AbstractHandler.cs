using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaPratica7Mag.GestioneSpese.Handlers
{
    abstract class AbstractHandler : IHandler
    {
        // ogni handler ha un handler che lo succede
        private IHandler _nextHandler;

        // metodo per settare l'handler successivo al corrente
        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;

            return handler;
        }

        // si definisce virutal per consentire implementazione ad handler specifici
        public virtual ApprovalLevel Handle(decimal amount)
        {
            if (this._nextHandler != null)
                // demandiamo la richiesta all'elemento successivo 
                return this._nextHandler.Handle(amount);
            else
                return ApprovalLevel.None;
        }
    }
}
