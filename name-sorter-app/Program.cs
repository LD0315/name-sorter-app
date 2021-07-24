using System;
using System.IO;

namespace name_sorter_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! " + args.Length);

            if (args.Length != 1)
            {
               throw new Exception("Usage: name-sorter-app fileName");
            }

            var contents = File.ReadAllText(args[0]);
            var names = contents.Split('\n');
            var people = new Person[names.Length];
            var added = 0;
            foreach (var name in names)
            {
                var subnames = name.Split(' ');
                Person person;
                if (subnames.Length == 1)
                {
                    person = new Person
                    {
                        LastName = subnames[0],
                        FirstName = "",
                        MiddleName = ""
                    };
                }
                else if (subnames.Length == 2)
                {
                    person = new Person
                    {
                        FirstName = subnames[0],
                        LastName = subnames[1],
                        MiddleName = ""
                    };
                }
                else
                {
                    var middlenames = "";

                    var first = subnames[0];
                    var last = subnames[subnames.Length - 1];
                    var limit = subnames.Length - 2;
                    for (var i = 1; i < limit; i++)
                    {
                        middlenames += subnames[i];
                        if (i < limit - 1)
                        {
                            middlenames += " ";
                        }
                    }
                    person = new Person
                    {
                        FirstName = first,
                        LastName = last,
                        MiddleName = middlenames
                    };
                }
                people[added++] = person;
            }


            Person.SortPeople(people);

            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
