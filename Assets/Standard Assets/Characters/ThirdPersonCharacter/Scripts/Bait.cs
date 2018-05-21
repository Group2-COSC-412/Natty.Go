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
    public void Start () {
        int randNum = Random.Range(0, 4);

        switch (randNum)
        {
            case 0:
                bait = BaitType.Carrot;
                gameObject.GetComponent<Renderer>().material.color = carrotColor;
                break;

            case 1:
                bait = BaitType.Fish;
                gameObject.GetComponent<Renderer>().material.color = fishColor;
                break;

            case 2:
                bait = BaitType.Berries;
                gameObject.GetComponent<Renderer>().material.color = berryColor;
                break;

            case 3:
                bait = BaitType.Hay;
                gameObject.GetComponent<Renderer>().material.color = hayColor;
                break;

            case 4:
                bait = BaitType.Nuts;
                gameObject.GetComponent<Renderer>().material.color = nutColor;
                break;
        }
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
        Destroy(gameObject);
    }
}
