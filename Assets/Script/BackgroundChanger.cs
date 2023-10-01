using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChanger : MonoBehaviour
{
    public float distance = 0f;
    public List<Shader> shaders;
    public MeshRenderer meshRenderer;
    
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        ChangeBackground();
    }

    // Update is called once per frame
    void Update()
    {
        distance += Time.deltaTime;
        if (distance > 10f)
        {
            distance = 0f;
            // ChangeBackground();
        }
    }
    
    void ChangeBackground()
    {
        // select a random background
        int index = Random.Range(0, shaders.Count);
    }
}
