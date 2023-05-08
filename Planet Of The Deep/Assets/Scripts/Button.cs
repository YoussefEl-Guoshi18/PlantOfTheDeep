using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    public UnityEvent buttonClick;
    public Sprite btnDown;
    public Sprite btnUp;

    void Awake()
    {
        if (buttonClick == null)
        {
            buttonClick = new UnityEvent();// Allows button to perform an action when clicked.
        }
    }

    void OnMouseUp()
    {
        buttonClick.Invoke();
        this.GetComponent<SpriteRenderer>().sprite = btnUp;
    }

    void OnMouseDown()
    {
        this.GetComponent<SpriteRenderer>().sprite = btnDown;// When the button is held down the sprite changes.
    }
}
