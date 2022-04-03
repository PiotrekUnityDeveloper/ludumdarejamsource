using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandboxManager : MonoBehaviour
{
    public GameObject optioncanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            ApplyChanges();
            optioncanvas.SetActive(!optioncanvas.activeInHierarchy);
            ApplyChanges();
        }

        
    }

    public Slider movespeedRight;
    public Slider movespeedLeft;
    public Slider jumpheight;
    public Slider gravitystrenghtX;
    public Slider gravitystrenghtY;
    public Toggle gravity;

    public void ApplyChanges()
    {
        if (optioncanvas.activeInHierarchy == false)
            return;

        if (gravity.isOn == false)
        {
            gravitystrenghtY.value = 0;
        }

        //modifying physics
        Physics.gravity = new Vector2(gravitystrenghtX.value, gravitystrenghtY.value);
        print(Physics.gravity.x + " - x gravity");
        print(Physics.gravity.y + " - y gravity");

        if(gravity.isOn == false)
        {
            Physics.gravity = new Vector2(0, 0);
        }

        GameObject.Find("Player").GetComponent<PlayerMovement>().moveleftspeed = movespeedLeft.value;
        GameObject.Find("Player").GetComponent<PlayerMovement>().moverightspeed = movespeedRight.value;
        GameObject.Find("Player").GetComponent<PlayerMovement>().jumpHeight = jumpheight.value;

        Rigidbody2D[] rb;
        rb = GameObject.FindObjectsOfType<Rigidbody2D>();
        foreach(Rigidbody2D rb2d in rb)
        {
            rb2d.gravityScale = gravitystrenghtY.value;
            
        }
    }
}
