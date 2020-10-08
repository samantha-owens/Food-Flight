using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        // moves animals and dogs down the screen
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
