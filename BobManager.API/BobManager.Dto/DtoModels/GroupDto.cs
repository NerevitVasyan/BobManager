﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BobManager.Dto.DtoModels
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IDictionary<string, int> Users { get; set; } // user, role
    }
}
