using System;
using PersonExampleDB.Models;
using PersonExampleDB.Repositories;

namespace PersonExampleDB
{
    class Program
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();
        static void Main(string[] args)
        {
            //Testing database Read
            //CreatePerson();     used and added person once
            ReadByCity();
            for (int i = 0; i < 100; i++)
            {
                ReadById(i);
            }
        }

        static void CreatePerson()
        {
            Person person = new Person();
            person.FirstName = "Teemu";
            person.LastName = "Heikkinen";
            person.City = "Suonenjoki";
            person.ShoeSize = 42;

            _personRepository.Create(person);
        }

        static void ReadByCity()
        {
            var persons = _personRepository.ReadByCity("Suonenjoki");
            
            foreach (var p in persons)
            {
                Console.WriteLine($"{p.Id} {p.FirstName} {p.LastName} {p.City}");
            }

            Console.WriteLine("-----------------------------------");
        }

        static void ReadById(long id)
        {
            var person = _personRepository.ReadById(id);

            if (person == null)
                Console.WriteLine($"Asiakasta numerolla {id} ei löydy!");
            else
                Console.WriteLine($"{person.Id} {person.FirstName} {person.LastName} {person.City}");
        }
    }
}
