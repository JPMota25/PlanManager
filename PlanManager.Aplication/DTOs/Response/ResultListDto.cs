using Flunt.Notifications;

namespace PlanManager.Aplication.DTOs;

public class ResultListDto<T> where T : class
{
    public static ResultListDto<T> Ok(T data)
    {
        return new ResultListDto<T>("true", data);
    }

    public static ResultListDto<T> Fail(IReadOnlyCollection<Notification> notifications)
    {
        return new ResultListDto<T>("false", notifications);
    }

    public static ResultListDto<T> Fail(Notification notification)
    {
        return new ResultListDto<T>("false", notification);
    }

    public string Success { get; private set; }
    public IList<T> Data { get; private set; } = [];
    public IReadOnlyCollection<Notification> Errors { get; private set; } = [];


    public ResultListDto(string success, T data)
    {
        Success = success;
        Data.Add(data);
    }

    public ResultListDto(string success, IReadOnlyCollection<Notification> errors)
    {
        Success = success;
        Errors = errors;
    }

    public ResultListDto(string success, Notification notification)
    {
        Success = success;
        Errors = [notification];
    }
}