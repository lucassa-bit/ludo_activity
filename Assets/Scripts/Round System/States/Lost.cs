using System.Collections;
using UnityEngine;

public class Lost : State
{
    public Lost(RoundSystem roundSystem) : base(roundSystem) { }

    public override IEnumerator Start()
    {
        Debug.Log("YOU LOSE!!!!!!!" + ((Team)RoundSystem.RoundIndex) + " WINS!!!!");
        yield return new WaitForSeconds(2f);
    }
}
