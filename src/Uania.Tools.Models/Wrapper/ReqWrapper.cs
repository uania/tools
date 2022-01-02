namespace Uania.Tools.Models.Wrapper
{
    public class ReqWrapper
    {

    }

    public class ReqWapper<T> : ReqWrapper where T : class
    {
        public T? Params { get; set; }
    }

    public class ReqPageWrapper : ReqWrapper
    {
        public Common.Paginatioin? Paginatioin { get; set; }

    }

    public class ReqPageWapper<T> : ReqPageWrapper where T : class
    {
        public T? Params { get; set; }
    }
}