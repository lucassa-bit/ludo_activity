using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickSystem : MonoBehaviour
{
    RaycastHit2D hit;
    public bool isForChooseColor;
    public Piece Piece;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (isForChooseColor)
                ClickColor();
        }
    }

    public IEnumerator ClickToGo(int addition)
    {
        if (hit)
        {
            Piece piece = hit.transform.gameObject.GetComponent<Piece>();
            if (hit.transform == null || piece == null || piece.Steps + addition > 51 || (!piece.IsOnBoard && addition != 6))
            {
                yield break;
            }
            Piece = hit.transform.gameObject.GetComponent<Piece>();
        }
    }

    public void ClickColor()
    {
        if(hit && hit.transform != null)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().TeamPiece = (Team)Enum.Parse(typeof(Team), hit.transform.name);
            SceneManager.LoadScene(1);
        }
    }
}
