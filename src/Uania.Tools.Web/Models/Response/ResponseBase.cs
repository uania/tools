namespace Uania.Tools.Web.Models.Response
{
    public class ResponseBase
    {
        public ResponseCodeEnum Code { get; set; }

        public string? Message { get; set; }
    }

    public class ResponseBase<T> : ResponseBase
    {
        public T? Data { get; set; }
    }
}