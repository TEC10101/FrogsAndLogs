using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlySpawner : MonoBehaviour {

    [SerializeField]
    private GameObject flyPrefab;

    [SerializeField]
    private int totalFlyMinimum = 12; //doesn't have to be serialized but lets us help change in inspector

    // play area is roughly a square of 50x50.  measuring from origin the x and z coords are -25 25
    private float spawnArea = 25f;

    public static int totalFlies;

	// Use this for initialization
	void Start () {
        totalFlies = 0;
	}
	
	// Update is called once per frame
	void Update () {

        // Create flies until minimum amount is there...
        while (totalFlies < totalFlyMinimum)
        {
            // ...increment fly count...
            totalFlies++;

            // ...create a random position for a fly...
            // ...nothing in place in case the same x,z coords...
            float positionX = Random.Range(-spawnArea, spawnArea);
            float positionZ = Random.Range(-spawnArea, spawnArea);

            Vector3 flyPosition = new Vector3(positionX, 2f, positionZ);

            // ...and create new fly.
            Instantiate(flyPrefab, flyPosition, Quaternion.identity);
        }
	}
}
