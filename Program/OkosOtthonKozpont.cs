using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    public class OkosOtthonKozpont
    {
        private readonly List<OkosEszkoz> eszkozok;

        public OkosOtthonKozpont()
        {
            this.eszkozok = new List<OkosEszkoz>();
        }

        public void Eszkozhozzadasa(OkosEszkoz eszkoz)
        {
            this.eszkozok.Add(eszkoz);
        }

        public void OsszesCsatlakoztatasa()
        {
            foreach(OkosEszkoz eszkoz in eszkozok)
            {
                eszkoz.Csatlakozas();
            }
        }

        public void Extrak()
        {
            foreach(OkosEszkoz eszkoz in eszkozok)
            {
                if (eszkoz is IHangjelzo h)
                {
                    h.Csipog(400);
                    h.VeszjelzesInditasa();
                }
                if (eszkoz is IStatisztika s)
                {
                    s.StatisztikatKeszit();
                }
                if(eszkoz is IIdozitheto i)
                {
                    i.IdozitestBeallit(5);
                    i.getMaradtIdo();
                }
            }
        }

        public int RendszerDiagnosztikaFuttatasa()
        {
            int sikeresTest = 0;
            foreach (OkosEszkoz eszkoz in eszkozok)
            {
                if(eszkoz.DiagnosztikaFuttatasa())
                {
                    sikeresTest++;
                }
            }
            return sikeresTest;
        }
    }
}
