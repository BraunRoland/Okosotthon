using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace Okosotthon
{
    internal abstract class OkosEszkoz
    {
        private string azonosito;
        private string nev;
        private bool onlineE;
        private DateTime utolsoFrissites;

        protected OkosEszkoz(string azonosito, string nev)
        {
            this.Azonosito = azonosito;
            this.Nev = nev;
            this.OnlineE = false;
            this.UtolsoFrissites = DateTime.Now;
        }

        public void Csatlakozas()
        { 
            OnlineE = true;
        }

        public void KapcsolatBontasa()
        {
            OnlineE = false;
        }

        public bool DiagnosztikaFuttatasa()
        {
            if (!OnlineE)
            {
                return false;
            }
            return OnTesztFuttatasa();
        }

        public virtual void GyariBeallitasokVisszaallitasa()
        {
            OnlineE = false;
            UtolsoFrissites = DateTime.Now;
        }

        public abstract void ParancsVegrehajtasa(string parancs);
        public abstract string AllapotJelentes();
        protected abstract bool OnTesztFuttatasa();


        public string Azonosito { get; private set; }
        public string Nev { get; private set; }
        public bool OnlineE { get; private set; }
        public DateTime UtolsoFrissites { get; protected set; }
    }
}
