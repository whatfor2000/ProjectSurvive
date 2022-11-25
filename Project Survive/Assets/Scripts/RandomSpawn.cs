using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject[] myObjects;
    //public float currentTime;
    public float time;

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 3)
        {
            int randomIndex = Random.Range(0, myObjects.Length);
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));

            Instantiate(myObjects[randomIndex], randomSpawnPosition, Quaternion.identity);
            time = 0;
        }
    }
}
