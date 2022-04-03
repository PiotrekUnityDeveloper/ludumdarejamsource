using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialscr : MonoBehaviour
{
    public GameObject tutorialborder;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(delayborders());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator delayborders()
    {
        yield return new WaitForSecondsRealtime(15f);
        tutorialborder.SetActive(false);
    }
}
