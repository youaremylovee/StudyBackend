namespace QuanLyVatPhamAPI.Models
{
    public class ResponseApi
    {
        public int Code { get; set; } = 200;
        public string Message { get; set; } = "Success";
        public object? Data { get; set; }
        public static ResponseApi NotFound(object? data) => new ResponseApi {Data = data, Code = 404, Message = "Not Found" };
        public static ResponseApi BadRequest(object? data) => new ResponseApi { Data = data, Code = 400, Message = "Bad Request" };
        public static ResponseApi InternalServerError(object? data) => new ResponseApi { Data = data, Code = 500, Message = "Internal Server Error" };
        public static ResponseApi Success(object? data) => new ResponseApi { Data = data, Code = 200, Message = "Success" };
    }
}
