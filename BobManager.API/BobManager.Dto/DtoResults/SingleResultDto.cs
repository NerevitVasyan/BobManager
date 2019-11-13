namespace BobManager.Dto.DtoResults
{
    public class SingleResultDto<T> : ResultDto
    {
        public T Data { get; set; }
    }
}
