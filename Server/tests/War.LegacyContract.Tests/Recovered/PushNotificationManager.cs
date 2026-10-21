namespace War.LegacyContract.Tests.Recovered;

internal sealed class PushNotificationManager
{
    public static PushNotificationManager instance { get; } = new();

    public void ScheduleLocalNotifications(DatabaseAction action) => OracleTrace.Calls.Add("scheduled");
    public void RescheduleLocalNotificationsAfterError(DatabaseAction action) => OracleTrace.Calls.Add("rescheduled");
}
