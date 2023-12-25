using FluentValidation.Results;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace pmesp.Application.Services;

// Classe destinada ao retorno padronizado das services
public class ResultService
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public ICollection<ErrorValidation> Errors { get; set; }
    public int TotalRecords { get; set; }

    public static ResultService RequestError(string message, ValidationResult validationResult)
    {
        return new ResultService
        {
            Success = false,
            Message = message,
            Errors = validationResult.
                Errors.
                Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()

        };
    }

    public static ResultService<T> RequestError<T>(string message, ValidationResult validationResult)
    {
        return new ResultService<T>
        {
            Success = false,
            Message = message,
            Errors = validationResult.
                Errors.
                Select(x => new ErrorValidation { Field = x.PropertyName, Message = x.ErrorMessage }).ToList()

        };
    }

    public static ResultService Fail(string message) => new ResultService { Success = false, Message = message };
    public static ResultService<T> Fail<T>(string message) => new ResultService<T> { Success = false, Message = message };

    public static ResultService Ok(string message) => new ResultService { Success = true, Message = message };
    public static ResultService<T> Ok<T>(T data, string message) => new ResultService<T> { Success = true, Data = data, Message = message}; 
    public static ResultService<T> Ok<T>(T data, string message, int totalRecord) => new ResultService<T> { Success = true, Data = data, Message = message, TotalRecords = totalRecord};
}

public class ResultService<T> : ResultService
{
    public T Data { get; set; }
}
