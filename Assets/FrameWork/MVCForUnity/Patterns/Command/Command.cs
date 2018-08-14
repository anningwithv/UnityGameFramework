
namespace ZW.MVCForUnity
{
    /// <summary>
    /// Base for command
    /// </summary>
    public class Command : ICommand
    {
        public virtual void Execute(IEventMessage eventNode)
        {

        }
    }
}
