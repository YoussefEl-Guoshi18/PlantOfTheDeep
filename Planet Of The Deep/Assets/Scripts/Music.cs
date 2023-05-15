using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    private AudioSource _audioSource;

    private void Awake()
    {
        GameObject[] musicobj = GameObject.FindGameObjectsWithTag("Music");// Allows the music to play while you are moving through the scenes.
        if (musicobj.Length > 1)// Prevents the music overlapping over the same music.
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
