﻿using System;
using PersonExampleDB.Models;
using PersonExampleDB.Repositories;
using PersonExampleDB.Views;

namespace PersonExampleDB
{
    class Program
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();
        static void Main(string[] args)
        {
            string userInput = null;
            UIModel uiModel = new UIModel();
            string msg = "";
            do
            {
                userInput = Choise();
                switch (userInput.ToUpper())
                {
                    case "C":
                        uiModel.CreatePerson();
                        msg = "---------------------------------";
                        break;
                    case "R":
                        uiModel.ReadById(5003);
                        msg = "---------------------------------";
                        break;
                    case "U":
                        uiModel.UpdatePerson();
                        msg = "---------------------------------";
                        break;
                    case "D":
                        uiModel.DeletePerson(5004);
                        msg = "---------------------------------";
                        break;
                    case "K":
                        uiModel.ReadByCity();
                        break;
                    case "X":
                        msg = "Lopetetaan...";
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
            Console.WriteLine("[C] Luodaan henkilö tietokantaan\n[R] Haetaan henkilö ID:n mukaan" +
                "\n[U] Päivitä henkilö\n[D] Poista henkilö tietokannasta\n[K] Hae kaupungin tiedot\n[X] Lopeta");
            Console.Write("Valitse mitä tehään: ");
            string choise = Console.ReadLine();
            return choise;
        }
    }
}
