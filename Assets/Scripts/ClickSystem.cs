using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSystem : MonoBehaviour
{
    RaycastHit2D hit;

    public Piece Piece;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        }
    }

    public IEnumerator ClickToGo()
    {
        if (hit)
        {
            while (hit.transform == null || hit.transform.gameObject.GetComponent<Piece>() == null)
            {
                yield return null;
            }
            Piece = hit.transform.gameObject.GetComponent<Piece>();
        }
        yield break;
    }
}
