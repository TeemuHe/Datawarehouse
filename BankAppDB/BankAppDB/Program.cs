using System;
using System.Collections.Generic;
using BankAppDB.Views;

namespace BankAppDB
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = null;
            UIModels uiModels = new UIModels();
            string msg = "";
            
            do
            {
                userInput = Choise();
                switch (userInput.ToUpper())
                {
                    case "1":
                        uiModels.CreateBank();
                        msg = "Uusi pankki luotu";
                        break;
                    case "2":
                        uiModels.UpdateBank();
                        msg = "Pankin tiedot päivitetty";
                        break;
                    case "3":
                        uiModels.DeleteBank(10);
                        msg = "Pankki poistettu";
                        break;
                    case "4":
                        uiModels.CreateCustomerAccount();
                        msg = "Asiakas ja tili luotu";
                        break;
                    case "5":
                        uiModels.ReadAccountsByBankId(7); //doesn´t print accounts
                        break;
                    case "6":
                        uiModels.ReadCustomerByBankId(6);
                        msg = "Pankin asiakkaat tulostettu";
                        break;
                    case "7":
                        uiModels.UpdateCustomer();
                        msg = "Asiakkaan tiedot päivitetty";
                        break;
                    case "8":
                        uiModels.DeleteCustomer(28);
                        msg = "Asiakas poistettu";
                        break;
                    case "9":
                        uiModels.ReadCustomerInfo(15); // doesn´t print balance
                        break;
                    case "10":
                        uiModels.AddTransaction(); //doesn´t work
                        break;
                    case "11":
                        uiModels.ReadTransactionById(15);
                        msg = "Tilitapahtumat tulostettu";
                        break;
                    case "X":
                        msg = "Sovellus suljetaan...";
                        break;
                    default:
                        msg = "Yritä uudestaan oikealla näppäimellä";
                        break;
                }
                Console.WriteLine(msg);
            } while (userInput.ToUpper() != "X");
        }
        static string Choise()
        {
            Console.WriteLine("[1] Lisää pankki\n[2] Päivitä pankki\n[3] Poista pankki\n[4] Lisää pankkiin asiakas ja tili\n[5] Hae pankin tilit" +
                "\n[6] Hae pankin asiakkaat\n[7] Päivitä asiakastiedot\n[8] Poista asiakas tiedot ja asiakkaan tilit\n[9] Hae asiakkaan tilin tiedot" +
                "\n[10] Luo asiakkaalle tilitapahtuma\n[11] Hae asiakkaan tilitapahtumia\n[X] Sammuta sovellus");
            Console.Write("Valitse mitä tehdään: ");
            string choise = Console.ReadLine();
            return choise;
        }
    }
}
