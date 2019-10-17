using System;
using System.Collections.Generic;
using System.Text;

namespace BobManager.Dto.DtoResults
{
    public class CollectionResultDto<T> : ResultDto
    {
        public List<T> Data { get; set; }
        public int Count { get; set; }
    }
}
