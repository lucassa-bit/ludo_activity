using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : StateMachine
{
    public GameObject Spawner;
    public GameObject Canva;
    [HideInInspector] public GameManager GameManager;

    [HideInInspector] public int NumPlayers;
    [HideInInspector] public int RoundIndex = 0;
    [HideInInspector] public int playerIndex;


    public GameObject Dice;
    public GameObject Button;


    public void Start()
    {
        SetState(new Begin(this));
        GameManager= GameObject.Find("GameManager").GetComponent<GameManager>();
        playerIndex = (int)GameManager.TeamPiece;
        NumPlayers = Spawner.GetComponent<SpawnScript>().SpawnNum;
    }

    public void NextPlayer()
    {
        RoundIndex++;
        if (RoundIndex == NumPlayers)
            RoundIndex = 0;
    }

    public List<Piece> GetPieces()
    {
        Team team = (Team)RoundIndex;
        List<Piece> piece = new List<Piece>();

        foreach (Piece children in Spawner.GetComponentsInChildren<Piece>())
        {
            if (piece.Count > 3) break;

            if (children.TeamEnum == team)
            {
                piece.Add(children);
            }
        }

        return piece;
    }
}
