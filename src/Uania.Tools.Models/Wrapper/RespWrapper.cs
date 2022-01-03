namespace Uania.Tools.Models.Wrapper
{
    public class RespWrapper
    {
        public int Code { get; set; }

        public string? Message { get; set; }

        public RespWrapper()
        {

        }
        public RespWrapper(int code, string message)
        {
            (Code, Message) = (code, message);
        }
    }

    public class RespWrapper<T> : RespWrapper where T : class
    {
        public RespWrapper()
        {

        }
        public RespWrapper(int code, string message) : base(code, message)
        {
            
        }
        public T? Data { get; set; }
    }

    public class RespListWrapper<T> : RespWrapper where T : class
    {
        public List<T>? Data { get; set; }
    }

    public class RespPaginationWrapper<T> : RespListWrapper<T> where T : class
    {
        public Common.Paginatioin? Paginatioin { get; set; }
    }
}