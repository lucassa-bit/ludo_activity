using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Animator DiceAnimator;
    private SpriteRenderer DiceRenderer;
    [SerializeField] private List<Sprite> DiceImagesList;
    [SerializeField] private float DiceAnimationDelay;

    void Start()
    {
        DiceAnimator = GetComponent<Animator>();
        DiceRenderer = GetComponent<SpriteRenderer>();
    }

    public int ShakeDice()
    {
        DiceAnimator.enabled = true;
        DiceAnimator.SetTrigger("Shake");

        int valorRandom = Random.Range(0, DiceImagesList.Count);
        StartCoroutine(ExecuteAfterTime(DiceAnimationDelay, valorRandom));
        return valorRandom + 1;
    }

    IEnumerator<WaitForSeconds> ExecuteAfterTime(float time, int index)
    {
        yield return new WaitForSeconds(time);
        DiceAnimator.enabled = false;
        DiceRenderer.sprite = DiceImagesList[index];

    }
}
