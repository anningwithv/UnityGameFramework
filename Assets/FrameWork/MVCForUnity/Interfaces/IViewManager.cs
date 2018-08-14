
namespace ZW.MVCForUnity
{
    /// <summary>
    /// Interface for view
    /// </summary>
    public interface IViewManager
    {
        void RegisterMediator(IMediator mediator);
        IMediator GetMediator(string mediatorName);
        void UnregisterMediator(string mediatorName);
    }
}
