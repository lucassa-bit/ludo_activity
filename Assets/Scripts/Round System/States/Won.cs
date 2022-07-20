using System.Collections;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Won : State
{
    public Won(RoundSystem roundSystem) : base(roundSystem) { }

    public override IEnumerator Start()
    {
        RoundSystem.Canva.SetActive(true);
        RoundSystem.Canva.GetComponentInChildren<TextMeshProUGUI>().text = "YOU WON!";

        yield return new WaitForSeconds(4f);
        RoundSystem.GameManager.canStart = false;

        RoundSystem.GameManager.gameObject.GetComponent<Database>()
            .Inserir(((Team)RoundSystem.RoundIndex).ToString(), (int)RoundSystem.GameManager.timer);

        RoundSystem.GameManager.timer = 0;

        SceneManager.LoadScene(0);
    }
}
