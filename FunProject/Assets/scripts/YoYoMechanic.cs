using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoYoMechanic : MonoBehaviour {

    public Rigidbody yoyoYo;
    public GameObject charcter;
    public GameObject camera;
    public float force = 20f;
    public int spawnDistance = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //when the user clicks the left mouse button the yo-yo will go forward depending on the view from the (camera/character?)

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 direction = camera.transform.forward;

            //start in the character
            yoyoYo.transform.position = charcter.transform.position + direction * spawnDistance;

            yoyoYo.AddForce(direction * force);
        }
		
	}
}
