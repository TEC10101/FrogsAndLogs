using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPickup : MonoBehaviour
{
    [SerializeField]
    private GameObject pickupPrefab;


    void OnTriggerEnter(Collider other)
    {
        // if the collider other is tagged with player...
        // aka if the fly runs into the player, do code
        if (other.CompareTag("Player"))
        {
            // ...add the pickup particles...
            Instantiate(pickupPrefab, transform.position, Quaternion.identity);
            
            // ...decrease total number of flies...
            FlySpawner.totalFlies--;

            // ...update the score...
            ScoreCounter.score++;

            Destroy(gameObject);
        }
    }
}
