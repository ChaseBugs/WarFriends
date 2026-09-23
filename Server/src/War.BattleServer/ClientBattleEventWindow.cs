namespace War.BattleServer;

public sealed class ClientBattleEventWindow
{
    private readonly ReliableEventWindow window;
    public ClientBattleEventWindow(int capacity=64){window=new ReliableEventWindow(capacity);}
    public ClientBattleEvent Publish(string kind,ulong entityId,System.Numerics.Vector3 position)
    {
        var eventData=new ClientBattleEvent(window.Append(),kind,entityId,position);
        ClientBattleEventValidator.Validate(eventData);return eventData;
    }
    public void Acknowledge(ulong sequence)=>window.Acknowledge(sequence);
    public bool CanReplay(ulong sequence)=>window.CanReplay(sequence);
}
