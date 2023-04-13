using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Common
{
    public class Response
    {
        public Response(Code code, string message)
        {
            Code = code;
            Message = message;
        }
        public Response(string message)
        {
            Message = message;
        }
        public Response() { }
        public Code Code { get; set; } = Code.Success;
        public string Message { get; set; } = "Thành công";
        public long TotalTime { get; set; } = 0;
    }

    public class ResponseError:Response
    {
        public ResponseError(Code code, string message, IList<Dictionary<string, string>> errorDetail = null) : base(code, message)
        {
            ErrorDetail = errorDetail;
        }
        public IList<Dictionary<string, string>> ErrorDetail { get; set; }
    }

    public class ResponseObject<T>:Response
    {
        public ResponseObject(T data)
        {
            Data = data;
        }
        public ResponseObject(T data, string message)
        {
            Data = data;
            Message = message;
        }
        public ResponseObject(T data, string message,Code code)
        {
            Code = code;
            Data = data;
            Message = message;
        }
        public T Data { get; set; }
    }
    public class ResponseList<T>: Response
    {
        public ResponseList(IList<T> data)
        {
            Data = data;
        }
        public ResponseList()
        {

        }

        public IList<T> Data { get; set; }
    }

    public class ResponsePagination<T> : Response
    {
        public ResponsePagination(Pagination<T> data)
        {
            Data = data;
        }

        public Pagination<T> Data { get; set; }
    }
    public class ResponseUpdate : Response
    {
        public ResponseUpdate(Guid id)
        {
            Data = new ResponseUpdateModel { Id = id };
        }

        public ResponseUpdate(Guid id, string message) : base(message)
        {
            Data = new ResponseUpdateModel { Id = id };
        }

        public ResponseUpdate(Code code, string message, Guid id) : base(code, message)
        {
            Data = new ResponseUpdateModel { Id = id };
        }

        public ResponseUpdate()
        {
        }

        public ResponseUpdateModel Data { get; set; }
    }

    public class ResponseUpdateMulti : Response
    {
        public ResponseUpdateMulti(IList<ResponseUpdate> data)
        {
            Data = data;
        }

        public ResponseUpdateMulti()
        {
        }

        public IList<ResponseUpdate> Data { get; set; }
    }

    public class ResponseDelete : Response
    {
        public ResponseDelete(Guid id, string name)
        {
            Data = new ResponseDeleteModel { Id = id, Name = name };
        }

        public ResponseDelete(Code code, string message, Guid id, string name) : base(code, message)
        {
            Data = new ResponseDeleteModel { Id = id, Name = name };
        }

        public ResponseDelete()
        {
        }

        public ResponseDeleteModel Data { get; set; }
    }

    public class ResponseDeleteMulti : Response
    {
        public ResponseDeleteMulti(IList<ResponseDelete> data)
        {
            Data = data;
        }

        public ResponseDeleteMulti()
        {
        }

        public IList<ResponseDelete> Data { get; set; }
    }

    public class ResponseScroll<T> : Response
    {
        public ResponseScroll(Pagination<T> data,
            string scrollId, string scrollTime,
            List<string> listHighlightOtherField)
        {
            Data = data;
            ListHighlightOtherField = listHighlightOtherField;
            ScrollId = scrollId;
            ScrollTime = scrollTime;
        }

        public Pagination<T> Data { get; set; }
        public List<string> ListHighlightOtherField { get; set; }
        public string ScrollId { get; set; }
        public string ScrollTime { get; set; }
    }


    public class Pagination<T>
    {
        public Pagination()
        {
            Size = 20;
            Page = 1;
        }

        public int Page { get; set; }
        public int TotalPages { get; set; }

        public int Size { get; set; }

        public int NumberOfElements { get; set; }

        public int TotalElements { get; set; }

        public IEnumerable<T> Content { get; set; }
    }

    public enum Code
    {
        Success = 200,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        ServerError = 500
    }

    public class ResponseUpdateModel
    {
        public Guid Id { get; set; }
    }

    public class ResponseDeleteModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class BaseObject
    {
        public DateTime Modified { get; set; }
        public string Modifier { get; set; }
    }

    public class ResponseV2
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public ResponseV2() { }
        public ResponseV2(int status, string message)
        {
            this.Status = status;
            this.Message = message;
        }
    }
    public class ResponseV2<T> : ResponseV2
    {
        public T Data { get; set; }

        public ResponseV2(int status, string message, T data)
        {
            this.Status = status;
            this.Message = message;
            this.Data = data;
        }
    }

    public class ResponeDeleteModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Result { get; set; }
        public string Message { get; set; }
    }

    public class DropdownListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class PaginationList<T>
    {
        public int PageNumber { get; set; }
        public double? MaxDefault { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int DataCount { get; set; }
        public List<T> Data { get; set; }
    }
}
