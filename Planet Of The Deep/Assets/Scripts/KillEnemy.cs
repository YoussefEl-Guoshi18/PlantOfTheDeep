using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    BoxCollider2D bc;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            bc = enemy.GetComponent<BoxCollider2D>();
            bc.enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;

        }
    }
}
