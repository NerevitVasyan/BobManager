using System.Collections.Generic;

namespace BobManager.Dto.DtoResults
{
    public class CollectionResultDto<T> : ResultDto
    {
        public ICollection<T> Data { get; set; }
        public int Count { get; set; }
    }
}