using System;

// Adapter pattern
public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Sending email notification: {message}");
    }
}

public class SMSNotification
{
    public void SendSMS(string text)
    {
        Console.WriteLine($"Sending SMS notification: {text}");
    }
}

public class SMSNotificationAdapter : INotification
{
    private readonly SMSNotification _smsNotification;

    public SMSNotificationAdapter(SMSNotification smsNotification)
    {
        _smsNotification = smsNotification;
    }

    public void Send(string message)
    {
        _smsNotification.SendSMS(message);
    }
}

// Decorator pattern
public abstract class NotificationDecorator : INotification
{
    private readonly INotification _notification;

    protected NotificationDecorator(INotification notification)
    {
        _notification = notification;
    }

    public virtual void Send(string message)
    {
        _notification.Send(message);
    }
}

public class UrgentNotificationDecorator : NotificationDecorator
{
    public UrgentNotificationDecorator(INotification notification) : base(notification)
    {
    }

    public override void Send(string message)
    {
        message = $"Urgent! {message}";
        base.Send(message);
    }
}

// Facade pattern
public class NotificationFacade
{
    private readonly INotification _notification;

    public NotificationFacade(INotification notification)
    {
        _notification = notification;
    }

    public void SendNotification(string message)
    {
        _notification.Send(message);
    }
}

// Proxy pattern
public class NotificationProxy : INotification
{
    private readonly NotificationFacade _notificationFacade;

    public NotificationProxy(INotification notification)
    {
        _notificationFacade = new NotificationFacade(notification);
    }

    public void Send(string message)
    {
        // Implement some access control logic
        Console.WriteLine("Access control logic for sending notifications.");
        _notificationFacade.SendNotification(message);
    }
}

class Program
{
    static void Main(string[] args)
    {
        var emailNotification = new EmailNotification();
        var smsNotification = new SMSNotification();
        var adaptedSmsNotification = new SMSNotificationAdapter(smsNotification);

        var basicNotification = new NotificationFacade(emailNotification);
        basicNotification.SendNotification("This is a basic notification.");

        var urgentEmailNotification = new UrgentNotificationDecorator(emailNotification);
        var veryUrgent = new UrgentNotificationDecorator(urgentEmailNotification);
        veryUrgent.Send("This is an urgent notification.");
        

        var proxyNotification = new NotificationProxy(adaptedSmsNotification);
        proxyNotification.Send("This is a proxied SMS notification.");
    }
}

