using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    
    public Renderer backgroundRenderer;
    public bool scrollEnabled = false;
    public GameObject background;
    
    // Start is called before the first frame update
    void Start()
    {
        backgroundRenderer = background.GetComponent<Renderer>();
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (scrollEnabled)
        {
            backgroundRenderer.material.mainTextureOffset += new Vector2(0.1f * Time.deltaTime, 0f);
        }
    }
}
