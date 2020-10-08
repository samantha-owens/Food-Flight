using System.Collections;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] float topBound = 30;
    [SerializeField] float lowerBound = -5;
    [SerializeField] float sideBound = 30;

    // Start is called before the first frame update
    void Start()
    {
        // reference to the game manager script
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        // if object goes past a player's gameview, remove object
        if (transform.position.z > topBound)
        {
            // deactives pizza for object pool
            gameObject.SetActive(false);
        }
        else if (transform.position.x > sideBound)
        {
            // destroys dogs off screen
            Destroy(gameObject);
        }
        else if (transform.position.x < -sideBound)
        {
            // destroys dogs off screen
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            // if an animal makes it past a player without being fed, player loses a life
            gameManager.LoseLife();
            Destroy(gameObject);
        }
    }
}
