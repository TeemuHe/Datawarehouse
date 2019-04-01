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
                    //case: "1":
                    //    msg = "ok";
                    //    break;
                    case "1":
                        uiModels.CreateBank();
                        break;
                    case "3":
                        uiModels.DeleteBank(8);
                        msg = "Pankki poistettu";
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
                "\n[6] Hae pankin asiakkaat\n[7] Päivitä asiakastiedot\n[8] Poista asiakas tiedot\n[9] Poista asiakkaan tili\n[10] Hae asiakkaan tilin tiedot" +
                "\n[11] Luo asiakkaalle tilitapahtuma\n[12] Hae asiakkaan tilitapahtumia\n[X] Sammuta sovellus");
            Console.Write("Valitse mitä tehdään: ");
            string choise = Console.ReadLine();
            return choise;
        }
    }
}
