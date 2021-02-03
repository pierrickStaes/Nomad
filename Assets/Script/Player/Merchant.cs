using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    public GameObject player;
    private int playerRessourceValue;
    public string requiredRessource;
    public int requiredRessourceValue;
    public string givenRessource;
    public int givenRessourceValue;
    private int playerRequiredRessourceValue;
    private bool popUp = false;
    private int merchantDialog = 0;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void talkToMerchant()
    {
        popUp = !popUp;
        //Debug.Log("Salutations, je suis le marchand !");
        //playerRessourceValue = player.GetComponent<Inventory>().ressourceValue;
        //Debug.Log($"Vous avez {playerRessourceValue} ressources.");
        //if(playerRessourceValue >= 2)
        //{
        //    Debug.Log("2 ressources dépensées.");
        //    player.GetComponent<Inventory>().ressourceValue -= 2;
        //    Debug.Log($"Il vous reste ${player.GetComponent<Inventory>().ressourceValue}.");
        //}
        //else
        //{
        //    Debug.Log("Vous n'avez pas assez de ressources.");
        //}
    }

    void OnTriggerStay(Collider collider)
    {
        if(collider.tag == "Noyau")
        {
            player = collider.GetComponent<Player>().flag;
        }
    }

    IEnumerator merchantDialogText(int value)
    {
        merchantDialog = value;
        yield return new WaitForSeconds(1);
        merchantDialog = 0;
    }

    void OnGUI()
    {
        if(popUp)
        {
            // Récupère la valeur de la ressource demandée dans l'inventaire du joueur
            if(requiredRessource == "bois")
            {
                playerRequiredRessourceValue = player.GetComponent<Inventory>().bois1.RessourceCount;
            }
            else if (requiredRessource == "minerai")
            {
                playerRequiredRessourceValue = player.GetComponent<Inventory>().minerai1.RessourceCount;
            }
            else if (requiredRessource == "plante")
            {
                playerRequiredRessourceValue = player.GetComponent<Inventory>().plante1.RessourceCount;
            }
            // On vérifie si le joueur a le nombre de ressources demandées par le marchand
            if (playerRequiredRessourceValue < requiredRessourceValue)
            {
                GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 300, 100), $"Désolé, tu n'as pas assez de {requiredRessource}, \nil m'en faudrait {requiredRessourceValue} !");
                GUILayout.BeginArea(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 25, 100, 100));
                if (GUILayout.Button("Quitter"))
                {
                    popUp = !popUp;
                    player.GetComponent<playercontroller>().ableToMove = true;
                    StartCoroutine(merchantDialogText(1));
                }
                GUILayout.EndArea();
            }
            else
            {
                // Pour être centré : screen.width /2 - (rect.width / 2), pareil pour height
                GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 300, 135), $"Dépenser {requiredRessourceValue} {requiredRessource} contre {givenRessourceValue} {givenRessource} ?");
                GUILayout.BeginArea(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 25, 100, 100));
                if (GUILayout.Button("Non"))
                {
                    popUp = !popUp;
                    player.GetComponent<playercontroller>().ableToMove = true;
                    StartCoroutine(merchantDialogText(2));
                }
                if (GUILayout.Button("Oui"))
                {
                    // Ressource donnée
                    if(requiredRessource == "bois")
                    {
                        player.GetComponent<Inventory>().bois1.RessourceCount -= requiredRessourceValue;
                    } 
                    else if (requiredRessource == "minerai")
                    {
                        player.GetComponent<Inventory>().minerai1.RessourceCount -= requiredRessourceValue;
                    }
                    else if (requiredRessource == "plante")
                    {
                        player.GetComponent<Inventory>().plante1.RessourceCount -= requiredRessourceValue;
                    }
                    // Ressource reçue
                    if (givenRessource == "bois")
                    {
                        player.GetComponent<Inventory>().bois1.RessourceCount += givenRessourceValue;
                    }
                    else if (givenRessource == "minerai")
                    {
                        player.GetComponent<Inventory>().minerai1.RessourceCount += givenRessourceValue;
                    }
                    else if (givenRessource == "plante")
                    {
                        player.GetComponent<Inventory>().plante1.RessourceCount += givenRessourceValue;
                    }
                    popUp = !popUp;
                    player.GetComponent<playercontroller>().ableToMove = true;
                    StartCoroutine(merchantDialogText(3));
                }
                GUILayout.EndArea();
            }
        }
        if(merchantDialog == 1)
        {
            var position = Camera.main.WorldToScreenPoint(transform.position);
            var textSize = GUI.skin.label.CalcSize(new GUIContent("À bientôt, peuple nomade !"));
            GUI.backgroundColor = Color.gray;
            GUI.Label(new Rect(position.x, Screen.height - position.y, textSize.x, textSize.y), "À bientôt, peuple nomade !");
        }
        else if (merchantDialog == 2)
        {
            var position = Camera.main.WorldToScreenPoint(transform.position);
            var textSize = GUI.skin.label.CalcSize(new GUIContent("Dommage, à une prochaine fois !"));
            GUI.backgroundColor = Color.gray;
            GUI.Label(new Rect(position.x, Screen.height - position.y, textSize.x, textSize.y), "Dommage, à une prochaine fois !");
        }
        else if (merchantDialog == 3)
        {
            var position = Camera.main.WorldToScreenPoint(transform.position);
            var textSize = GUI.skin.label.CalcSize(new GUIContent("Merci peuple nomade !"));
            GUI.backgroundColor = Color.gray;
            GUI.Label(new Rect(position.x, Screen.height - position.y, textSize.x, textSize.y), "Merci peuple nomade !");
        }
    }
}
