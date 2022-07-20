using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject Menu;
    public GameObject FindColor;
    public GameObject Rank;
    public void PlayGame()
    {
        Menu.SetActive(!Menu.activeSelf);
        FindColor.SetActive(!FindColor.activeSelf);
    }
    public void Ranking()
    {
        Menu.SetActive(!Menu.activeSelf);
        Rank.SetActive(!Rank.activeSelf);
    }
    public void Quit(){
        Application.Quit();
    }
}
