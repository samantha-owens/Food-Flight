using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject pizza1;
    public GameObject pizza2;
    public GameObject pizza3;

    // Start is called before the first frame update
    void Start()
    {
        // starts alternating coroutines to make pizza throwing animation for title screen
        StartCoroutine(FlashPizza(pizza1, 0.5f, 0.5f, 1.25f));
        StartCoroutine(FlashPizza(pizza2, 1.0f, 0.5f, 0.75f));
        StartCoroutine(FlashPizza(pizza3, 1.5f, 0.5f, 0.25f));
    }

    // loads next scene and begins game, attached to the START button in UI
    public void LoadScene()
    {
        // resets player prefs
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Prototype 2");
    }

    IEnumerator FlashPizza(GameObject pizza, float timeA, float timeB, float timeC)
    {
        while (true)
        {
            yield return new WaitForSeconds(timeA);
            pizza.gameObject.SetActive(true);
            yield return new WaitForSeconds(timeB);
            pizza.gameObject.SetActive(false);
            yield return new WaitForSeconds(timeC);
        }
    }
}
