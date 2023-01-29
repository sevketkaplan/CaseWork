using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ResultType
{
    public class Result<T> : IResult<T>
    {
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public Paginate Paginate { get; set; }
        public long RecordsTotal { get; set; } = 0;
        public long RecordsFiltered { get; set; } = 0;


        public bool? IsLastPackage { get; set; }
        public ResultTypeEnum ResultType { get; set; }
        public string Html { get; set; }

        public string[] MessagesParameters { get; set; }

        public Result()
        {
            Data = default;
        }

        public Result(bool IsSuccess, T Data, string Message, params string[] parameters)
        {
            this.IsSuccess = IsSuccess;
            this.Data = Data;
            this.Message = string.Format(Message, parameters);
        }

        public Result(bool? IsSuccess = false, T? Data = default, string? Message = "",
            Paginate? Paginate = null, long? RecordsTotal = 0, long? RecordsFiltered = 0,
            bool? IsLastPackage = null, ResultTypeEnum? ResultType = ResultTypeEnum.None, string? Html = null,
                params string[] parameters
             )
        {
            this.IsSuccess = IsSuccess.HasValue ? IsSuccess.Value : false;
            this.Data = Data;
            this.Paginate = Paginate;
            this.RecordsTotal = RecordsTotal.HasValue ? RecordsTotal.Value : 0;
            this.RecordsFiltered = RecordsFiltered.HasValue ? RecordsFiltered.Value : 0;
            this.IsLastPackage = IsLastPackage.HasValue ? IsLastPackage.Value : false;
            this.ResultType = ResultType.HasValue ? ResultType.Value : ResultTypeEnum.None;
            this.Html = Html;
            this.Message = string.Format(Message, parameters);
        }


    }

    public enum ResultTypeEnum
    {
        None = 0,
        Information = 1,
        Success = 2,
        Warning = 3,
        Error = 4,
        Redirect = 5,
        Nothing = 404,
        NotFound = 6,
        Activation = 7,
    };

    public partial class Paginate
    {
        public long Current { get; set; }
        public long Prev { get; set; }
        public long Next { get; set; }
        public List<string> Pages { get; set; }
        public string PagesStr { get; set; }
    }
}


