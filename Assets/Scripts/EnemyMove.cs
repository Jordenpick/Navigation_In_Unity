using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Transform[] path;
    [SerializeField] private int currentPathIndex = 0;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private EnemyDetection detection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        detection = GetComponentInChildren<EnemyDetection>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (detection.target == null)
        {
            if (agent.remainingDistance < .0000001f)
            {
                agent.SetDestination(path[currentPathIndex++].position);
                if (currentPathIndex >= path.Length)
                {
                    currentPathIndex = 0;
                }
            }
        }
        else
        {
            agent.SetDestination(detection.target.position);
        }
    }
}
