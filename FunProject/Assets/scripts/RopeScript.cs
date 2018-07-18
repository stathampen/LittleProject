using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeScript : MonoBehaviour {
    public GameObject target;
    LineRenderer line;

    // Use this for initialization
    void Start () {
        line = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
