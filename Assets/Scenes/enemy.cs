using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public LayerMask playermask;
    public bool move;
    private Vector2 lockedpos;
    public GameObject player;
    public float maxfollowdist;

    public float detectionrange;
    public float rotaddiction = 0;

    public bool isdashingenemy;

    // Start is called before the first frame update
    void Start()
    {
        lockedpos = this.transform.position;
        //move = false;
        StartCoroutine(delaylockedpossetter());
    }

    // Update is called once per frame
    void Update()
    {
        if (move == false)
        {
            this.transform.position = lockedpos;
        }

        //detectplayer();
    }

    //public static RaycastHit2D rh;

    private void FixedUpdate()
    {
        fixeddetection();
    }

    public void fixeddetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, detectionrange);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, Vector2.left);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position, Vector2.up);
        RaycastHit2D hit4 = Physics2D.Raycast(transform.position, Vector2.down);

        Debug.DrawLine(this.transform.position, player.transform.position, Color.blue, 0.01f);

        move = false;

        if(hit.collider.gameObject.tag == "Player" && hit.collider.gameObject.layer == 3) //found a player!
        {
            move = true;
        }

        if (hit2.collider.gameObject.tag == "Player" && hit.collider.gameObject.layer == 3) //found a player!
        {
            move = true;
        }

        if (hit3.collider.gameObject.tag == "Player" && hit.collider.gameObject.layer == 3) //found a player!
        {
            move = true;
        }

        if (hit4.collider.gameObject.tag == "Player" && hit.collider.gameObject.layer == 3) //found a player!
        {
            move = true;
        }

        //done i think
    }

    public void detectplayer()
    {
        
        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z - 90);
        RaycastHit2D rh = Physics2D.Raycast(this.transform.position, transform.right, detectionrange, 1, playermask);
        //this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z - 90);
        //Vector3 direction = player.transform.position - transform.position;
        Debug.DrawLine(this.transform.position, player.transform.position, Color.black, 1);
        Debug.DrawRay(this.transform.position, player.transform.position, Color.gray, 0.2f);

        Debug.DrawLine(this.transform.position, this.transform.right, Color.white, 0.1f);

        //print(rh.collider.gameObject.name);

        if (rh.collider != null)
        {
            if(rh.collider.gameObject.tag == "Player" || rh.collider.gameObject.name == "Player")
            {
                move = true;
                print(rh.collider.gameObject.name);
            }
        }
        else
        {
            
            //move = false;
        }

        if(move == true)
        {
            if(Vector2.Distance(this.transform.position, player.transform.position) > maxfollowdist)
            {
                //move = false;
            }

        }

        if(Vector2.Distance(this.transform.position, player.transform.position) < 5)
        {
            StartCoroutine(dash());
            move = false;
            StartCoroutine(delaymovement());
        }
    }

    public IEnumerator dash()
    {
        for(int i = 0; i < 2; i++)
        {
            yield return new WaitForSecondsRealtime(0.4f);
            this.transform.position = transform.up * -0.1f;
            Debug.Log("dashing!");
        }
    }

    public IEnumerator delaymovement()
    {
        yield return new WaitForSecondsRealtime(1.9f);
        move = true;
    }

    public IEnumerator delaylockedpossetter()
    {
        yield return new WaitForSecondsRealtime(1);
        lockedpos = this.transform.position;
        StartCoroutine(delaylockedpossetter());
    }
}
