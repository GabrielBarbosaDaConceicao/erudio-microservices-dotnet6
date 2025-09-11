using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services.Interfaces;

namespace RestWithASPNETUdemy.Services
{
    public class PersonService : IPersonService
    {
        private volatile int count;

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8;  i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

       

        public Person FindById(long id)
        {
            var person = new Person()
            {
                Id = IncrementAndGet(),
                FirstName = "Leandro",
                LastName = "Costa",
                Adress = "Uberlandia - Minas Gerais - Brasil",
                Gender = "Male",
            };
          
            return person;
        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person()
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name" + i,
                LastName = "Person LastName" + i,
                Adress = "Some Address" + i,
                Gender = "Male",
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}