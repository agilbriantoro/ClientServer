using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class ProfilingsRepository : GeneralRepositories<int, Profiling>
    {
        private readonly MyContext context;
        public ProfilingsRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
}
