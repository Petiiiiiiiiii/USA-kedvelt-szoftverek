using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Szoftverek
{
    class Szoftver
    {
        public double burttoAr() 
        {
            double szazalek = 1 + (Adokulcs / 100);

            return NettoArUSD * szazalek;
        }

        public int Azonosito { get; set; }
        public string Nev { get; set; }
        public string LicencTipus { get; set; }
        public string OpKompabilitasString { get; set; }
        public string OpKompabilitas1 { get; set; }
        public string OpKompabilitas2 { get; set; }
        public string Kategoria { get; set; }
        public double Ertekeles { get; set; }
        public double NettoArUSD { get; set; }
        public int Adokulcs { get; set; }

        public Szoftver(string sor)
        {
            var s = sor.Split('|');
            this.Azonosito = int.Parse(s[0]);
            this.Nev = s[1];
            this.LicencTipus = s[2];
            this.OpKompabilitasString = s[3];
            if (OpKompabilitasString.Split(',').Length == 2) 
            {
                var s2 = OpKompabilitasString.Split(',');
                this.OpKompabilitas1 = s2[0];
                this.OpKompabilitas2 = s2[1];
            }
            else
                this.OpKompabilitas1 = s[3];
            this.Kategoria = s[4];
            this.Ertekeles = double.Parse(s[5].Replace(',','.'));
            this.NettoArUSD = double.Parse(s[6].Replace(',','.'));
            this.Adokulcs = int.Parse(s[7]);
        }

        public override string ToString()
        {
            return $"\tazonosító: {this.Azonosito} \n\tnév és verziószám: {this.Nev} \n\tlicenc típus: {this.LicencTipus} \n\toperációs rendszerek: {this.OpKompabilitasString} \n\tkategória: {this.Kategoria} \n\tfelhasználói értékelés: {this.Ertekeles} \n\tnettó ár: {this.NettoArUSD} \n\tadókulcs: {this.Adokulcs}% \n";
        }
    }
}
