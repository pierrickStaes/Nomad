using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RessourcesHUD : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Noyau");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 15;
        myStyle.normal.textColor = Color.white;
        //GUI.Label(new Rect(Screen.width - 110, 10, 100, 20), $"Ressources : {player.GetComponent<Inventory>().ressourcesNumber}", myStyle);
        GUI.Label(new Rect(Screen.width - 110, 10, 100, 20), $"Bois : {player.GetComponent<Inventory>().bois1.RessourceCount}", myStyle);
        GUI.Label(new Rect(Screen.width - 110, 30, 100, 20), $"Minerais : {player.GetComponent<Inventory>().minerai1.RessourceCount}", myStyle);
        GUI.Label(new Rect(Screen.width - 110, 50, 100, 20), $"Plantes : {player.GetComponent<Inventory>().plante1.RessourceCount}", myStyle);
    }
}
