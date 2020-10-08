using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float timer;
    private float timeElapsed;
    private bool timerStarted = false;
    public float reloadTime = 3.0f;


    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && timerStarted == false)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            timer = Time.time; // timer set
            timerStarted = true; // timer started
        }

        if (timerStarted == true) // if the timer is started
        {
            timeElapsed = Time.time - timer; // counts the time elapsed
            if (timeElapsed >= reloadTime) // if the time elapsed equals reload time
            {
                timerStarted = false; // end timer
            }
        }
    }

}
