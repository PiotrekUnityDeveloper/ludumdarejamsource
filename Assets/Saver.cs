using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
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

        //cam pos
        PlayerPrefs.SetFloat("cameraXpos", camera.transform.position.x);
        PlayerPrefs.SetFloat("cameraYpos", camera.transform.position.y);

        //cam rot
        PlayerPrefs.SetFloat("cameraZrot", camera.transform.rotation.z);

        //cam offsets
        PlayerPrefs.SetFloat("cameraXoffset", camera.GetComponent<CamControl>().camoffset.x);
        PlayerPrefs.SetFloat("cameraYoffset", camera.GetComponent<CamControl>().camoffset.y);
        //Z offset is always set to -10 so no need to save it
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
        //now other stuff

        foreach (GameObject g in reloadableObjects)
        {
            //other stuff
            g.transform.position = new Vector2(PlayerPrefs.GetFloat(g.name + "Xpos", 0), PlayerPrefs.GetFloat(g.name + "Ypos", 0));
            //now rotation
            g.transform.rotation = Quaternion.Euler(g.transform.rotation.x, g.transform.rotation.y, PlayerPrefs.GetFloat(g.name + "Zrot", 0));
            //velocity
            g.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(PlayerPrefs.GetFloat(g.name + "Xvel", 0), PlayerPrefs.GetFloat(g.name + "Yvel", 0));
            //and finally, the gravity
            g.GetComponent<Rigidbody2D>().gravityScale = PlayerPrefs.GetFloat(g.name + "gravity", 0);
            //is the object enabled?
            //retrieve the bool first
            bool b = PlayerPrefs.GetInt(g.name + "enabled", 0) > 0;
            g.gameObject.SetActive(b); //setting the object to the variable val
        }

        //camera
        //load position of the camera
        camera.transform.position = new Vector2(PlayerPrefs.GetFloat("cameraXpos", 0), PlayerPrefs.GetFloat("cameraYpos", 0));
        //load rotation of the caemraa
        camera.transform.rotation = Quaternion.Euler(camera.transform.rotation.x, camera.transform.rotation.y, PlayerPrefs.GetFloat("cameraZrot", 0));
        //load offset of the cameracontroll script (attached)
        camera.GetComponent<CamControl>().camoffset = new Vector3(PlayerPrefs.GetFloat("cameraXoffset", 0), PlayerPrefs.GetFloat("cameraYoffset", 0), -10);
        
    }
}
