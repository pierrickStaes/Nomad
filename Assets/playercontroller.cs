using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playercontroller : MonoBehaviour
{

    public Camera cam;
    public NavMeshAgent agent;
    public GameObject noyau;

    public int ratioPeuple = 2;
    private int peuplade = 8;
    public GameObject flagPeon;
    public GameObject peon;

    public int viePeuple = 16;

    public List<GameObject> généraux;
    public List<GameObject> soldats;

    public bool ableToMove = true;

    // Start is called before the first frame update
    void Start()
    {
        createPeon();
        //createPeuplade();
        createPeupladeRigide();
    }

    // Update is called once per frame
    void Update()
    {
        if (ableToMove)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Click move");
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    agent.SetDestination(hit.point);
                    Debug.Log(hit.point);
                }
            }
        }

        //FULL FLAG
        /*if (Input.GetKeyDown(KeyCode.UpArrow) && viePeuple<16)
        {
            soldats[16 - viePeuple].gameObject.GetComponent<otherFlag>().putVisible(true);
            viePeuple++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && viePeuple > 1)
        {
            viePeuple--;
            soldats[16-viePeuple].gameObject.GetComponent<otherFlag>().putVisible(false);
        }*/

        //RIGIDE
        if (Input.GetKeyDown(KeyCode.UpArrow) && viePeuple<16)
        {
            soldats[16 - viePeuple].gameObject.GetComponent<Player>().enableMesh(true);
            viePeuple++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && viePeuple > 1)
        {
            viePeuple--;
            soldats[16-viePeuple].gameObject.GetComponent<Player>().enableMesh(false);
        }
    }


    private void createPeon()
    {
        Vector3 newPos = new Vector3(transform.position.x, 0, transform.position.x);
        GameObject obj = Instantiate(noyau, newPos, Quaternion.identity);
        obj.gameObject.GetComponent<Player>().setFlag(this.gameObject);
    }

    private void createPeuplade()
    {
        float radius = 2f;
        float cercle = 1f;
        float cerclePopMax = peuplade;
        for (int i = 0; i < ratioPeuple; i++)
        {
            for (int j = 0; j < cerclePopMax; j++)
            {
                float angle = j * Mathf.PI * 2f / cerclePopMax;
                float rangeX = Mathf.Cos(angle) * radius * cercle;
                float rangeZ = Mathf.Sin(angle) * radius * cercle;
                Vector3 newPos = new Vector3(rangeX + transform.position.x, 0, rangeZ + transform.position.z);
                GameObject obj = Instantiate(flagPeon, newPos, Quaternion.identity);
                obj.gameObject.GetComponent<otherFlag>().setCam(this.cam);
                obj.gameObject.GetComponent<otherFlag>().setPeon(this.peon);
                obj.gameObject.GetComponent<otherFlag>().setRangeX(rangeX);
                obj.gameObject.GetComponent<otherFlag>().setRangeZ(rangeZ);
                if (i == 0)
                {
                    généraux.Add(obj);
                }
                else
                {
                    soldats.Add(obj);
                }
            }
            cercle++;
            cerclePopMax = (cerclePopMax * 2);
        }
        for (int i = 0; i < généraux.Count; i++)
        {
            GameObject temp = généraux[i];
            int randomIndex = Random.Range(i, généraux.Count);
            généraux[i] = généraux[randomIndex];
            généraux[randomIndex] = temp;
        }
        for (int i = 0; i < soldats.Count; i++)
        {
            GameObject temp = soldats[i];
            int randomIndex = Random.Range(i, soldats.Count);
            soldats[i] = soldats[randomIndex];
            soldats[randomIndex] = temp;
        }
    }

    private void createPeupladeRigide()
    {
        float radius = 2f;
        float cercle = 1f;
        float cerclePopMax = peuplade;
        for (int i = 0; i < ratioPeuple; i++)
        {
            for (int j = 0; j < cerclePopMax; j++)
            {
                float angle = j * Mathf.PI * 2f / cerclePopMax;
                float rangeX = Mathf.Cos(angle) * radius * cercle;
                float rangeZ = Mathf.Sin(angle) * radius * cercle;
                Vector3 newPos = new Vector3(rangeX + transform.position.x, 0, rangeZ + transform.position.z);
                GameObject obj = Instantiate(peon, newPos, Quaternion.identity);
                obj.gameObject.GetComponent<Player>().setFlag(this.gameObject);
                obj.gameObject.GetComponent<Player>().setRangeX(rangeX);
                obj.gameObject.GetComponent<Player>().setRangeZ(rangeZ);
                if (i == 0)
                {
                    généraux.Add(obj);
                }
                else
                {
                    soldats.Add(obj);
                }
            }
            cercle++;
            cerclePopMax = (cerclePopMax * 2);
        }
        for (int i = 0; i < généraux.Count; i++)
        {
            GameObject temp = généraux[i];
            int randomIndex = Random.Range(i, généraux.Count);
            généraux[i] = généraux[randomIndex];
            généraux[randomIndex] = temp;
        }
        for (int i = 0; i < soldats.Count; i++)
        {
            GameObject temp = soldats[i];
            int randomIndex = Random.Range(i, soldats.Count);
            soldats[i] = soldats[randomIndex];
            soldats[randomIndex] = temp;
        }
    }
}
