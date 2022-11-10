using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushPower : MonoBehaviour
{
    private IEnumerator coroutine;

    public GameObject fox;
    private PlayerPlatformerController playerPlatformerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerPlatformerControllerScript = fox.GetComponent<PlayerPlatformerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        coroutine = WaitAndPrint(10.0f);
        StartCoroutine(coroutine);
    }


    private IEnumerator WaitAndPrint(float waitTime)
    {
        playerPlatformerControllerScript.maxSpeed += 5;
        //for the time one, here I would ++ time in the timer script
        //instead of max speed increase, but destroys would be the same
        //won't need wait for seconds so coroutine is unnecessary yay
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<BoxCollider2D>());
        Debug.Log("Speed boast for 10 seconds!");
        yield return new WaitForSeconds(waitTime);
        playerPlatformerControllerScript.maxSpeed -= 5;
        Destroy(gameObject);
        print("Coroutine ended: " + Time.time + " seconds");
    }

}
