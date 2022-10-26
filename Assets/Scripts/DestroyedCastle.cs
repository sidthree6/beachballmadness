using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedCastle : MonoBehaviour {

    public float Speed;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.World);

        if (transform.position.x < -12.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
