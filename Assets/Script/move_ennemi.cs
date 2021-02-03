using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_ennemi : MonoBehaviour
{
    public GameObject target;
    public float speed = 8f;
    public bool agro = false;
    public Vector3 position_initial;

    // Start is called before the first frame update
    void Start()
    {
        //transform.parent.GetComponent<Renderer>().material.color = Color.gray;
        position_initial = transform.parent.position;
    }

    void OnTriggerStay(Collider other) {
        if (target == null)
        {
            if (other.tag == "Peon" && !other.gameObject.GetComponent<Player>().dead)
            {
                //transform.parent.GetComponent<Renderer>().material.color = Color.red;
                 target = other.gameObject;
                agro = true;
            }
        }
    }

    void OnTriggerExit(Collider other) {
        //transform.parent.GetComponent<Renderer>().material.color = Color.gray;
        if(other.gameObject == target)
        {
            agro = false;
            target = null;
        }
    }

    void Update() {
        if(target != null && target.GetComponent<Player>().dead)
        {
            target = null;
        }
        float step = speed * Time.deltaTime;
        if (agro)
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, target.transform.position, step);
        else
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, position_initial, step);
    }
}
