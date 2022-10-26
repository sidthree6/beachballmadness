using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessfullyDestroy : MonoBehaviour {

    private Player PlayerScript;
    private GameObject ParentCastle;

    public GameObject DestroyedCastleObject;

    // Use this for initialization
    void Start () {
        PlayerScript = GameObject.FindGameObjectWithTag("PlayerBall").GetComponent<Player>();
        ParentCastle = transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerBall")
        {
            Instantiate(DestroyedCastleObject, ParentCastle.transform.position, Quaternion.identity);
            
            PlayerScript.CollectScore();

            // Destroy Sand Castle
            Object.Destroy(ParentCastle);
        }
    }

}
