using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yoyoDestroySelf : MonoBehaviour {

    //destroy the yoyo once it returns back to the player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
