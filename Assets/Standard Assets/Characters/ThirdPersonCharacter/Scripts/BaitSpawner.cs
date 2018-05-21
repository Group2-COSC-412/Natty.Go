using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitSpawner : MonoBehaviour {
    public Transform[] spawnPoints;
    public Bait[] bait = new Bait[4];
    public float spawnCooldown = 60f;  //Will respawn after a minute
    private static bool[] isSpawned = { true, true, true, true };
    int spawnPointIndex;

	// Use this for initialization
	void Start () {
        spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //Initializes all the bait that will get spawned
        for(int i =0; i<bait.Length; i++)
        {
            bait[i].Start();
        }

        //Spawns initial bait into world at for different points
        Instantiate(bait[0], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        Instantiate(bait[1], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        Instantiate(bait[2], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        Instantiate(bait[3], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        InvokeRepeating("Spawn", spawnCooldown, spawnCooldown);
    }
	
	void Spawn()
    {
        if (!isSpawned[0])
        {
            isSpawned[0] = true;
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(bait[0], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }

        if (!isSpawned[1])
        {
            isSpawned[1] = true;
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(bait[1], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }

        if (!isSpawned[2])
        {
            isSpawned[2] = true;
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(bait[2], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }

        if (!isSpawned[3])
        {
            isSpawned[3] = true;
            spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(bait[3], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}
