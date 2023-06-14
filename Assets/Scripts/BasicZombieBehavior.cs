using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class BasicZombieBehavior : MonoBehaviour
{
    public List<Vector3> locationsToGoAround;
    public GameObject playerGameObject;
    public float normalSpeed = 4f;
    public float triggeredSpeed = 5f;

    private NavMeshAgent _agent;

    private Vector3 _lastLocation = Vector3.zero;

    void Start()
    {

            //Debug.Log("Respawn Basic Zombie");
            _agent = GetComponent<NavMeshAgent>();
            _lastLocation = locationsToGoAround[new System.Random().Next(locationsToGoAround.Count)];
            _agent.SetDestination(_lastLocation);
    }

    private void Update()
    {
        if (playerGameObject == default) return;
        if (Vector3.Distance(transform.position, playerGameObject.gameObject.transform.position) < 10f)
        {
            _lastLocation = default;
            _agent.SetDestination(playerGameObject.gameObject.transform.position);
            _agent.speed = triggeredSpeed;
            return;
        }

        if (_lastLocation == Vector3.zero || Vector3.Distance(transform.position, _lastLocation) < 3f)
        {
            _lastLocation = locationsToGoAround[new System.Random().Next(locationsToGoAround.Count)];
            _agent.SetDestination(_lastLocation);
            _agent.speed = normalSpeed;
        }
    }
}