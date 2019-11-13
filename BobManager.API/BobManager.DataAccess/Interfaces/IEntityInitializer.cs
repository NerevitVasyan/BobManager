using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.DataAccess.Interfaces
{
    public interface IEntityInitializer
    {
        Task SeedData();
        void AddConfig(ITypeInitializer typeInitializer);
    }
}
