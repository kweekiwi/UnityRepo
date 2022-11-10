using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class immunity : MonoBehaviour
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
        playerPlatformerControllerScript.invincible = true;
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<BoxCollider2D>());
        Debug.Log("Invincible for 10 seconds!");
        yield return new WaitForSeconds(waitTime);
        playerPlatformerControllerScript.invincible = false;
        Destroy(gameObject);
        print("Coroutine ended: " + Time.time + " seconds");
    }
}
