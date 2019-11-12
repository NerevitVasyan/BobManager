using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BobManager.DataAccess.Interfaces
{
    public interface ITypeInitializer 
    {
        Task Init(DbContext context);
    }
}
