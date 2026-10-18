using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    internal class OkosZar : OkosEszkoz, IHangjelzo, IStatisztika
    {
        private bool zartE;
        private string pinKod;
        private int nyitasok;

        public OkosZar(string azonosito, string nev) : base(azonosito, nev)
        {
            this.ZartE = true;
            this.Nyitasok = 0;
        }

        public bool ZartE { get; private set; }
        public int Nyitasok { get; private set; }

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
                    this.Nyitasok++;
                    Csipog(400);
                }
                else
                {
                    VeszjelzesInditasa();
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
            this.pinKod = "0000";
            this.Nyitasok = 0;
        }

        public string StatisztikatKeszit()
        {
            return$"Nyitások száma: {this.Nyitasok}";
        }

        public void Csipog(int hosszu)
        {
            Console.WriteLine($"A zár csipogott {hosszu}ms-ig");
        }

        public void VeszjelzesInditasa()
        {
            Console.WriteLine("A zár vészjelzést indított rossz PIN kód miatt!");
        }
    }
}
