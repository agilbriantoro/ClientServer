using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class EmployeeRepository : GeneralRepositories<string, Employee>
    {
        private readonly MyContext context;
        public EmployeeRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
