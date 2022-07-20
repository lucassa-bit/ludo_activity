using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lost : State
{
    public Lost(RoundSystem roundSystem) : base(roundSystem) { }

    public override IEnumerator Start()
    {
        RoundSystem.Canva.SetActive(true);
        RoundSystem.Canva.GetComponentInChildren<TextMeshProUGUI>().text = "YOU LOSE!";

        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(0);
    }
}
