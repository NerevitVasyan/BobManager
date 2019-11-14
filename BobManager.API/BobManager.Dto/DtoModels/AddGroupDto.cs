using System;
using System.Collections.Generic;
using System.Text;

namespace BobManager.Dto.DtoModels
{
    public class AddGroupDto
    {
        public string Name { get; set; }
        public Dictionary<string, int> Users { get; set; } // User id, role id
    }
}
