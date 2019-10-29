using System;
using System.Collections.Generic;
using System.Text;

namespace BobManager.Dto.DtoResults
{
    public class ErrorResultDto : ResultDto
    {
        public uint ErrorID { get; set; }
    }

    public class ErrorResultDto<T> : ErrorResultDto 
    {
        public T AddtionalInfo { get; set; }
    }
}
