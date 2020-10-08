using System.Collections;
using UnityEngine;

public class GainHealth : MonoBehaviour
{
    GameManager gameManager;

    void Start()
    {
        // reference to the game manager script
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // starts coroutine that makes the health objects dissapear after some time
        StartCoroutine(DestroyAfterTime());
    }

    // if the player collides with a health object, they gain a life
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.GainLife();
            Destroy(gameObject);
        }
    }

    // if the health object isn't used in 10 seconds, the health object disappears
    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
