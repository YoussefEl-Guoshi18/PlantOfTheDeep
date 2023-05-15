using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorOpen2 : MonoBehaviour
{
    // Start is called before the first frame update
    bool enterNextScene = false;
    private AudioSource audioSource;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enterNextScene == true && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("P2");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            enterNextScene = true;
        }
    }

}
