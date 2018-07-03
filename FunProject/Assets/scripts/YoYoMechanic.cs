using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoYoMechanic : MonoBehaviour {

    public GameObject yoyoMesh;
    public GameObject charcter;
    public GameObject camera;
    public float speed = 20f;
    public int spawnDistance = 10;
    public float maxDistance;

    public bool moving = false;

    Vector3 direction;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //when the user clicks the left mouse button the yo-yo will go forward depending on the view from the (camera/character?)

        if (Input.GetMouseButtonDown(0))
        {
            direction = camera.transform.forward;

            //start infront of the character
            yoyoMesh.transform.position = charcter.transform.position + direction * spawnDistance;


            moving = true;
        }

        if (moving == true)
        {
            yoyoMesh.transform.Translate(direction * speed * Time.deltaTime);
        }

        var dist = Vector3.Distance(charcter.transform.position, yoyoMesh.transform.position);

        if (dist > maxDistance)
        {
            moving = false;

        }
		
	}
}
