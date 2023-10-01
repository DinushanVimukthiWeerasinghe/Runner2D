using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGenerator : MonoBehaviour
{
    public ObjectPooler healthPooler;

    // Update is called once per frame
    public void SpawnHealth(Vector3 position, float groundWidth)
    {
        int randomNo = Random.Range(0, 100);
        if (randomNo < 50)
        {
            return;
        }
        int noOfHealth = 1;
        float xPosition = position.x + groundWidth/2 - 2f;
        for (int i = 0; i < noOfHealth; i++)
        {
            GameObject health = healthPooler.GetPooledObject();
            health.transform.position = new Vector3(
                xPosition + i,
                position.y + 4f,
                position.z
                );
            health.SetActive(true);
        }
    }
}
