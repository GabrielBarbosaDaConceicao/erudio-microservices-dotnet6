using RestWithASPNETUdemy.Model;

namespace RestWithASPNETUdemy.Services.Interfaces
{
    public interface IPersonService
    {
        List<Person> FindAll();
        Person FindById(long id);
        Person Create(Person person);
        Person Update(Person person);
        void Delete(long id);
    }
}