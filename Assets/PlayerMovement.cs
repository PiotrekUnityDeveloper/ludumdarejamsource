using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //TODO: sort these variables
    public float groundDistance;
    [SerializeField] private GameObject playerObj;
    public float jumpHeight;
    [SerializeField] private LayerMask groundLayer;
    public float moveleftspeed;
    public float moverightspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: strafing in air speed reduction + code cleanup
        //print(isGrounded());
        if((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && isGrounded())
        {
            playerObj.GetComponent<Rigidbody2D>().velocity = new Vector2(this.playerObj.GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            Debug.DrawRay(playerObj.transform.position, -Vector3.up, Color.green, groundDistance - 0.2f);

        }

        if (Input.GetKey(KeyCode.A)) //move left
        {
            if (playerObj.GetComponent<Rigidbody2D>().velocity.x < -4)
                return;

            playerObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(moveleftspeed * -1f, 0), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.D)) //move right
        {
            if (playerObj.GetComponent<Rigidbody2D>().velocity.x > 4)
                return;

            playerObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(moverightspeed * 1f, 0), ForceMode2D.Impulse);
        }

        //print(playerObj.GetComponent<Rigidbody2D>().velocity.x.ToString());
        Debug.DrawRay(playerObj.transform.position, -Vector3.up, Color.red, 0.01f);
    }

    public bool isGrounded()
    {
        Debug.DrawRay(playerObj.transform.position, -Vector3.up, Color.yellow, groundDistance - 0.2f);
        return Physics2D.Raycast(playerObj.transform.position, -Vector3.up, groundDistance + 0.1f, groundLayer);
    }
}
