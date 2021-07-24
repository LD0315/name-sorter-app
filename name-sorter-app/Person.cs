using System;
namespace name_sorter_app
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public override string ToString()
        {
            return (MiddleName != "") ? FirstName + " " + MiddleName + " " + LastName
                                        : FirstName + " " + LastName;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                var other = obj as Person;

                return FirstName == other.FirstName &&
                    LastName == other.LastName &&
                    MiddleName == other.MiddleName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode() + MiddleName.GetHashCode();
        }

        public static int ComparePeople(Person p1, Person p2)
        {
            if (p1.Equals(p2))
            {
                return 0;
            }

            if (p1.LastName.CompareTo(p2.LastName) == 0)
            {
                if (p1.FirstName.CompareTo(p2.FirstName) == 0)
                {
                    return p1.MiddleName.CompareTo(p2.MiddleName);
                }
                else
                {
                    return p1.FirstName.CompareTo(p2.FirstName);
                }
            }
            else
            {
                return p1.LastName.CompareTo(p2.LastName);
            }

        }

        public static void SortPeople(Person [] people)
        {
            if (people.Length <= 1)
            {
                return;
            }

            for (var i = 0; i < people.Length - 1; i++)
            {
                var minI = i;
                for (var j = i + 1; j < people.Length; j++)
                {
                    if (ComparePeople(people[minI], people[j]) > 0)
                    {
                        minI = j;
                    }
                }
                Person swapped = people[minI];
                people[minI] = people[i];
                people[i] = swapped;
            }
        }


 
    }
}
