using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuscr : MonoBehaviour
{
    public AudioSource mainmusic;
    public AudioSource menumusic;

    // Start is called before the first frame update
    void Start()
    {
        ///PlayerPrefs.DeleteAll(); //delete it later
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject menuobj;
    public void Showmenu()
    {
        if (menuobj.activeInHierarchy == false)
            return;

        menumusic.Stop();
        mainmusic.Play();

        menuobj.GetComponent<Animator>().SetTrigger("playmenu");
        Time.timeScale = 1;
        StartCoroutine(disablemenuscreen());
    }

    public IEnumerator disablemenuscreen()
    {
        yield return new WaitForSecondsRealtime(2f);
        menuobj.SetActive(false);
    }

    public void QuitGame()
    {
        //UnityEditor.PlayModeStateChange = UnityEditor.PlayModeStateChange.ExitingEditMode;
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
