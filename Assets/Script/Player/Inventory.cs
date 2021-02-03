using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Array inventoryContent;
    private bool textBox = false;
    public bool opened = false;
    private GameObject ressource;
    public string ressourceName;
    public string ressourceType;
    public int ressourceValue;
    public int ressourcesNumber;
    // Initialisation de l'objet Ressource
    public class RessourceObject
    {
        public RessourceObject(string first, int second, string last)
        {
            RessourceName = first;
            RessourceCount = second;
            RessourceType = last;
        }

        public string RessourceName { get; set; }
        public int RessourceCount { get; set; }
        public string RessourceType { get; set; }

        public string displayRessource() => RessourceName + " : " + RessourceCount + " / " + RessourceType;
        public string displayRessourceName() => RessourceName;
        public int displayRessourceCount() => RessourceCount;
        public string displayRessourceType() => RessourceType;
    }
    public RessourceObject minerai1 = new RessourceObject("Minerai 1", 0, "minerai");
    public RessourceObject bois1 = new RessourceObject("Bois 1", 0, "bois");
    public RessourceObject plante1 = new RessourceObject("Plante 1", 0, "plante");

    void Start()
    {
        ressourcesNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) & !opened)
        {
            opened = !opened;
            Debug.Log("Inventaire ouvert !");
            Debug.Log($"Nombre total de ressources : {ressourcesNumber}");
            Debug.Log($"{minerai1.displayRessource()}");
            Debug.Log($"{bois1.displayRessource()}");
            Debug.Log($"{plante1.displayRessource()}");
        } else if(Input.GetKeyDown(KeyCode.I))
        {
            opened = !opened;
        }
    }

    public void addToInventory(Collider ressource)
    {
        //if (ressourceType != ressource.GetComponent<Ressource>().ressourceType)
        //{
        //    Debug.Log("Ressource obtenue différente de la dernière");
        //}

        if (ressource.GetComponent<Ressource>().ressourceType == "minerai")
        {
            minerai1.RessourceCount += 1;
            ressourceName = minerai1.RessourceName;
            ressourceValue = minerai1.RessourceCount;
            ressourcesNumber += 1;
            Debug.Log($"{minerai1.displayRessourceName()} obtenu !");
        }
        else if (ressource.GetComponent<Ressource>().ressourceType == "bois")
        {
            bois1.RessourceCount += 1;
            ressourceName = bois1.RessourceName;
            ressourceValue = bois1.RessourceCount;
            ressourcesNumber += 1;
            Debug.Log($"{bois1.displayRessourceName()} obtenu !");
        }
        else if (ressource.GetComponent<Ressource>().ressourceType == "plante")
        {
            plante1.RessourceCount += 1;
            ressourceName = plante1.RessourceName;
            ressourceValue = plante1.RessourceCount;
            ressourcesNumber += 1;
            Debug.Log($"{plante1.displayRessourceName()} obtenu !");
        }

        //ressourceName = ressource.GetComponent<Ressource>().ressourceName;
        //ressourceType = ressource.GetComponent<Ressource>().ressourceType;
        //ressourceValue += ressource.GetComponent<Ressource>().ressourceValue;
        //Debug.Log($"{ressourceName} obtenu !");

        Destroy(ressource.gameObject);
        StartCoroutine(itemInfoBox());
    }

    IEnumerator itemInfoBox()
    {
        textBox = true;
        yield return new WaitForSeconds(1);
        textBox = false;
    }


    // Texte de notification quand ressource récupérée
    void OnGUI()
    {
        GUIStyle myStyle = new GUIStyle();
        myStyle.fontSize = 15;
        myStyle.normal.textColor = Color.white;
        if (textBox)
        {
            GUI.Label(new Rect(10, 10, 100, 20), $"{ressourceName} : {ressourceValue}", myStyle);
        }
        if (opened)
        {
            GUI.Label(new Rect(Screen.width - 130, 90, 100, 20), $"Inventaire ouvert !", myStyle);
        }
    }
}
