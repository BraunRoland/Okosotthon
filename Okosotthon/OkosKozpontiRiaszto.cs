using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    internal class OkosKozpontiRiaszto : OkosEszkoz, IHangjelzo, IIdozitheto, IStatisztika
    {
        int idozito;
        int riasztasok;

        public OkosKozpontiRiaszto(string azonosito, string nev) : base(azonosito, nev)
        {
            this.Idozito = 0;
            this.Riasztasok = 0;
        }

        public int Idozito { get; set; }
        public int Riasztasok { get; set; }

        public override string AllapotJelentes()
        {
            return $"Idözítő: {this.Idozito}, Riasztasok: {this.Riasztasok}";
        }

        public void Csipog(int hosszu)
        {
            Console.WriteLine("A riasztó csipogott {hosszu} ms-ig");
        }

        public int getMaradtIdo()
        {
            return Idozito;
        }

        public void IdozitestBeallit(int perc)
        {
            this.Idozito = perc;
        }

        public override void ParancsVegrehajtasa(string parancs)
        {
            if (parancs == "RIASZT")
            {
                VeszjelzesInditasa();
                this.Riasztasok++;
            }
        }

        public string StatisztikatKeszit()
        {
            return $"Idözítő: {this.Idozito}, Riasztasok: {this.Riasztasok}";
        }

        public void VeszjelzesInditasa()
        {
        Console.WriteLine("A riasztó riasztott!");
        }

        protected override bool OnTesztFuttatasa()
        {
            return true;
        }
    }
}
