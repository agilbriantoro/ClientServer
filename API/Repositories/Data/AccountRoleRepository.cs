using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class AccountRoleRepository : GeneralRepositories<int, AccountRole>
    {
        private readonly MyContext context;
        public AccountRoleRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
