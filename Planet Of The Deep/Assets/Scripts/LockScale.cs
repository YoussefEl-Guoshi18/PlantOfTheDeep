using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockScale : MonoBehaviour
{
    // Start is called before the first frame update
    public float scaleX = 0.2f;
    public float scaleY = 0.2f;

    void Awake()
    {
        this.transform.localScale = new Vector3(0.2f, 0.2f, 0);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
