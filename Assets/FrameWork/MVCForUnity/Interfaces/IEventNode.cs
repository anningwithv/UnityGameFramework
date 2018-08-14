namespace ZW.MVCForUnity
{
    /// <summary>
    /// Interface for eventnode
    /// </summary>
    public interface IEventNode:IEventTrigger, IEventObserver
    {
        string[] ListInterestEvent();

        void OnRegister();

        void OnRemove();

    }
}
