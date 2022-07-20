using System;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Team TeamEnum;

    public int Id;
    public int Position;
    public int Steps = 0;

    public bool IsOnBoard = false;
    public bool HasBeenKilled = false;

    public Vector3 InitialVector;

    private Transform gO;

    private void Start()
    {
        gO = GetComponent<Transform>();
        TeamEnum = (Team)Enum.Parse(typeof(Team), gO.parent.name.Split('(')[0]);
        Id = int.Parse(gO.name);
        InitialVector = gO.transform.position;
        Position = (-1) * ((int)TeamEnum);

        defineSpawnPoint();
    }

    public void changingPosition(Vector3 newPosition)
    {
        if (Position < 0) defineSpawnPoint();
        Vector3 pickDiference = newPosition - gO.transform.position;
        gO.position += pickDiference;
        //Debug.Log("Attacker: " + gameObject.GetComponent<Transform>().parent.name + " " + gameObject.name);

        foreach (Piece children in gO.parent.parent.GetComponentsInChildren<Piece>())
        {
            if (children.TeamEnum != TeamEnum && children.Position == this.Position)
            {
                //Debug.Log("Victim: " + children.gameObject.GetComponent<Transform>().parent.name + " " + children.gameObject.name);
                children.deathApplication();
                break;
            }
        }
    }

    public void deathApplication()
    {
        Debug.Log(gameObject.GetComponent<Transform>().parent.name + " " + gameObject.name);
        if (IsOnBoard) IsOnBoard = !IsOnBoard;
        if (!HasBeenKilled) HasBeenKilled = !HasBeenKilled;

        gO.transform.position = InitialVector;
        Steps = HasBeenKilled ? 7 : 0;

        defineSpawnPoint();
    }

    public void defineSpawnPoint()
    {
        switch (TeamEnum)
        {
            case Team.Red:
                Position = HasBeenKilled ? 32 : 25;
                break;
            case Team.Green:
                Position = HasBeenKilled ? 20 : 13;
                break;
            case Team.Blue:
                Position = HasBeenKilled ? 44 : 37;
                break;
            case Team.Yellow:
                Position = HasBeenKilled ? 8 : 1;
                break;
        }
    }
}
