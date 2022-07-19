using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3[] posicoes;

    [SerializeField] private Vector3[] PosicoesRed;
    [SerializeField] private Vector3[] PosicoesBlue;
    [SerializeField] private Vector3[] PosicoesGreen;
    [SerializeField] private Vector3[] PosicoesYellow;

    [SerializeField] private int IndexPiece;
    public Team TeamPiece;

    public void MovementInsideBoard(int addition, Piece piece)
    {
        if (piece.IsOnBoard)
        {
            int checking = piece.Steps + addition;
            if (checking <= 45)
            {
                piece.Steps = checking;
                int soma = piece.Position + addition;
                piece.Position = soma > 47 ? soma - 47 : soma;
                piece.changingPosition(posicoes[piece.Position]);
            }
            else if (checking <= 50)
            {
                piece.Position = (-1) * ((int)piece.TeamEnum);
                piece.Steps = checking;
                int position = piece.Steps - 46;
                piece.changingPosition(piece.TeamEnum == Team.Red
                    ? PosicoesRed[position]
                    : piece.TeamEnum == Team.Blue
                        ? PosicoesBlue[position]
                        : piece.TeamEnum == Team.Green
                            ? PosicoesGreen[position]
                            : PosicoesYellow[position]);
            }
            else if (checking == 51)
            {
                Destroy(piece.gameObject);
            }
        }
        else if (!piece.IsOnBoard && addition == 6)
        {
            piece.IsOnBoard = !piece.IsOnBoard;
            piece.changingPosition(posicoes[piece.Position]);
        }

    }

    public IEnumerator PlayerPlay()
    {
        ClickSystem click = GameObject.Find("Main Camera").GetComponent<ClickSystem>();
        RoundSystem round = GameObject.Find("RoundSystem").GetComponent<RoundSystem>();
        Dice dice = GameObject.Find("Dice").GetComponent<Dice>();
        Piece piece = null;

        int shakeDice = dice.ShakeDice();

        round.Button.SetActive(false);
        if (round.GetPieces().TrueForAll((value) => !value.IsOnBoard) && shakeDice != 6)
        {
            round.NextPlayer();
            round.SetState(new IATurn(round));

            yield break;
        }

        while (piece == null)
        {
            Debug.Log(round.GetPieces().FindAll((value) => value.HasBeenKilled).Count);
            yield return StartCoroutine(click.ClickToGo());
            piece = click.Piece;
        }


        if (dice != null)
            MovementInsideBoard(shakeDice, piece);

        click.Piece = null;
        round.NextPlayer();
        round.SetState(new IATurn(round));
    }

    public void clickButton()
    {
        StartCoroutine(PlayerPlay());
    }
}
