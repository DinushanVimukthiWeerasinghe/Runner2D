using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public List<ObjectPooler> enemyPoolers;
    public void SpawnEnemies(Vector3 position, float groundWidth)
    {
        int randomEnemy = Random.Range(0, enemyPoolers.Count);
        ObjectPooler enemyPooler = enemyPoolers[randomEnemy];
        
        int noOfEnemies = 1;
        float xPosition = position.x + groundWidth/2 - 2f;
        for (int i = 0; i < noOfEnemies; i++)
        {
            
            GameObject enemy = enemyPooler.GetPooledObject();
            enemy.transform.position = new Vector3(
                xPosition + i,
                position.y + 2f,
                position.z);
            enemy.SetActive(true);
            // move enemy to the left 
        }
    }
}
