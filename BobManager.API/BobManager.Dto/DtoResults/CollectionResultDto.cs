using System;
using System.Collections.Generic;
using System.Text;

namespace BobManager.Dto.DtoResults
{
    public class CollectionResultDto<T> : ResultDto
    {
        public ICollection<T> Data { get; set; }
        public int Count { get; set; }
    }
}
