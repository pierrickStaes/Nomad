using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class otherFlag : MonoBehaviour
{

    public Camera cam;
    public NavMeshAgent agent;
    public GameObject peon;
    public float rangeX;
    public float rangeZ;

    // Start is called before the first frame update
    void Start()
    {
        createPeon();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(new Vector3(rangeX + hit.point.x, hit.point.y, rangeZ+hit.point.z));
            }
        }
    }

    private void createPeon()
    {
        Vector3 newPos = new Vector3(transform.position.x, 0, transform.position.x);
        GameObject obj = Instantiate(peon, newPos, Quaternion.identity);
        obj.gameObject.GetComponent<Player>().setFlag(this.gameObject);
    }

    public void setCam(Camera cam)
    {
        this.cam = cam;
    }

    public void setPeon(GameObject peon)
    {
        this.peon = peon;
    }

    public void setRangeX(float rangeX)
    {
        this.rangeX = rangeX;
    }

    public void setRangeZ(float rangeZ)
    {
        this.rangeZ = rangeZ;
    }

    public void putVisible(bool visible)
    {
        this.enabled = visible;
        this.peon.gameObject.GetComponent<Player>().enableMesh(visible);
    }
}
