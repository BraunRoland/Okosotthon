using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    internal class OkosZar : OkosEszkoz
    {
        private bool zartE;
        private string pinKod;

        public OkosZar(string azonosito, string nev) : base(azonosito, nev)
        {
            this.ZartE = true;
        }

        public bool ZartE { get; private set; }

        public override string AllapotJelentes()
        {
            if (this.ZartE)
            {
                return "NYITVA";
            }
            else
            {
                return "ZÁRVA";
            }
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs.StartsWith("NYITAS:"))
            {
                string[] reszek = parancs.Split(":");
                if (reszek[1] == this.pinKod)
                {
                    this.ZartE = false;
                }
            }
            if(parancs == "ZARAS")
            {
                this.zartE = true;
            }
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            base.GyariBeallitasokVisszaallitasa();
            this.ZartE = true;
        }
    }
}
