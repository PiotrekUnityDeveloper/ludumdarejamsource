using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public int targetmode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ///GameObject.Find("MainCamera").GetComponent<CamControl>().cammode = targetmode;
            ///GameObject.Find("MainCamera").GetComponent<CamControl>().SwitchedMode(targetmode);

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamControl>().SwitchedMode(targetmode);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamControl>().cammode = targetmode;
            ///GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamControl>().SwitchedMode(targetmode);
            ///GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamControl>().SwitchedMode(targetmode);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ///GameObject.Find("MainCamera").GetComponent<CamControl>().cammode = targetmode;
            ///GameObject.Find("MainCamera").GetComponent<CamControl>().SwitchedMode(targetmode);

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamControl>().SwitchedMode(targetmode);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CamControl>().cammode = targetmode;
            
        }
    }
}
