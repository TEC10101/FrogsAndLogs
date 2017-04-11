using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public bool alive;
    [SerializeField]
    private GameObject pickupPrefab;


    // Use this for initialization
    void Start()
    {
        alive = true;
    }

    void OnTriggerEnter(Collider other)
    {
        // ...If the collider other is tagged with player...
        // ...aka if the bird runs into the player...
        if (other.CompareTag("Enemy") && alive == true)
        {
            alive = false;

            // Create the pickup particles
            Instantiate(pickupPrefab, transform.position, Quaternion.identity);

            //// ...decrease total number of flies...
            //FlySpawner.totalFlies = 0;

            //// ...update the score...
            //ScoreCounter.score = 0;

            //Destroy(gameObject);
        }
    }
}