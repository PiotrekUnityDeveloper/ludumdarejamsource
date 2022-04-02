using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public GameObject player;
    public Vector3 camoffset;

    public float camsmoothing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Rigidbody2D>().velocity.x <= 0) 
        {
            this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, player.GetComponent<Rigidbody2D>().velocity.x * 1f);
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, player.GetComponent<Rigidbody2D>().velocity.x * 1f);
        }


        //update offset here
        /* x offset */ camoffset = new Vector3(player.GetComponent<Rigidbody2D>().velocity.x * 0.1f, camoffset.y, camoffset.z);
        /* y offset */ camoffset = new Vector3(camoffset.x, player.GetComponent<Rigidbody2D>().velocity.y * 0.1f, camoffset.z);
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = player.transform.position + camoffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, camsmoothing);
        transform.position = smoothedPosition;

        //transform.LookAt(target);
    }
}
