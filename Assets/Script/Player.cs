using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject flag;
    public float rangeX;
    public float rangeZ;
    public bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        //createPeon();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(new Vector3(flag.transform.position.x + rangeX+0.1f, flag.transform.position.y, rangeZ + flag.transform.position.z + 0.1f));
        //agent.SetDestination(new Vector3(flag.transform.position.x, flag.transform.position.y, flag.transform.position.z));
    }
    public void setFlag(GameObject flag)
    {
        this.flag = flag;
    }
    public void setRangeX(float rangeX)
    {
        this.rangeX = rangeX;
    }

    public void setRangeZ(float rangeZ)
    {
        this.rangeZ = rangeZ;
    }

    public void enableMesh(bool enable)
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = enable;
        if (enable)
        {
            this.gameObject.GetComponent<NavMeshAgent>().obstacleAvoidanceType = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
        }
        else
        {
            this.gameObject.GetComponent<NavMeshAgent>().obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
        }
        
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Ressource")
        {
            collider.GetComponent<BoxCollider>().enabled = false;
            flag.GetComponent<Inventory>().addToInventory(collider);
        }
        if (collider.name == "Merchant")
        {
            if (Input.GetKey(KeyCode.F) & flag.GetComponent<playercontroller>().ableToMove)
            {
                flag.GetComponent<playercontroller>().ableToMove = false;
                collider.GetComponent<Merchant>().talkToMerchant();
            }
        }
        if(collider.tag == "ennemie")
        {
            enableMesh(false);
            dead = true;
        }
    }
}
