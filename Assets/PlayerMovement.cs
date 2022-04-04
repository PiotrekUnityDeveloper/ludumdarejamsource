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

    public bool universaljumpval = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(checkforcollairjump());
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && universaljumpval == true) //for airjump blocks
        {
            playerObj.GetComponent<Rigidbody2D>().velocity = new Vector2(this.playerObj.GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            Debug.DrawRay(playerObj.transform.position, -Vector3.up, Color.green, groundDistance - 0.2f);

        }

        //TODO: strafing in air speed reduction + code cleanup
        //print(isGrounded());
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && isGrounded())
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

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && universaljumpval == true) //for airjump blocks
        {
            playerObj.GetComponent<Rigidbody2D>().velocity = new Vector2(this.playerObj.GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            Debug.DrawRay(playerObj.transform.position, -Vector3.up, Color.green, groundDistance - 0.2f);

        }

        //print(playerObj.GetComponent<Rigidbody2D>().velocity.x.ToString());
        Debug.DrawRay(playerObj.transform.position, -Vector3.up, Color.red, 0.01f);
    }

    public bool isGrounded()
    {
        Debug.DrawRay(playerObj.transform.position, -Vector3.up, Color.yellow, groundDistance - 0.2f);
        return Physics2D.Raycast(playerObj.transform.position, -Vector3.up, groundDistance + 0.1f, groundLayer);
    }


    private void OnTriggerEnter(Collider other)
    {
        
    }

    public IEnumerator checkforcollairjump()
    {
        yield return new WaitForSecondsRealtime(1);

        if(this.gameObject.GetComponent<BoxCollider2D>().IsTouchingLayers(8) == false)
        {
            universaljumpval = false;
        }

        if (this.gameObject.GetComponent<BoxCollider2D>().IsTouchingLayers(8) == true)
        {
            universaljumpval = true;
        }

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && universaljumpval == true) //for airjump blocks
        {
            playerObj.GetComponent<Rigidbody2D>().velocity = new Vector2(this.playerObj.GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
            Debug.DrawRay(playerObj.transform.position, -Vector3.up, Color.green, groundDistance - 0.2f);

        }

        StartCoroutine(checkforcollairjump());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "airjump")
        {
            universaljumpval = true;
        }
        else
        {
            universaljumpval = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "airjump")
        {
            universaljumpval = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "airjump")
        {
            universaljumpval = false;
        }
    }
}
