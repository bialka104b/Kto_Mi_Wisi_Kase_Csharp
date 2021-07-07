using System;
using System.Collections.Generic;
using System.Text;

namespace KtoMiWisiKase.Core
{
    class Dluznik //Borrower
    {
        public string Imie { get; set; } //Name
        public decimal Kwota { get; set; }//kwota z liczbami po przecinku więc decimal
        public string Date { get; set; }

        public override string ToString()
        {
            return Imie + "; " + Kwota.ToString() + "; " + Date;
        }
    }
}
