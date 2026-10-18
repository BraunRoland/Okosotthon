using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    internal class Termosztat : OkosEszkoz,IIdozitheto,IStatisztika
    {
        private double jelenlegiHomerseklet;
        private double celHomerseklet;
        private int idozitoPerc;

        public Termosztat(string azonosito, string nev, double celHomerseklet) : base(azonosito, nev)
        {
            this.JelenlegiHomerseklet = 21.0;
            this.CelHomerseklet = celHomerseklet;
            this.idozitoPerc = 0;
        }

        public double JelenlegiHomerseklet { get; private set; }
        public double CelHomerseklet { get; private set; }
        public int IdozitoPerc { get; set; }

        public override string AllapotJelentes()
        {
            return $"Jelenlegi hőmérséklet: {this.JelenlegiHomerseklet}, Cél hőmérséklet: {this.CelHomerseklet}";
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
           if (parancs.StartsWith("BEALLIT_HOMERSEKLET:"))
            {
                string[] reszek = parancs.Split(":");
                double ujHomerskelet = double.Parse(reszek[1]);
                this.JelenlegiHomerseklet = ujHomerskelet;
            }
        }

        protected override bool OnTesztFuttatasa()
        {
            if (CelHomerseklet > 5 && CelHomerseklet <35)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void GyariBeallitasokVisszaallitasa()
        {
            base.GyariBeallitasokVisszaallitasa();
            this.JelenlegiHomerseklet = 21.0;
            idozitoPerc = 0;
        }

        public string StatisztikatKeszit()
        {
            return $"Jelenlegi hőmérséklet: {this.JelenlegiHomerseklet}, Cél hőmérséklet: {this.CelHomerseklet}, fűtésből hátramaradt perc: {this.IdozitoPerc}";
        }

        public void IdozitestBeallit(int perc)
        {
            this.IdozitoPerc = perc;
        }

        public int getMaradtIdo()
        {
            return IdozitoPerc;
        }
    }
}
