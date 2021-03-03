using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controlador : MonoBehaviour
{


    public GameObject player;
    public GameObject[] enemies;
    public GameObject[] points;
    public int MaxEnemies = 6;
    int ingame = 1;
    NavMeshAgent agent;
    NavMeshAgent[] agentE;
    GameObject[] targets;


    // Start is called before the first frame update
    void Start()
    {
        agentE = new NavMeshAgent[enemies.Length];
        targets = new GameObject[enemies.Length];
        agent = player.GetComponent<NavMeshAgent>();

        for (int i = 0; i < enemies.Length; i++) {
            if (enemies[i])
                agentE[i] = enemies[i].GetComponent<NavMeshAgent>();
        }
        

    }

    // Update is called once per frame
    void Update()
    {

        for (int x = 0; x <ingame; x++) {

            if (!targets[x])
            {
                if (enemies[x])
                    targets[x] = points[Random.Range(0, 5)];
                if (enemies[x])
                    agentE[x].SetDestination(targets[x].GetComponent<Rigidbody>().position);
            }
            if(enemies[x] &&  agentE[x].remainingDistance < 1) {
                targets[x] = null;
            }
        }

        if (Time.time % 10 > 9.995 && ingame < MaxEnemies)
        {
            
            enemies[ingame].SetActive(true);
            ingame++;
        }



        RaycastHit hitInfo;
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(myRay, out hitInfo) && Input.GetMouseButton(0))
        {

            agent.SetDestination(hitInfo.point);

        }

    }


    bool isClose(Vector3 targt) {

        bool conclusion = false;

        if (Mathf.Abs(targt.x) < 1)
            conclusion = true;
        if (Mathf.Abs(targt.y) < 1)
            conclusion = true;

        return conclusion;
    
    }
}
