using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuscr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject menuobj;
    public void Showmenu()
    {
        menuobj.GetComponent<Animator>().SetTrigger("playmenu");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        //UnityEditor.PlayModeStateChange = UnityEditor.PlayModeStateChange.ExitingEditMode;
        Application.Quit();
    }
}
