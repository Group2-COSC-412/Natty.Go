using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bait : MonoBehaviour {
    public enum BaitType
    {
        Carrot,
        Fish,
        Berries,
        Hay,
        Nuts,
    }

    public BaitType bait;
    public Color carrotColor;
    public Color fishColor;
    public Color berryColor;
    public Color hayColor;
    public Color nutColor;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * 30 * Time.deltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        AnimalSpawner spawner = new AnimalSpawner();
         if(spawner == null)
         {
            return;
         }

        switch (bait)
        {
            case BaitType.Berries:
                spawner.spawnDeer();
                break;
            case BaitType.Carrot:
                spawner.spawnRabbit();
                break;
            case BaitType.Fish:
                spawner.spawnWhale();
                break;
            case BaitType.Hay:
                spawner.spawnHorse();
                break;
            case BaitType.Nuts:
                spawner.spawnSquirrel();
                break;
            default:
                break;
        }
    }

    public void setBaitTypeOnSpawn(BaitType b)
    {

    }
}
