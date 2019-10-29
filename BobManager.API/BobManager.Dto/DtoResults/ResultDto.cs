using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace BobManager.Dto.DtoResults
{
    public class ResultDto
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
    }
}
