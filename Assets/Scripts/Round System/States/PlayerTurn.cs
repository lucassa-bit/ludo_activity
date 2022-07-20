using System;
using System.Collections;
using UnityEngine;

public class PlayerTurn : State
{
    public PlayerTurn(RoundSystem roundSystem) : base(roundSystem) { }

    public override IEnumerator Start()
    {
        if(RoundSystem.GetPieces().Count <= 0)
        {
            RoundSystem.SetState(new Won(RoundSystem));
        }
        else
        {
            RoundSystem.Button.SetActive(true);
        }
        yield break;
    }
}
