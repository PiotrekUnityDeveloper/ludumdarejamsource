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
            optioncanvas.SetActive(!optioncanvas.activeInHierarchy);
        }

        ApplyChanges();
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

        //modifying physics
        Physics.gravity = new Vector2(gravitystrenghtX.value, gravitystrenghtY.value);

        if(gravity.isOn == false)
        {
            Physics.gravity = new Vector2(0, 0);
        }

        GameObject.Find("Player").GetComponent<PlayerMovement>().moveleftspeed = movespeedLeft.value;
        GameObject.Find("Player").GetComponent<PlayerMovement>().moverightspeed = movespeedRight.value;
        GameObject.Find("Player").GetComponent<PlayerMovement>().jumpHeight = jumpheight.value;
    }
}
