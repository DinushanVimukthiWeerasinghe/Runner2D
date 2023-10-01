using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler coinPooler;
    public float maxCoinHeight=3f;

    public void SpawnCoins(Vector3 position, float groundWidth)
    {
        
        
        int noOfCoins = (int)Random.Range(3f, groundWidth );
        float xPosition = position.x -groundWidth/2 + 2f;
        float randomY = Random.Range(2f, maxCoinHeight);
        for (int i = 0; i < noOfCoins; i++)
        {
            
            GameObject coin = coinPooler.GetPooledObject();
            coin.transform.position = new Vector3(
                 xPosition + i,
                position.y + randomY,
                position.z);
            coin.SetActive(true);
        }
    }
    
    
}
