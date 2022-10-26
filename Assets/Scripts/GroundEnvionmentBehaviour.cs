using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnvionmentBehaviour : MonoBehaviour {

    private float Speed;

    public int ID;

    private BG_AssetSpawner BGAssetSpawner;

    // Use this for initialization
    void Start () {
        BGAssetSpawner = GameObject.FindGameObjectWithTag("OceanAssetSpawner").GetComponent<BG_AssetSpawner>();
        Speed = 2.5f;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime * Speed, Space.World);

        if (transform.position.x < -12.0f)
        {
            BGAssetSpawner.ReduceOceanEnvironment(ID);
            Destroy(this.gameObject);
        }
    }
}
