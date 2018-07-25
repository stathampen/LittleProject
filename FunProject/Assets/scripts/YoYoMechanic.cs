using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoYoMechanic : MonoBehaviour {

    public GameObject yoyoPrefab;
    public GameObject character;
    public Camera cam;

    public float force = 10f;
    public float rtnspeed = 2f;
    public int spawnDistance = 5;
    public float maxDistance;


    Vector3 direction;

    //private stuff
    float startTime;
    bool returning = false;

    private GameObject yoyoSpawned;
    private LineRenderer yoyoString;

    // Use this for initialization
    void Start () {
		yoyoString = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update () {
        //when the user clicks the left mouse button the yo-yo will go forward depending on the view from the (camera/character?)
        if (Input.GetMouseButtonDown(0))
        {
            if (yoyoSpawned)   //destroy the yoyo if it's already present
            {
                Destroy(yoyoSpawned);
            }

            direction = cam.transform.forward;
            
            //create the yoyo
            yoyoSpawned = Instantiate(yoyoPrefab);
            yoyoSpawned.GetComponent<Rigidbody>().AddForce(direction * force, ForceMode.Impulse);
            

            //yoyomodel.GetComponent<Rigidbody>().AddForce(direction * force);
            //start infront of the character
            //yoyoMesh.transform.position = charcter.transform.position + direction * spawnDistance;
        }

        if (yoyoSpawned != null)
        {
            StringHandler();

            Returning();
        }
       
    }

    private void Returning()
    {
        Vector3 difference = new Vector3(
    yoyoSpawned.transform.position.x - character.transform.position.x,
    yoyoSpawned.transform.position.y - character.transform.position.y,
    yoyoSpawned.transform.position.z - character.transform.position.z);

        float distance = Mathf.Sqrt(
            Mathf.Pow(difference.x, 2f) +
            Mathf.Pow(difference.y, 2f) +
            Mathf.Pow(difference.z, 2f));

        if (distance > maxDistance && returning != true)
        {
            //freezes everything when it reaches a certain distance
            //yoyomodel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;


            returning = true;

            startTime = Time.time;

        }

        if (returning == true)
        {
            float distcovered = (Time.time - startTime) * rtnspeed;

            float fracjourney = distcovered / distance;

            yoyoSpawned.transform.position = Vector3.Slerp(yoyoSpawned.transform.position, character.transform.position, fracjourney);
        }

    }

    void StringHandler()
    {
        //makes sure the 'string' continues to run between the yoyo and character
        yoyoString.SetPositions(new Vector3[] {character.transform.position, yoyoSpawned.transform.position});
    }
}
