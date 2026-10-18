using System;
using System.Collections.Generic;
using System.Text;

namespace Okosotthon
{
    internal class OkosOtthonKozpont
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
