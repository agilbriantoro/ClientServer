﻿using API.Contexts;
using API.Models;

namespace API.Repositories.Data
{
    public class EducationRepository : GeneralRepositories<int, Education>
    {
        private readonly MyContext context;
        public EducationRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
    }
    
}
