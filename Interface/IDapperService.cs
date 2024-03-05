using learndapper.Model;

namespace learndapper.Interface
{
    public interface IDapperService
    {

        Task<List<Employee>> GetAll();

        Task<Employee> Getbyid(int id);

        Task<string> Create(Employee emp);

        Task<string> Update(Employee emp,int id);

        Task<string> Remove(int id);
    }
}
