# TMPS-LAB-3
# Design Patterns Implementation in Notification System

This project demonstrates the implementation of several design patterns in a simple notification system written in C#. The following design patterns have been utilized to create a flexible and maintainable notification system:

## Adapter Pattern
The Adapter pattern is used to adapt the existing `SMSNotification` class to the `INotification` interface. This adaptation is achieved through the `SMSNotificationAdapter` class, which allows the system to send SMS notifications by using the `INotification` interface.
```csharp
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
```

## Decorator Pattern
The Decorator pattern is utilized to add additional behavior to the notification system dynamically. The `NotificationDecorator` and `UrgentNotificationDecorator` classes provide the capability to mark a notification as urgent before sending it. The `UrgentNotificationDecorator` specifically modifies the behavior of the Send method to prepend "Urgent!" to the message before sending it.
```csharp
public abstract class NotificationDecorator : INotification
{
    // ... constructor and other methods

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
```

## Facade Pattern
The Facade pattern provides a simplified interface to the complex notification system, allowing users to interact with the system without needing to understand its underlying complexity. The `NotificationFacade` class acts as a facade to the notification system, providing a straightforward `SendNotification` method to send notifications without exposing the intricacies of the underlying notification mechanism.
```csharp
public class NotificationFacade
{
    // ... constructor and other methods

    public void SendNotification(string message)
    {
        _notification.Send(message);
    }
}
```

## Proxy Pattern
The Proxy pattern is used to control access to the notification system. The `NotificationProxy` class acts as a proxy to the `NotificationFacade`, enabling the implementation of access control logic before sending a notification. This can be utilized for adding security checks or logging before the actual operation is performed.
```csharp
public class NotificationProxy : INotification
{
    // ... constructor and other methods

    public void Send(string message)
    {
        // Implement some access control logic
        Console.WriteLine("Access control logic for sending notifications.");
        _notificationFacade.SendNotification(message);
    }
}
```

## Usage
To use this notification system, follow these steps:

1. Set up the required notification services such as email and SMS.
2. Use the `NotificationFacade` or `NotificationProxy` to send notifications in your application.
3. Customize the decorators to add more functionalities to your notifications as needed.
