namespace ZW.MVCForUnity
{
    public interface IEventMessage
    {
        string Name { get; }

        object Body { get; set; }
    }
}
