using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour {

    enum BaitType
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
    private BaitType bait;
    

	// Use this for initialization
	void Start () {
        bait = BaitType.None;
	}
	
	// Update is called once per frame
	void Update () {
        //if the player has ran into bait, spawn a dude
        if (!player.GetComponent<BaitType>().Equals(BaitType.None))
        {
            spawn();
        }
	}

    void spawn()
    {
        if (player.GetComponent<BaitType>().Equals(BaitType.Berries))
        {
            bait = BaitType.Berries;
            spawnDeer();
        }

        else if (player.GetComponent<BaitType>().Equals(BaitType.Hay))
        {
            bait = BaitType.Hay;
            spawnHorse();
        }

        else if (player.GetComponent<BaitType>().Equals(BaitType.Fish))
        {
            bait = BaitType.Fish;
            spawnWhale();
        }

        else if (player.GetComponent<BaitType>().Equals(BaitType.Nuts))
        {
            bait = BaitType.Nuts;
            spawnSquirrel();
        }

        else if (player.GetComponent<BaitType>().Equals(BaitType.Carrot))
        {
            bait = BaitType.Carrot;
            spawnRabbit();
        }
    }

    void spawnDeer()
    {

    }

    void spawnHorse()
    {

    }

    void spawnSquirrel()
    {

    }

    void spawnWhale()
    {

    }

    void spawnRabbit()
    {

    }
}
