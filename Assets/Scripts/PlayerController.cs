using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager gameManager;
    public GameObject projectilePrefab;

    private float horizontalInput;
    private float verticalInput;

    [SerializeField] float speed = 15.0f;
    [SerializeField] float xRange = 15.0f;
    [SerializeField] float zTop = 15.0f;
    [SerializeField] float zBottom = 0.0f;

    public float flashingTime = .6f;
    public float timeInterval = .1f;

    private void Start()
    {
        // reference to the game manager script
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        LaunchProjectile();
    }

    // moves the player with the arrow keys, and restricts player from leaving the screen
    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        // restricts x axis range
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // restricts z axis range
        if (transform.position.z < zBottom)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBottom);
        }

        if (transform.position.z > zTop)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zTop);
        }
    }

    // if the spacebar is pressed, the player will throw a projectile
    void LaunchProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameManager.isPaused)
        {
            // Get an object from the pool
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = transform.position; // position it at player
            }
        }
    }

    // stores player flashing animation
    public void FlashingPlayer()
    {
        StartCoroutine(Flash(flashingTime, timeInterval));
    }

    // causes the player to flash for a short amount of time
    IEnumerator Flash(float time, float intervalTime)
    {
        float elapsedTime = 0f;

        // repeats flashing until the time alloted has elapsed
        while (elapsedTime < time)
        {
            Renderer[] RendererArray = GetComponentsInChildren<Renderer>();

            // turns off all renderers
            foreach (Renderer r in RendererArray)
                r.enabled = false;
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(intervalTime);

            // then turns them back on
            foreach (Renderer r in RendererArray)
                r.enabled = true;
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(intervalTime);
        }
    }
}
