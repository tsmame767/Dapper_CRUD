using Dapper;
using learndapper.Context;
using learndapper.Interface;
using learndapper.Model;
using System.Data;

namespace learndapper.Repo
{
    public class DapperRepo:IDapperService
    {
        private readonly DapperDbContext context;
        public DapperRepo(DapperDbContext _context) 
        {
            this.context = _context;  
        }
        public async Task<List<Employee>> GetAll()
        {
            var query = "SELECT * FROM Employee";
            using(var connect = this.context.CreateConnection())
            {
                var emplist = await connect.QueryAsync<Employee>(query);
                return emplist.ToList();
            }
        }

        public async Task<Employee> Getbyid(int Id)
        {
            var query = "SELECT * FROM Employee where id=@Id";
            using (var connect = this.context.CreateConnection())
            {
                var emplist = await connect.QueryFirstOrDefaultAsync<Employee>(query, new {Id});
                return emplist;
            }
        }

        

        public async Task<string> Remove(int Id)
        {
            string response = string.Empty;
            var query = "delete from employee where id=@Id";
            using (var connect = this.context.CreateConnection())
            {
                await connect.ExecuteAsync(query, new { Id });
                response = "pass";
            }
            return response;
        }

        public async Task<string> Create(Employee emp)
        {  
            string response = string.Empty;
            var query = "insert into employee(fname,salary) values(@fName,@Salary)";

            var parameters = new DynamicParameters();
            parameters.Add("fname", emp.fName, DbType.String);
            parameters.Add("salary", emp.Salary, DbType.Int32);

            using (var connect = this.context.CreateConnection())
            {
                await connect.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }

        public async Task<string> Update(Employee emp, int Id)
        {
            string response = string.Empty;
            var query = "update employee set fname=@fName, salary=@Salary where id=@Id";


            var parameters = new DynamicParameters();
            parameters.Add("id", Id, DbType.Int32);
            parameters.Add("fname", emp.fName, DbType.String);
            parameters.Add("salary", emp.Salary, DbType.Int32);

            using (var connect = this.context.CreateConnection())
            {
                await connect.ExecuteAsync(query, parameters);
                response = "pass";
            }
            return response;
        }
    }
}
