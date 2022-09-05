using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrashSpawner : MonoBehaviour
{
    [SerializeField] private float spawnTimer;
    [SerializeField] private float radius;

    private float timerStart = 0;
    private GameObject spawnedTrash;
    private bool spawnTimerRunning = false;

    private void Update()
    {
        if (spawnedTrash == null && !spawnTimerRunning)
        {
            timerStart = Time.time;
            spawnTimerRunning = true;
        }

        if (Time.time > timerStart + spawnTimer && spawnTimerRunning)
        {
            spawnedTrash = Instantiate(GameManager.Instance.TrashPrefab);

            Vector3 newPos = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
            newPos.Normalize();
            newPos *= Random.Range(0, radius);
            
            spawnedTrash.transform.position = transform.position + newPos;
            
            spawnTimerRunning = false;
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
