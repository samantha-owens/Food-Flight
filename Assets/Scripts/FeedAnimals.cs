using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedAnimals : MonoBehaviour
{
    GameManager gameManager;

    public Slider hungerSlider;
    public int amountToBeFed;
    public int currentFedAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // reference to game manager script
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        // set the hunger bar's starting value and how much it needs to be filled
        hungerSlider.maxValue = amountToBeFed;
        hungerSlider.value = 0;
        hungerSlider.fillRect.gameObject.SetActive(false);
    }

    // when a food object hits an animal, the hunger slider is filled up by 1
    public void FeedAnimal(int amount)
    {
        currentFedAmount += amount;
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = currentFedAmount;

        // when a hunger bar is full, a point is added to the score and the animal disappears
        if (currentFedAmount >= amountToBeFed)
        {
            gameManager.AddScore();
            Destroy(gameObject);
        }
    }

    // when an animal collides with a food object, the animal is fed
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Food"))
        {
            FeedAnimal(1);
            // the food is deactivated and added back to object pool
            other.gameObject.SetActive(false);
        }
    }
}
