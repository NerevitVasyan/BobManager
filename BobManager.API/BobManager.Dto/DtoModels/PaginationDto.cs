using BobManager.Dto.DtoResults;
using System.Collections.Generic;

namespace BobManager.Dto.DtoModels
{
    public class PaginationDto<T> : ResultDto
    {
        public ICollection<T> PaginatedList { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}