using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class buttonFix : MonoBehaviour
{
    UnityAction UnityA;
    void Start()
    {
        UnityA += GameObject.Find("GameManager").GetComponent<GameManager>().clickButton;
        gameObject.GetComponent<Button>().onClick.AddListener(UnityA);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
