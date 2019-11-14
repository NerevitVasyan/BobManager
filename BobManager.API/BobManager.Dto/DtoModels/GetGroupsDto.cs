using System;
using System.Collections.Generic;
using System.Text;

namespace BobManager.Dto.DtoModels
{
    public class GetGroupsDto
    {
        public int? Count { get; set; }
        public int? Offset { get; set; } // group id
    }
}
