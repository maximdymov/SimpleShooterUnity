using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float normalSpeed = 3.5f;
    [SerializeField] private float fastSpeed = 7f;
    [SerializeField] private PlayerDetection playerDetector;

    private int destPoint = 0;
    private NavMeshAgent agent;

    private void OnEnable()
    {
        playerDetector.PlayerDetected += MoveToPlayer;
        playerDetector.PlayerRan += ResetSpeed;
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agent.speed = normalSpeed;
        GotoNextPoint();
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }

    private void MoveToPlayer(object sender, System.EventArgs e)
    {
        agent.speed = fastSpeed;
        agent.destination = (Vector3)sender;
    }

    private void ResetSpeed()
    {
        agent.speed = normalSpeed;
    }
}
