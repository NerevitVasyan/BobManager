using System;
using System.Collections.Generic;
using System.Text;

namespace BobManager.Dto.DtoModels
{
    public class AddUsersToGroupDto
    {
        public int ID { get; set; }
        public Dictionary<string, int> Users { get; set; } // User id, role id
    }
}
