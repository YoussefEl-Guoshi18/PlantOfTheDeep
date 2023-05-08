using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    //public AudioSource clickSound;

    public static void Changescene(string sceneName) //This method is assigned with the button, whenever the button is clicked it changes from one scene to another.
    {
        //clickSound.Play();
        //DontDestroyOnLoad(clickSound.transform.gameObject);
        SceneManager.LoadScene(sceneName);
    }

    public static void Quit()// The application will close.
    {
        Application.Quit();
    }
}
