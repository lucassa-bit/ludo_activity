using UnityEngine;

public enum Team
{
    Red = 0,
    Blue = 1,
    Green = 2,
    Yellow = 3
}

public static class Utility
{
    public static Piece GetPieceByIndex(Team teamFind, int piece)
    {
        GameObject father = GameObject.Find("Spawn");
        if (father != null)
        {
            foreach (Piece children in father.GetComponentsInChildren<Piece>())
            {
                if (children.gameObject.GetComponent<Transform>()
                        .parent.name.Split("(")[0] == teamFind.ToString()
                            && children.gameObject.name == piece.ToString())
                    return children;
            }
        }

        return null;
    }

    public static Color TeamToColor(Team t)
    {
        switch (t)
        {
            case Team.Red:
                return Color.red;
            case Team.Green:
                return Color.green;
            case Team.Yellow:
                return Color.yellow;
            case Team.Blue:
                return Color.blue;
            default:
                return Color.white;
        }
    }
}
