﻿using API.Contexts;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Repositories.Data
{
    public class UniversityRepository : GeneralRepositories<int, University>
    {
        private readonly MyContext context;
        public UniversityRepository(MyContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<University>> GetUniversityByName(string name)
        {
            return await context.Universities.Where(u => u.Name == name).ToListAsync();
        }
    }
}
