using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitSpawner : MonoBehaviour {
    public Transform[] spawnPoints;
    public Bait bait;
    public float spawnCooldown = 60f;  //Will respawn after a minute
    private static bool isSpawned = true;
    int spawnPointIndex;

	// Use this for initialization
	void Start () {
        spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //Spawns initial bait into world at for different points
        Instantiate(bait, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        InvokeRepeating("Spawn", spawnCooldown, spawnCooldown);
    }

    void Spawn()
    {
        if (!isSpawned)
        {
            Instantiate(bait, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            isSpawned = true;
        }
    }
}
