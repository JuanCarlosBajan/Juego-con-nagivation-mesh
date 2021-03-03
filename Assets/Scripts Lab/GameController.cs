using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject player;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {

        agent = player.GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hitInfo;
        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (agent && Physics.Raycast(myRay, out hitInfo) && Input.GetMouseButton(0)) {

            agent.SetDestination(hitInfo.point);

        }
        
    }
}
