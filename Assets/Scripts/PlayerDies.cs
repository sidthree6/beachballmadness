using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDies : MonoBehaviour {

    private Player PlayerScript;

    // Use this for initialization
    void Start () {

        PlayerScript = GameObject.FindGameObjectWithTag("PlayerBall").GetComponent<Player>() as Player;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "PlayerBall")
        {
            PlayerScript.Dies();
        }

    }
}
