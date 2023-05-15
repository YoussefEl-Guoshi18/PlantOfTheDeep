using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class DoorOpen : MonoBehaviour
{
    bool enterNextScene = false;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enterNextScene = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enterNextScene == true && Input.GetKeyDown(KeyCode.Return))
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            SceneManager.LoadScene("P1");
        }
    }


}
