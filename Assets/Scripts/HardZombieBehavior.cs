using System;
using UnityEngine;
using UnityEngine.AI;

public class HardZombieBehavior : MonoBehaviour
{
    public GameObject playerGameObject;

    public float speed = 5f;
    public float speedWhenTriggered = 8f;

    private float _currentSpeed;
    
    private NavMeshAgent _agent;

    private void Awake()
    {
        _currentSpeed = speed;
    }

    void Start()
    {

        //Debug.Log("Respawn Hard Zombie");
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(playerGameObject.gameObject.transform.position);
    }

    private void Update()
    {
        if (playerGameObject == default) return;
        _agent.SetDestination(playerGameObject.gameObject.transform.position);
        _agent.speed = _currentSpeed;

        if (Vector3.Distance(transform.position, playerGameObject.gameObject.transform.position) < 10f)
        {
            _currentSpeed = speedWhenTriggered;
            return;
        }
        _currentSpeed = speed;

    }
}
