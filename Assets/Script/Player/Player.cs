using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float moveSpeed = 4f;
    public bool ableToMove = true;

    // Update is called once per frame
    void Update()
    {
        if (ableToMove)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0.0f, 0.0f, moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0.0f, 0.0f, -moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(moveSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
    }

    // Automatique ou appui de touche ?
    void OnTriggerStay(Collider collider)
    {
        if (collider.name != "Plane" & collider.name != "Merchant")
        {
            gameObject.GetComponent<Inventory>().addToInventory(collider);
        }
        if (collider.name == "Merchant")
        {
            if (Input.GetKey(KeyCode.F) & ableToMove)
            {
                ableToMove = !ableToMove;
                collider.GetComponent<Merchant>().talkToMerchant();
            }
        }
    }
}