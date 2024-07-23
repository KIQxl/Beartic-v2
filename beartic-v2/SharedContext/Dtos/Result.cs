using Flunt.Notifications;

namespace Beartic.Shared.Dtos
{
    public class Result<T>
    {
        public Result(int status, string message, T data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public Result(int status, string message, IEnumerable<Notification>? notifications = null)
        {
            Status = status;
            Message = message;
            Data = default;

            if (notifications != null)
                foreach (Notification notification in notifications)
                    Errors.Add(notification.Message);
        }

        public int Status { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public T? Data { get; set; }
        public bool Success => Status >= 200 && Status <= 299;
    }
}
