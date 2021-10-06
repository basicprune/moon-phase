using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float timeBetweenSpawns;
    public List<Transform> spawnLocations;

    void Start()
    {
        StartCoroutine("WaitAndSpawn");
    }

    IEnumerator WaitAndSpawn()
    {

        while (true)
        {

            yield return new WaitForSeconds(timeBetweenSpawns);
            int index = Random.Range(0, spawnLocations.Count);
            Transform locationToSpawn = spawnLocations[index];

            Instantiate(enemy, locationToSpawn.position, Quaternion.identity);


        }

    }
}
