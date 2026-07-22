namespace EMSWebApp.Services
{
    public class EventNotificationService
    {
        public event Action<Guid>? OnRegistrationAdded;

        public void NotifyRegistrationChange(Guid eventId)
        {
            OnRegistrationAdded?.Invoke(eventId);
        }
    }
}
