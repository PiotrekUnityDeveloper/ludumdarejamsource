using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class enemy : MonoBehaviour
{
    public LayerMask playermask;
    public bool move;
    private Vector2 lockedpos;

    public bool fall;

    public GameObject player;
    public float maxfollowdist;

    public float detectionrange;
    public float rotaddiction = 0;

    public bool isdashingenemy;

    //should the y movement be always unlocked?
    public bool yUnlocked;
    public bool gravitational;

    // Start is called before the first frame update
    void Start()
    {
        lockedpos = this.transform.position;
        move = false;
        StartCoroutine(delaylockedpossetter());
    }

    // Update is called once per frame
    void Update()
    {
        if (move == false && yUnlocked == false)
        {
            this.transform.position = lockedpos;
        }
        else if (move == false && yUnlocked == true)
            {
                this.transform.position = new Vector2(lockedpos.x, this.transform.position.y);
            }

        detectplayer();
        //fixeddetection();
    }

    //public static RaycastHit2D rh;

    private void FixedUpdate()
    {
        //fixeddetection();

        if (this.gameObject.GetComponent<CircleCollider2D>().IsTouchingLayers(6) == false)
        {
            fall = true;
            //grav = 0; cant modify it every frame
        }
    }

    public void fixeddetection()
    {
        Vector2 desiredDir;
        desiredDir = player.transform.position-this.transform.position;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, desiredDir, detectionrange);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position, desiredDir);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position, Vector2.up);
        RaycastHit2D hit4 = Physics2D.Raycast(transform.position, Vector2.down);

        Debug.DrawLine(this.transform.position, player.transform.position, Color.blue, 0.01f);
        Debug.DrawRay(new Vector2(this.transform.position.x, this.transform.position.y + 10), player.transform.position, Color.black, 0.05f);

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

        print(move);
    }

    public float grav;

    public void detectplayer()
    {
        if(gravitational == true && fall == true)
        {
            this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - grav);
            grav += 0.05f;
            //yes
        }


        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z - 90);
        RaycastHit2D rh = Physics2D.Raycast(this.transform.position, Vector2.down, detectionrange, playermask);
        RaycastHit2D rh2 = Physics2D.Raycast(this.transform.position, Vector2.up, detectionrange, playermask);
        RaycastHit2D rh3 = Physics2D.Raycast(this.transform.position, Vector2.right, detectionrange, playermask);
        RaycastHit2D rh4 = Physics2D.Raycast(this.transform.position, Vector2.left, detectionrange, playermask);
        RaycastHit2D rh5 = Physics2D.Raycast(this.transform.position, transform.forward, detectionrange, playermask);
        RaycastHit2D rh6 = Physics2D.Raycast(this.transform.position, transform.up, detectionrange, playermask);
        RaycastHit2D rh7 = Physics2D.Raycast(this.transform.position, transform.right, detectionrange, playermask);
        //this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z - 90);
        //Vector3 direction = player.transform.position - transform.position;
        // Debug.DrawLine(this.transform.position, player.transform.position, Color.black, 1);
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

        if (rh2.collider != null)
        {
            if (rh2.collider.gameObject.tag == "Player" || rh2.collider.gameObject.name == "Player")
            {
                move = true;
                print(rh2.collider.gameObject.name);
            }
        }
        else
        {

            //move = false;
        }

        if (rh3.collider != null)
        {
            if (rh3.collider.gameObject.tag == "Player" || rh3.collider.gameObject.name == "Player")
            {
                move = true;
                print(rh3.collider.gameObject.name);
            }
        }
        else
        {

            //move = false;
        }

        if (rh4.collider != null)
        {
            if (rh4.collider.gameObject.tag == "Player" || rh4.collider.gameObject.name == "Player")
            {
                move = true;
                print(rh4.collider.gameObject.name);
            }
        }
        else
        {

            //move = false;
        }

        if (rh5.collider != null)
        {
            if (rh5.collider.gameObject.tag == "Player" || rh5.collider.gameObject.name == "Player")
            {
                move = true;
                print(rh5.collider.gameObject.name);
            }
        }
        else
        {

            //move = false;
        }

        if (rh6.collider != null)
        {
            if (rh6.collider.gameObject.tag == "Player" || rh6.collider.gameObject.name == "Player")
            {
                move = true;
                print(rh6.collider.gameObject.name);
            }
        }
        else
        {

            //move = false;
        }

        if (rh7.collider != null)
        {
            if (rh7.collider.gameObject.tag == "Player" || rh7.collider.gameObject.name == "Player")
            {
                move = true;
                print(rh7.collider.gameObject.name);
            }
        }
        else
        {

            //move = false;
        }

        if (move == true)
        {
            if(Vector2.Distance(this.transform.position, player.transform.position) > maxfollowdist)
            {
                move = false;
            }

        }

        if(Vector2.Distance(this.transform.position, player.transform.position) < 5 && isdashingenemy == true)
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
            this.transform.position = transform.forward * -0.1f;
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

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public GameObject gameoverscreen;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject.Find("music").GetComponent<AudioSource>().Stop();
            Time.timeScale = 0;
            gameoverscreen.SetActive(true);
            PlayerPrefs.SetInt("Death", 1);
            StartCoroutine(restart());
        }
    }

    public IEnumerator restart()
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            fall = false;
            grav = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            fall = true;
            grav = 0;
        }
    }
}
