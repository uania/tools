namespace Uania.Tools.Models.Wrapper
{
    public class RespWrapper
    {
        public int Code { get; set; }

        public string? Message { get; set; }
    }

    public class ResqWrapper<T> : RespWrapper where T : class
    {
        public T? Data { get; set; }
    }
}