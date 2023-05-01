using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpenBoss : MonoBehaviour
{
    bool enterNextScene = false;
    KeyCardManager keycardManager;
    // Start is called before the first frame update

    void Start()
    {
        keycardManager = FindObjectOfType<KeyCardManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (keycardManager.keycardCollect >= 4)
            {
                enterNextScene = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enterNextScene == true && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Boss");
        }
    }


}
