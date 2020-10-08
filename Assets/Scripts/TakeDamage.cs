using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TakeDamage : MonoBehaviour
{
    GameManager gameManager;
    PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        // references to the game manager and player controller scripts
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // when a dog hits the player a life is lost and the player flashes
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.LoseLife();
            playerController.FlashingPlayer();
        }
    }

}
