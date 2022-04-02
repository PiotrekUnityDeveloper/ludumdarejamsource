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
        if (Input.GetKeyDown(KeyCode.R))
        {
            SaveLocalGame(true); //CHANGE TO FALSE LATER
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            LoadLocalGame();
        }
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

                //rotation (Z only)
                PlayerPrefs.SetFloat(g.name + "Zrot", g.transform.rotation.z);

                //velocity
                PlayerPrefs.SetFloat(g.name + "Xvel", g.GetComponent<Rigidbody2D>().velocity.x);
                PlayerPrefs.SetFloat(g.name + "Yvel", g.GetComponent<Rigidbody2D>().velocity.y);

                //is object enabled
                PlayerPrefs.SetInt(g.name + "enabled", (g.activeInHierarchy ? 1 : 0));
                ///getting the bool code:
                ///bool getenabled = PlayerPrefs.GetInt(g.name + "enabled", 0) > 0;

                //rb settings
                PlayerPrefs.SetFloat(g.name + "gravity", g.GetComponent<Rigidbody2D>().gravityScale); //object's grav
                //more code here
                //add tag and layermask support later 
            }

        }
    }

    public void LoadLocalGame()
    {
        //loading player position 
        player.transform.position = new Vector2(PlayerPrefs.GetFloat("playerXpos", 0), PlayerPrefs.GetFloat("playerYpos", 0));
        //loading player rotation
        player.transform.rotation = Quaternion.Euler(player.transform.rotation.x, player.transform.rotation.y, PlayerPrefs.GetFloat("playerZrot", 0));
        //loading player velocity
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(PlayerPrefs.GetFloat("playerXvel", 0), PlayerPrefs.GetFloat("playerYvel", 0));
        //done for the player
    }
}
