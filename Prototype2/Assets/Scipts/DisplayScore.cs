/*
 * (Kailie Otto)
 * (Prototype 2)
 * (Controls textbox that displays score)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text textbox;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        //set up ref to text component
        textbox = GetComponent<Text>();
        textbox.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        textbox.text = "Score: " + score;
    }
}
