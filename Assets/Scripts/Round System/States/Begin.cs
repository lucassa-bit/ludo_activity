using System.Collections;

public class Begin : State
{
    public Begin(RoundSystem roundSystem) : base(roundSystem) { }

    public override IEnumerator Start()
    {
        if (RoundSystem.playerIndex == 0)
            RoundSystem.SetState(new PlayerTurn(RoundSystem));
        else
            RoundSystem.SetState(new IATurn(RoundSystem));

        yield break;
    }
}
