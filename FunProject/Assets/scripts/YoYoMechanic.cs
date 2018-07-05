using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoYoMechanic : MonoBehaviour {

    public GameObject yoyomodel;
    public GameObject charcter;
    public Camera cam;

    public float force = 10f;
    public float rtnspeed = 2f;
    public int spawnDistance = 5;
    public float maxDistance;


    Vector3 direction;

    //private stuff
    float startTime;
    bool returning = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //when the user clicks the left mouse button the yo-yo will go forward depending on the view from the (camera/character?)

        if (Input.GetMouseButtonDown(0))
        {
            direction = cam.transform.forward;

            yoyomodel.GetComponent<Rigidbody>().AddForce(direction * force);
            //start infront of the character
            //yoyoMesh.transform.position = charcter.transform.position + direction * spawnDistance;
        }

        Vector3 difference = new Vector3(
            yoyomodel.transform.position.x - charcter.transform.position.x,
            yoyomodel.transform.position.y - charcter.transform.position.y,
            yoyomodel.transform.position.z - charcter.transform.position.z);

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

            yoyomodel.transform.position = Vector3.Lerp(yoyomodel.transform.position, charcter.transform.position, fracjourney);
        }

    }
}
