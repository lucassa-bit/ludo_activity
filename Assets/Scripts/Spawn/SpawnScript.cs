using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> SpawnPrefab;
    [SerializeField] private Vector3[] spawnPosition;
    private Transform spawnTransform;

    public int SpawnNum = 1;

    void Start()
    {
        spawnTransform = GetComponent<Transform>();
        getAllChildrens();
    }

    private void getAllChildrens()
    {
        int index = 0;
        Team time = GameObject.Find("GameManager").GetComponent<GameManager>().TeamPiece;

        foreach (GameObject child in SpawnPrefab)
        {
            if (SpawnNum <= index) break;

            GameObject instantiation = Instantiate(child, spawnPosition[index], Quaternion.Euler(0, 0, 0));
                foreach (SpriteRenderer childInstatiation in instantiation.GetComponentsInChildren<SpriteRenderer>())
                {
                    childInstatiation.gameObject.AddComponent<Piece>();
                if (time == (Team)Enum.Parse(typeof(Team), child.name.Split("(")[0]))
                    childInstatiation.gameObject.AddComponent<BoxCollider2D>();
                }
            
            instantiation.transform.parent = spawnTransform.transform;
            index++;
        }
    }
}
