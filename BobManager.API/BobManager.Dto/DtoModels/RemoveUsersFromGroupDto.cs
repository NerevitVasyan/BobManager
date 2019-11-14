using System;
using System.Collections.Generic;
using System.Text;

namespace BobManager.Dto.DtoModels
{
    public class RemoveUsersFromGroupDto
    {
        public int ID { get; set; }
        public List<string> Users { get; set; }
    }
}
