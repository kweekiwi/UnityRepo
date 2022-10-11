/*
 * (Kailie Otto)
 * (Assignment 5A)
 * (Displays "You Win" when triggerzone is entered)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Text win;
    // Start is called before the first frame update
    void Start()
    {
        win = GameObject.FindGameObjectWithTag("YouWin").GetComponent<Text>();
        win.text = " ";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        win.text = "You Win!";
    }
}
