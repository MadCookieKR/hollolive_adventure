using UniRx;
using UnityEngine;

public interface Command
{
    public class Attack : Command {
        public Character other;

        public Attack(Character other)
        {
            this.other = other;
        }
    }

    public class Run : Command { }
    public class ShowVMonBag : Command { }
    public class ShowBag : Command { }
}

public abstract class InputSource : MonoBehaviour
{
    public Subject<Command> command = new Subject<Command>();
}
