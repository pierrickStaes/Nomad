using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_collider : MonoBehaviour
{
    void OnTriggerEnter() {
        print("Collision");
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
