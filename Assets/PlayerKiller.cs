using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKiller : MonoBehaviour
{
    public bool triggerdetect;
    public bool collisiondetect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject gameoverscreen;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisiondetect == false)
            return;

        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("music").GetComponent<AudioSource>().Stop();
            Time.timeScale = 0;
            gameoverscreen.SetActive(true);
            PlayerPrefs.SetInt("Death", 1);
            StartCoroutine(restart());
        }
    }

    public IEnumerator restart()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerdetect == false)
            return;

        if (collision.gameObject.tag == "Player")
        {
            GameObject.Find("music").GetComponent<AudioSource>().Stop();
            Time.timeScale = 0;
            gameoverscreen.SetActive(true);
            PlayerPrefs.SetInt("Death", 1);
            StartCoroutine(restart());
        }
    }
}
