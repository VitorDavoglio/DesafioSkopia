namespace TaskManager.Utils
{
    public class ApiNotification<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public IEnumerable<string> Notifications { get; set; } = Array.Empty<string>();
    }
}
