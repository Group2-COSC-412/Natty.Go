using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour {

    public enum myBait
    {
        Carrot,
        Fish,
        Berries,
        Hay,
        Nuts,
        None
    }

    public Transform[] spawnPoints;
    public GameObject deer;
    public GameObject horse;
    public GameObject squirrel;
    public GameObject whale;
    public GameObject rabbit;
    public GameObject player;
    public myBait bait;
    int spawnPointIndex;

    

	// Use this for initialization
	void Start () {
        bait = myBait.None;
	}
	
	// Update is called once per frame
	void Update () {
        //if the player has ran into bait, spawn a dude
        /*if (!player.GetComponent<myBait>().Equals(myBait.None))
        {
            spawn();
        }*/
	}

    /*void spawn()
    {
        if (player.GetComponent<myBait>().Equals(myBait.Berries))
        {
            bait = myBait.Berries;
            spawnDeer();
        }

        else if (player.GetComponent<myBait>().Equals(myBait.Hay))
        {
            bait = myBait.Hay;
            spawnHorse();
        }

        else if (player.GetComponent<myBait>().Equals(myBait.Fish))
        {
            bait = myBait.Fish;
            spawnWhale();
        }

        else if (player.GetComponent<myBait>().Equals(myBait.Nuts))
        {
            bait = myBait.Nuts;
            spawnSquirrel();
        }

        else if (player.GetComponent<myBait>().Equals(myBait.Carrot))
        {
            bait = myBait.Carrot;
            spawnRabbit();
        }
    }*/

    public void spawnDeer()
    {
        spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(deer, (spawnPoints[spawnPointIndex].position + player.transform.position), spawnPoints[spawnPointIndex].rotation);
    }

    public void spawnHorse()
    {
        spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(horse, (spawnPoints[spawnPointIndex].position + player.transform.position), spawnPoints[spawnPointIndex].rotation);
    }

    public void spawnSquirrel()
    {
        spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(squirrel, (spawnPoints[spawnPointIndex].position + player.transform.position), spawnPoints[spawnPointIndex].rotation);
    }

    public void spawnWhale()
    {
        spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(whale, (spawnPoints[spawnPointIndex].position + player.transform.position), spawnPoints[spawnPointIndex].rotation);
    }

    public void spawnRabbit()
    {
        spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(rabbit, (spawnPoints[spawnPointIndex].position + player.transform.position), spawnPoints[spawnPointIndex].rotation);
    }
}
