using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class DoorOpenBoss : MonoBehaviour
{
    bool enterNextScene = false;
    public Text lockedMessage;
    KeyCardManager keycardManager;

    private AudioSource audioSource;
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
            else
            {
                StartCoroutine(ShowLockedMessage());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (enterNextScene == true && Input.GetKeyDown(KeyCode.Return))
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            SceneManager.LoadScene("Boss");
        }
    }

    IEnumerator ShowLockedMessage()
    {
        lockedMessage.text = "LOCKED";
        yield return new WaitForSeconds(1.5f);
        lockedMessage.text = "";
    }
}
