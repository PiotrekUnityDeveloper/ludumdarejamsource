using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEnabler : MonoBehaviour
{
    [SerializeField] private List<GameObject> items2enable = new List<GameObject>();
    public bool setactive = true;
    public bool onlyplayer = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && onlyplayer == true) return;

        foreach(GameObject item in items2enable)
        {
            item.SetActive(setactive);
        }
    }
}
