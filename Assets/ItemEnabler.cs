using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEnabler : MonoBehaviour
{
    [SerializeField] private List<GameObject> items2enable = new List<GameObject>();
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
        foreach(GameObject item in items2enable)
        {
            item.SetActive(true);
        }
    }
}
