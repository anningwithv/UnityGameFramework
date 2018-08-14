
namespace ZW.MVCForUnity
{
    /// <summary>
    /// Interface for command
    /// </summary>
    public interface IEventObserver
    {
        string Name { get; set; }

        void HandleEvent(IEventMessage eventNode);
        bool CompareMethodContext(object obj);
    }
}
