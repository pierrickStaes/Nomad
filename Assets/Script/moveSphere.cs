using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveSphere : MonoBehaviour
{
    public float Speed=10f;
    public int Life = 100;
    public bool attacked = false; 
    public Text LifeText;

    // Start is called before the first frame update
    void Start()
    {
        LifeText.text = "PV : " + Life;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left*Time.deltaTime*Speed);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right*Time.deltaTime*Speed);
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.forward*Time.deltaTime*Speed);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(-Vector3.forward*Time.deltaTime*Speed);
        if (Input.GetKeyDown("space"))
            rb.velocity += Vector3.up*Speed;
    }

    void OnTriggerEnter(Collider obj) {
        attacked = true;
        if (attacked)
        {
            if (Life > 0)
            {
                Life = Life - 10;
            }
            LifeText.text = "PV : " + Life;
        }
    }

    void OnTriggerExit(Collider other) {
        attacked = false;
    }
}
