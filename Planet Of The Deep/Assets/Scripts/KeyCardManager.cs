using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class KeyCardManager : MonoBehaviour
{
    public static KeyCardManager instance;
    public int keycardCollect = 0;

    private AudioSource audioSource;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   public void UpdateKeyCard()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        keycardCollect++;
    }
}





