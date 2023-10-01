using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    private GameObject enemyDestroyPoint;
    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        enemyDestroyPoint = GameObject.Find("DestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < enemyDestroyPoint.transform.position.x)
        {
            // rest the rotation of the enemy
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.position = startPosition;
            gameObject.SetActive(false);
        }
        
    }
}
