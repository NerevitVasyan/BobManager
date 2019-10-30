using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace BobManager.DataAccess.Configuration
{
    public class BobManagerContextInitializer
    {
        private List<string> paths = new List<string>
        {
          //@"Mock-data\CalendarEvent.sql",
            @"Mock-data\Group.sql",
            @"Mock-data\GroupRole.sql",
          //@"Mock-data\Spending.sql",
            @"Mock-data\SpendingCategory.sql",
          //@"Mock-data\ToDo.sql",
            @"Mock-data\ToDoCategory.sql",
          //@"Mock-data\User.sql",
          //@"Mock-data\UserGroup.sql"
        };

       public void Seed(ApplicationContext context)
        {
            var buildDir = System.AppDomain.CurrentDomain.BaseDirectory;
            foreach (var path in paths)
            {
                var p = buildDir + path;
                if (File.Exists(p))
                    context.Database.ExecuteSqlCommand(ReadFromFile(buildDir + path));
            }
        }

        private RawSqlString ReadFromFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
                return sr.ReadToEnd();
        }
    }
}
