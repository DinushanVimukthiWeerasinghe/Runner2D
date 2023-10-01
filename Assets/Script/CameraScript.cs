using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Player player;
    private Camera camera;
    private Vector3 offset; // Last known position of the player
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        offset = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.transform.position.x - offset.x;
        transform.position = new Vector3(transform.position.x + distance, transform.position.y, transform.position.z);
        offset = player.transform.position;
        
        
    }
}
