using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
    
    private GameObject groundDestroyPoint;
    // Start is called before the first frame update
    void Start()
    {
        groundDestroyPoint = GameObject.Find("DestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < groundDestroyPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
        
    }
}
