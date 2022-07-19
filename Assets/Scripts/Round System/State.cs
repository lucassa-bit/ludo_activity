using System.Collections;

public abstract class State
{
    protected RoundSystem RoundSystem;

    protected State(RoundSystem roundSystem)
    {
        RoundSystem = roundSystem;
    }

    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator PlayDice()
    {
        yield break;
    }
}
