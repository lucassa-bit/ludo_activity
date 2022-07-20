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
        DiceAnimator.enabled = false;
    }

    public int ShakeDice()
    {
        int valorRandom = Random.Range(0, DiceImagesList.Count);
        DiceRenderer.sprite = DiceImagesList[valorRandom];
        return valorRandom + 1;
    }
}
