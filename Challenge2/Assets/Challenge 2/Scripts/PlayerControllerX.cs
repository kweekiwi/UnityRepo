/*
 * (Kailie Otto)
 * (Challenge 2)
 * (Controls player ability to spawn dogs)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool delay;

    private void Start()
    {
        delay = false;
    }

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && !delay)
        {
            StartCoroutine(Dogs());
        }
    }
    IEnumerator Dogs()
    {
        delay = true;
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        //3 sec delay before start
        yield return new WaitForSeconds(.5f);
        delay = false;
       

    }
}
