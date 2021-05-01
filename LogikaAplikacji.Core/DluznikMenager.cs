using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace KtoMiWisiKase.Core
{
    public class DluznikMenager //Borrower Menager
    {
        private List<Dluznik> Dluznicy { get; set; } = new List<Dluznik>();
        private string PlikZDanymi { get; set; } = "ktoMiWisiKase.txt";
        //format:      Marta; 20
        

        public DluznikMenager() //konstruktor
        {
            Dluznicy = new List<Dluznik>(); //inicjalizacja listy
            if (!File.Exists(PlikZDanymi))
            {
                return;
            }
            var tablicaStringow = File.ReadAllLines(PlikZDanymi); //czytamy wszystkie linie pliku
            foreach (var item in tablicaStringow)
            { //rozbijamy po średniku każdy string na 2 wartości
                var imieIKwotaTablica = item.Split(';'); //zwróci nam tablice strinów znowu
                
                if(decimal.TryParse(imieIKwotaTablica[1], out var kwotaDecimal))
                {
                    DodajDluznika(imieIKwotaTablica[0], kwotaDecimal, false);
                }
            }
        }

        //MOŻNA JESZCZE ZAIPLEMENTOWAĆ ŁĄCZNĄ SUME WSZYSTKICH KWOT
        //ODEJMOWANIE KWOTY OD ISTNIEJĄCEGO DLUZNIKA
        //MOZNA TEZ ZROBIC USUWANIE PO IMIENIU I KWOCIE, SPRAWDZIĆ TUTAJ CZY KWOTA JEST MNIEJSZA, JAK JEST MNIEJSZA TO WTEDY EDYTOWAĆ
        //mOŻNA ZAPISAC DATE W KTÓREJ DLUZNIK ZOSTAŁ DODANY dATEnOW(), PO OKREŚLONEJ LICZBIE DNI DODAJE SIĘ 5% DO KWOTY
        //
        public void DodajDluznika(string imie, decimal kwota, bool flaga = true)
        {
            var dluznik = new Dluznik
            {
                Imie = imie,
                Kwota = kwota
            };
            Dluznicy.Add(dluznik);
            if (flaga) {
                File.WriteAllLines(PlikZDanymi, new List<string> { dluznik.ToString() });
            }
        }

        public void UsunDluznika(string imie, decimal kwota, bool flaga = true) //tu pasuje jeszcze zrobić żeby część kwoty zwracać
        {

            foreach (var dluznik in Dluznicy)
            {
                if (dluznik.Imie == imie) //sprawdz czy jego imie jest takie samo jak podane imie
                {
                    Dluznicy.Remove(dluznik);
                    break;
                }
            }

            if (flaga) {

                var dluznicyDoZapisu = new List<string>();
                foreach (var dluznik in Dluznicy)
                {
                    dluznicyDoZapisu.Add(dluznik.ToString());
                }

                File.Delete(PlikZDanymi);
                File.WriteAllLines(PlikZDanymi, dluznicyDoZapisu );
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
