using System.Collections;
using UnityEngine;

public class Won : State
{
    public Won(RoundSystem roundSystem) : base(roundSystem) { }

    public override IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
    }
}
