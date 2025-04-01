namespace APB.AccessControl.Domain.Primitives
{
    public enum ActionType
    {
        None = 0,
        SendNotification,
        SendEmail,
        SendSms,
        SendPush,
        SendHttpRequest,
        ExecuteScript,
        SendMQTTRequest

    }
}
