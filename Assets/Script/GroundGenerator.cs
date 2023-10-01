using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public Transform groundPoint;
    public ObjectPooler[] groundPooler;
    
    public ObjectPooler[] enemyPooler;
    
    private float[] groundWidths;
    
    public Transform minHeightPoint;
    public Transform maxHeightPoint;
    
    private CoinGenerator coinGenerator;
    private EnemyGenerator enemyGenerator;
    public LifeGenerator lifeGenerator;
    
    private float minY ;
    private float maxY ;
    
    public float minGap;
    public float maxGap;
    
    
    
    void Start()
    {
        groundWidths = new float[groundPooler.Length];
        minY = minHeightPoint.position.y;
        maxY = maxHeightPoint.position.y;
        coinGenerator = FindObjectOfType<CoinGenerator>();
        enemyGenerator = FindObjectOfType<EnemyGenerator>();
        lifeGenerator = FindObjectOfType<LifeGenerator>();
        
        for (int i = 0; i < groundPooler.Length; i++)
        {
            groundWidths[i] = groundPooler[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < groundPoint.position.x)
        {
            int randomIndex = Random.Range(0, groundPooler.Length);
            float distance = groundWidths[randomIndex] / 2;
            
            float gap = Random.Range(minGap, maxGap);
            float height = Random.Range(minY, maxY);
            
            transform.position = new Vector3(
                transform.position.x + distance + gap,
                height,
                transform.position.z);
            GameObject obj = groundPooler[randomIndex].GetPooledObject();
            obj.transform.position = transform.position;
            obj.SetActive(true);
            int random = Random.Range(0, 100);
            if (random < 60)
            {
                lifeGenerator.SpawnHealth(transform.position, groundWidths[randomIndex]);
                coinGenerator.SpawnCoins(transform.position, groundWidths[randomIndex]);
            }
            else
            {
                
                enemyGenerator.SpawnEnemies(transform.position, groundWidths[randomIndex]);
            }

            
            transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        }
        
    }
}
