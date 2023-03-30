using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class RoleRepository : GeneralRepositories<int, Role>
    {
        private readonly MyContext context;
        public RoleRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
