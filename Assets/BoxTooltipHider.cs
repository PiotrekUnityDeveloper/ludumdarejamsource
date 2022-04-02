using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTooltipHider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        candestroy = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public Animator anim;
    private bool candestroy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            //play the animation

            if (candestroy == false)
                return;

            anim.SetTrigger("jump");

            Destroy(anim.gameObject, 7);
            candestroy = false;
        }

        
    }

    
}
