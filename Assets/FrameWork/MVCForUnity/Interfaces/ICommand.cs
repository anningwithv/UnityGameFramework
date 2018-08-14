
namespace ZW.MVCForUnity
{
    /// <summary>
    /// Interface for command
    /// </summary>
    public interface ICommand
    {
        void Execute(IEventMessage eventNode);
    }
}
