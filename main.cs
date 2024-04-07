//Dependency injection example
public interface IClient
{
    void Send(string message);
}

public class EmailClient : IClient
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending Email: {message}");
    }
}

public class SmsClient : IClient
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}

public class NotificationService
{
    private IClient _client;

    public NotificationService(IClient client)
    {
        _client = client;
    }

    public void Notify(string message)
    {
        _client.Send(message);
    }
}
//Inject the dependency
class Program
{
    static void Main(string[] args)
    {
        IClient emailClient = new EmailClient();
        NotificationService emailService = new NotificationService(emailClient);
        emailService.Notify("Hello via Email!");

        IClient smsClient = new SmsClient();
        NotificationService smsService = new NotificationService(smsClient);
        smsService.Notify("Hello via SMS!");
    }
}

