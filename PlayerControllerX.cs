using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool isDogReady;

    void Start()
    {
        isDogReady = true;
    }

    void Update()
    {
        // On spacebar press, send a dog if a dog is ready.
        if (Input.GetKeyDown(KeyCode.Space) && isDogReady)
        {
            SendDog();
            isDogReady = false;
            StartCoroutine(GetDogReady());
        }
    }

    void SendDog()
    {
        Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
    }

    // A new dog is ready 0.66 seconds after sending the last dog.
    IEnumerator GetDogReady()
    {
        yield return new WaitForSeconds(0.66f);
        isDogReady = true;
    }
}