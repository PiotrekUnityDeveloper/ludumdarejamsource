using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public GameObject player;
    public Vector3 camoffset;

    public int cammode = 1;

    //camera holders
    public GameObject lv1hold;

    public float camsmoothing;

    private float targetsize;
    private float targetrotation;
    private bool isbigger;
    private bool zoom;
    //rotation utils
    private bool isrotbigger;
    private bool rotate;
    // Start is called before the first frame update
    void Start()
    {
        cammode = 1;
        desiredSize = 0.001f;
    }

    // Update is called once per frame
    void Update()
    {
        camoffset = new Vector3(0, 0, -10);

        if(cammode == 1)
        {
            if (player.GetComponent<Rigidbody2D>().velocity.x <= 0)
            {
                this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, player.GetComponent<Rigidbody2D>().velocity.x * 1f);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, player.GetComponent<Rigidbody2D>().velocity.x * 1f);
            }


            //update offset here
            /* x offset */
            camoffset = new Vector3(player.GetComponent<Rigidbody2D>().velocity.x * 0.1f, camoffset.y, camoffset.z);
            /* y offset */
            camoffset = new Vector3(camoffset.x, player.GetComponent<Rigidbody2D>().velocity.y * 0.1f, camoffset.z);
        }

        desiredSize = 0.01f;
        //zooming code rh
        if (isbigger == true && zoom == true)
        {
            if (this.GetComponent<Camera>().orthographicSize < targetsize)
            {
                this.GetComponent<Camera>().orthographicSize += desiredSize;
                desiredSize *= 1.25f;
            }
            else if (this.GetComponent<Camera>().orthographicSize >= targetsize)
            {
                zoom = false;
                //zoomed in! :D
            }
        }
        else if (isbigger == false && zoom == true)
        {
            if (this.GetComponent<Camera>().orthographicSize > targetsize)
            {
                this.GetComponent<Camera>().orthographicSize -= desiredSize;
                desiredSize *= 1.25f;
            }
            else if (this.GetComponent<Camera>().orthographicSize <= targetsize)
            {
                zoom = false;
                //zoomed out! :D
            }
        }

        desiredSize = 0.01f;

        //rotating code here
        if (isrotbigger == true && rotate == true)
        {
            if (this.transform.rotation.z < targetrotation)
            {
                this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z + desiredSize);
                //desiredSize *= 1.25f;
            }
            else if (this.transform.rotation.z >= targetrotation)
            {
                rotate = false;
                print("finished rotating");
                //rotation ends here
            }
        }
        else if (isrotbigger == false && rotate == true)
        {
            if (this.transform.rotation.z > targetrotation)
            {
                this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z - desiredSize);
                //desiredSize *= 1.25f;
            }
            else if (this.transform.rotation.z <= targetrotation)
            {
                rotate = false;
                print("finished rotating");
                //rotation ends here
            }
        }
    }

    private float desiredSize = 0.01f;

    private void LateUpdate()
    {

        

        if (cammode == 1)
        {
            Vector3 desiredPosition = player.transform.position + camoffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, camsmoothing);
            transform.position = smoothedPosition;

            //transform.LookAt(target);
        }
        else if(cammode == 2)
        {
            //SETS THE POSITION OF THE TARGET OBJECT
            Vector3 desiredPosition = lv1hold.transform.position + camoffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, camsmoothing);
            transform.position = smoothedPosition;
            /*
            if(desiredSize < 7.55f) //7.55f is target size for cammode 2
            {
                desiredSize += 0.05f;
            }
            */
           // this.GetComponent<Camera>().orthographicSize = desiredSize;
        }


    }

    public void SwitchedMode(int modeid)
    {
        print("test");
        if (cammode == modeid)
            return;

        print("siema");

        if (modeid == 2) //big cam
        {
            //SETS THE CAMERA ZOOM FOR THE SPECIFIC MODE
            targetsize = 10f;
            targetrotation = 0f;
        }
        else if (modeid == 1) //default
        {
            targetsize = 5.5f;
            targetrotation = 0f;
        }

        if (targetsize > this.GetComponent<Camera>().orthographicSize)
        {
            isbigger = true;
        }
        else
        {
            isbigger = false;
        }

        if(targetrotation > this.transform.rotation.z)
        {
            isrotbigger = true;
        }
        else
        {
            isrotbigger = false;
        }

        zoom = true;
        rotate = true;

        //StartCoroutine(TimedSmoothing()); even smoother transition
    }

    public IEnumerator TimedSmoothing()
    {
        camsmoothing = 0.0125f;
        yield return new WaitForSecondsRealtime(0.3f);
        camsmoothing = 0.0512f;
        yield return new WaitForSecondsRealtime(0.6f);
        camsmoothing = 0.0640f;
        yield return new WaitForSecondsRealtime(0.8f);
        camsmoothing = 0.64f;
        yield return new WaitForSecondsRealtime(0.9f);
        camsmoothing = 0.95f;
        yield return new WaitForSecondsRealtime(1f);
        camsmoothing = 0.128f;
    }
}
