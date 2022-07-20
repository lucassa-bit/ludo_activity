using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IATurn : State
{
    public IATurn(RoundSystem roundSystem) : base(roundSystem) { }

    public override IEnumerator Start()
    {
        RoundSystem.Button.SetActive(false);
        if (RoundSystem.GetPieces().Count <= 0)
        {
            RoundSystem.Button.SetActive(false);
            RoundSystem.SetState(new Lost(RoundSystem));
            yield break;
        }

        yield return RoundSystem.StartCoroutine(PlayDice());

        RoundSystem.NextPlayer();
        RoundSystem.SetState(RoundSystem.RoundIndex == RoundSystem.playerIndex
            ? new PlayerTurn(RoundSystem)
            : new IATurn(RoundSystem));
    }

    public override IEnumerator PlayDice()
    {
        int Addition = RoundSystem.Dice.GetComponent<Dice>().ShakeDice();
        List<Piece> pieces = RoundSystem.GetPieces();

        yield return new WaitForSeconds(1.5f);

        if (pieces.Count <= 0)
        {
            RoundSystem.SetState(new Lost(RoundSystem));
        } 
        else
        {
            if (pieces.TrueForAll((valor) => !valor.IsOnBoard))
            {
                RoundSystem.GameManager.MovementInsideBoard(Addition, pieces.ToArray()[pieces.Count - 1]);
            }
            else
            {
                Piece EndingPiece = pieces.Find((valor) => (Addition + valor.Steps) == 51);
                Piece KillerPiece = CanKill(RoundSystem.Spawner.GetComponentsInChildren<Piece>(), pieces.ToArray(), Addition);

                if (EndingPiece != null)
                {
                    RoundSystem.GameManager.MovementInsideBoard(Addition, EndingPiece);
                }
                else if (KillerPiece != null)
                {
                    RoundSystem.GameManager.MovementInsideBoard(Addition, KillerPiece);
                }
                else if (Addition == 6 && pieces.Find((valor) => !valor.IsOnBoard) != null)
                {
                    RoundSystem.GameManager.MovementInsideBoard(Addition, pieces.Find((valor) => !valor.IsOnBoard));
                }
                else
                {
                    RoundSystem.GameManager.MovementInsideBoard(Addition, WhoIsMoreDistant(pieces.FindAll((value) => value.IsOnBoard).ToArray()));
                }
            }
        }

        yield break;
    }

    public Piece CanKill(Piece[] pieces, Piece[] teamPieces, int extraStepsToKill)
    {
        foreach (Piece killer in teamPieces)
            foreach (Piece victim in pieces)
                if (!victim.IsOnBoard) continue;
                else if(victim.Position == (killer.Position + extraStepsToKill))
                    return killer;

        return null;
    }

    public Piece WhoIsMoreDistant(Piece[] pieces)
    {
        Piece savePiece = null;

        foreach (Piece piece in pieces)
        {
            if(savePiece == null || savePiece.Steps < piece.Steps)
            {
                savePiece = piece;
            }
        }
        return savePiece;
    }
}
