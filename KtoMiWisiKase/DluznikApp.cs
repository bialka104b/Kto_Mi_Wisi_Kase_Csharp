using KtoMiWisiKase.Core;
using System;

namespace KtoMiWisiKase
{
    public class DluznikApp //DebtorApp
    {
        public DluznikMenager DluznikMenagerApp { get; set; } = new DluznikMenager();

        public void PrzedstawienieAplikacji() //IntroduceDebtorApp()
        {
            Console.WriteLine("Cześć. Witam Cie w aplikacji Kto mi wisi kase :). teraz możesz zapisać tutaj czarne owce do swojej listy");
        }

        public void DodajDluznika() { // AddBorrower()
            Console.WriteLine("Podaj imie osoby której pozyczyłeś pieniądze. Dodamy go do listy");
            var userImie = Console.ReadLine(); //uzytkownik podaje imie
            Console.WriteLine("Podaj kwotę pieniędzy, które pozyczyłeś");
            var userKwota = Console.ReadLine(); //uzytkownik podaje kwote

            var kwotaDecimal = default(decimal);
            while (!decimal.TryParse(userKwota, out kwotaDecimal))//dopóki nie udaje się sparsować
            {
                Console.WriteLine("Podano niepoprawną wartość kwoty. ");
                Console.WriteLine("Podaj ponownie kwotę");
                userKwota = Console.ReadLine(); //uzytkownik podaje kwote
            }

            if (decimal.TryParse(userKwota, out kwotaDecimal))
            {
                DluznikMenagerApp.DodajDluznika(userImie, kwotaDecimal);
            }
        }

        public void UsunDluznika() { // DeleteBorrower()
            Console.WriteLine("Podaj imie osoby która oddała Ci pieniądze.");
            var userImie = Console.ReadLine(); //uzytkownik podaje imie
            Console.WriteLine("Podaj kwotę pieniędzy, które zostały oddane");
            var userKwota = Console.ReadLine(); //uzytkownik podaje kwote

            var kwotaDecimal = default(decimal);
            while (!decimal.TryParse(userKwota, out kwotaDecimal))//dopóki nie udaje się sparsować
            {
                Console.WriteLine("Podano niepoprawną wartość kwoty. ");
                Console.WriteLine("Podaj ponownie kwotę");
                userKwota = Console.ReadLine(); //uzytkownik podaje kwote
            }

            if (decimal.TryParse(userKwota, out kwotaDecimal))
            {
                DluznikMenagerApp.UsunDluznika(userImie, kwotaDecimal);
                Console.WriteLine("udało się usunąć z listy");
            }
        }

        public void WypiszDluznikow() { //ListAllBorrowers()
            Console.WriteLine("To jest lista osób które pozyczyły pieniądze: ");
            foreach (var dluznik in DluznikMenagerApp.ListaDluznikow())
            {
                Console.WriteLine(dluznik);
            }
            
        }

        public void UserCoChceszZrobic() { //AskForAction()
        
        }
    }
}
