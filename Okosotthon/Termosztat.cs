using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    internal class Termosztat : OkosEszkoz
    {
        private double jelenlegiHomerseklet;
        private double celHomerseklet;

        public Termosztat(string azonosito, string nev, double celHomerseklet) : base(azonosito, nev)
        {
            this.JelenlegiHomerseklet = 21.0;
            this.CelHomerseklet = celHomerseklet;
        }

        public double JelenlegiHomerseklet { get; private set; }
        public double CelHomerseklet { get; private set; }

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
        }
    }
}
