using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using TMPro;


public class SpawnZombieRandomlyAtSelectedLocations : MonoBehaviour
{
    public List<Vector3> respawnLocations;
    public List<Vector3> locationsToGoAround;
    public GameObject prefabToSpawn;
    public GameObject playerGameObject;
    public float regularZombieSpeed = 4f;
    public float regularTriggeredZombieSpeed = 5f;
    public float hardZombieNormalSpeed = 3f;
    public float hardZombieTriggeredSpeed = 4f;

    public TextMeshProUGUI loserText;

    private void Start()
    {
       var toDestroy=Instantiate(prefabToSpawn, respawnLocations[0], Quaternion.identity);
       Destroy(toDestroy);

        var basicZombiesCount = respawnLocations.Count * 2 / 3;
        var hardZombiesCount = respawnLocations.Count - basicZombiesCount;

        var uniqueSpawnLocations = new Queue<Vector3>(respawnLocations);

        for (var i = 0; i < basicZombiesCount; i++)
        {
            SpawnZombie(true);
        }

        for (int i = 0; i < hardZombiesCount; i++)
        {
            SpawnZombie(false);
        }

        GameObject SpawnZombie(bool isBasic)
        {
            Vector3 positionOfSpawnedObject = uniqueSpawnLocations.Dequeue();
            Quaternion rotationOfSpawnedObject = Quaternion.identity; // no rotation.
            // GameObject zombieObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject)
            GameObject zombieObject = default;

            // Find the closest point on the NavMesh to the spawn location
            NavMeshHit hit;
            if (NavMesh.SamplePosition(positionOfSpawnedObject, out hit, 5f, NavMesh.AllAreas))
            {
                // Spawn the zombie at the closest point on the NavMesh
                zombieObject = Instantiate(prefabToSpawn, hit.position, rotationOfSpawnedObject);
                zombieObject.GetComponent<KillOnCollide>().loserText = loserText;
                // Enable navigation for the zombie
                NavMeshAgent zombieAgent = zombieObject.GetComponent<NavMeshAgent>();
                if (zombieAgent != null)
                {
                    zombieAgent.enabled = true;
                }
                
                if (isBasic)
                {
                    var zombieObjectScript = zombieObject.AddComponent<BasicZombieBehavior>();
                    zombieObjectScript.locationsToGoAround = locationsToGoAround;
                    zombieObjectScript.playerGameObject = playerGameObject;
                }
                else
                {
                    var zombieObjectScript = zombieObject.AddComponent<HardZombieBehavior>();
                    zombieObjectScript.playerGameObject = playerGameObject;
                    zombieObjectScript.speed = hardZombieNormalSpeed;
                    zombieObjectScript.speedWhenTriggered = hardZombieTriggeredSpeed;

                }
            }

            return zombieObject;
        }
    }
}