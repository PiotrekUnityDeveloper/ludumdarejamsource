using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public List<GameObject> reloadableObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    //relies on PlayerPrefs :)
    public void SaveLocalGame(bool onlyPlayer)
    {
        if(onlyPlayer)
        {
            //player velocity
            PlayerPrefs.SetFloat("playerXvel", player.GetComponent<Rigidbody2D>().velocity.x);
            PlayerPrefs.SetFloat("playerYvel", player.GetComponent<Rigidbody2D>().velocity.y);

            //player position
            PlayerPrefs.SetFloat("playerXpos", player.transform.position.x);
            PlayerPrefs.SetFloat("playerYpos", player.transform.position.y);

            //player rotation (Z only)
            PlayerPrefs.SetFloat("playerZrot", player.transform.rotation.z);

            //we dont need scaling and other stuff saved for now
        }
        else
        {
            //save other stuff too
            //player first

            //player velocity
            PlayerPrefs.SetFloat("playerXvel", player.GetComponent<Rigidbody2D>().velocity.x);
            PlayerPrefs.SetFloat("playerYvel", player.GetComponent<Rigidbody2D>().velocity.y);

            //player position
            PlayerPrefs.SetFloat("playerXpos", player.transform.position.x);
            PlayerPrefs.SetFloat("playerYpos", player.transform.position.y);

            //player rotation (Z only)
            PlayerPrefs.SetFloat("playerZrot", player.transform.rotation.z);

            //we dont need scaling and other stuff saved for now

            //now save other stuff

            foreach(GameObject g in reloadableObjects)
            {
                //position
                PlayerPrefs.SetFloat(g.name + "Xpos", g.transform.position.x);
                PlayerPrefs.SetFloat(g.name + "Ypos", g.transform.position.y);

                //rotation


                //velocity

                //is object enabled

                //rb settings
            }
        }
    }

    public void LoadLocalGame(bool noPlayer)
    {

    }
}
