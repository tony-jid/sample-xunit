using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_lib
{
    public class PersonDataAccess
    {
        public List<Person> People { get; set; }

        public PersonDataAccess()
        {
            People = new List<Person>();
        }

        public PersonDataAccess(List<Person> people)
        {
            People = people;
        }

        public Person AddPerson(Person p)
        {
            if (p == null) throw new ArgumentNullException($"{nameof(p)} cannot be null.");

            this.People.Add(p);

            return p;
        }

        public List<string> ConvertNamesToListStringCSV()
        {
            if (!People.Any()) throw new NullReferenceException($"{nameof(People)} cannot be null/empty.");

            List<string> names = new List<string>();
            foreach (var p in People)
            {
                names.Add($"{p.FirstName},{p.LastName}");
            }

            return names;
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
