using System.Collections;
/*
 * (Kailie Otto)
 * (Challenge 2)
 * (keeps track of score and displays in textbox)
 */
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
	public Text textbox;
	public int score;

    // Start is called before the first frame update
    void Start()
    {
		//ref to textbox
		textbox = GetComponent<Text>();
		textbox.text = "Score: " + 0;
    }

    
    // Update is called once per frame
    void Update()
    {
		textbox.text = "Score: " + score;
	}
}
