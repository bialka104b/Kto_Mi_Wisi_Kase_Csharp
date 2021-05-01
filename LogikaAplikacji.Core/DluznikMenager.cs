using System;
using System.Collections.Generic;
using System.Text;

namespace KtoMiWisiKase.Core
{
    public class DluznikMenager //Borrower Menager
    {
        private List<Dluznik> Dluznicy { get; set; } = new List<Dluznik>();
        public DluznikMenager()
        {
            Dluznicy = new List<Dluznik>(); //inicjalizacja listy
        }
        public void DodajDluznika(string imie, decimal kwota)
        {
            var dluznik = new Dluznik
            {
                Imie = imie,
                Kwota = kwota
            };
            Dluznicy.Add(dluznik);
        }

        public void UsunDluznika(string imie, decimal kwota) //tu pasuje jeszcze zrobić żeby część kwoty zwracać
        {

            foreach (var dluznik in Dluznicy)
            {
                if (dluznik.Imie == imie) //sprawdz czy jego imie jest takie samo jak podane imie
                {
                    Dluznicy.Remove(dluznik);
                    return;
                }
            }
            
        }

        public List<string> ListaDluznikow()
        {
            var dluznicyStrings = new List<string>();
            var indekser = 1; // liczba porządkowa która będzie wyświetlana
            foreach (var dluznik in Dluznicy) //dla każdego dłuznika generuj stringa
            {
                var dluznikString = indekser + ". " + dluznik.Imie + " - " + dluznik.Kwota + " zł.";//1. Imie - kwota zł
                indekser++;

                dluznicyStrings.Add(dluznikString);
            } 
            return dluznicyStrings; // zwróć liste
        }

    }
}
