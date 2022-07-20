using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class DisplayDatabase : MonoBehaviour
{
    public GameObject Text;
    int initialPoint = 80;

    public void Ranking()
    {
        IDataReader reader = GameObject.Find("MenuManager").GetComponent<Database>().Recuperar();
        int index = 1, position = initialPoint;
        while (reader.Read() && index <= 5)
        {
            string name = reader.GetString(0); 
            int value = reader.GetInt32(1);

            GameObject get = Instantiate(Text, Vector3.zero, Quaternion.Euler(Vector3.zero), transform);
            get.GetComponent<RectTransform>().localPosition = new Vector2(25, position);
            get.GetComponent<TextMeshProUGUI>().text = index + " - " + name + " => " + value + " s";

            index++; 
            position -= 40;
        }
    }

    private void OnEnable()
    {
        Ranking();
    }
    private void OnDisable()
    {
        foreach (TextMeshProUGUI reader in gameObject.GetComponentsInChildren<TextMeshProUGUI>())
        {
            Destroy(reader.gameObject);
        }
    }
}
