using System;
using System.Collections;
using UnityEngine;

public class PlayerTurn : State
{
    public PlayerTurn(RoundSystem roundSystem) : base(roundSystem) { }

    public override IEnumerator Start()
    {
        RoundSystem.Button.SetActive(true);
        yield break;
    }
}
