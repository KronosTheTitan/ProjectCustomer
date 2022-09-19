using UnityEngine;
using Random = UnityEngine.Random;

public class TrashSpawner : MonoBehaviour
{
    /// <summary>
    /// the time between picking up the spawned trash and spawning new trash
    /// </summary>
    [SerializeField] private float spawnTimer;
    
    /// <summary>
    /// the maximum radius withing which new trash can spawn.
    /// </summary>
    [SerializeField] private float radius;

    /// <summary>
    /// the time at which the most recent timer started.
    /// </summary>
    private float timerStart = 0;
    
    
    /// <summary>
    /// the trash object belonging to this spawner.
    /// </summary>
    private GameObject spawnedTrash;
    
    /// <summary>
    /// used to check if the respawn timer is currently running.
    /// </summary>
    private bool spawnTimerRunning = false;

    private void Update()
    {
        if (spawnedTrash == null && !spawnTimerRunning)
        {
            timerStart = Time.time;
            spawnTimerRunning = true;
        }

        //if current time exceeds the starting time of the current timer + the spawn time
        //and the timer is running. then a new trash object will be spawned at a random
        //position inside of the spawn radius.
        if (Time.time > timerStart + spawnTimer && spawnTimerRunning)
        {
            //create a new trash object and set spawnedTrash to that new object.
            //spawned object is a prefab fetched from the gameManager.
            spawnedTrash = Instantiate(GameManager.Instance.TrashPrefab);

            //pick a random position between -10 and 10 on each axis.
            //used to create a random direction.
            Vector3 newPos = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
            
            //scale the length of the newPos vector to be 1.
            newPos.Normalize();
            
            //randomize the distance between 0 and the radius of the spawner.
            newPos *= Random.Range(0, radius);
            
            //set the position of the spawned trash to the spawners position + the newPos
            spawnedTrash.transform.position = transform.position + newPos;
            
            //turn of the timer.
            spawnTimerRunning = false;
        }
    }

    /// <summary>
    /// draws the radius in the editor when the object is selected.
    /// makes it easier for designers to estimate the size.
    /// </summary>
    void OnDrawGizmos ()
    {
        //set the color of the gizmo to be drawn to yellow.
        Gizmos.color = Color.yellow;
        
        //draw a wire sphere at the origin of the gameObject with the radius of the object.
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
