using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanEnvironmentBehaviour : MonoBehaviour {

    private float BoatSpeed;
    private float IslandSpeed;

    public int ID;

    private BG_AssetSpawner BGAssetSpawner;

	// Use this for initialization
	void Start () {

        BGAssetSpawner = GameObject.FindGameObjectWithTag("OceanAssetSpawner").GetComponent<BG_AssetSpawner>();

        BoatSpeed = Random.Range(2.75f,3.2f);
        IslandSpeed = 2f;

	}
	
	// Update is called once per frame
	void Update () {

        if (ID == 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * BoatSpeed, Space.World);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * IslandSpeed, Space.World);
        }

        if(transform.position.x < -10.0f)
        {
            BGAssetSpawner.ReduceOceanEnvironment(ID);
            Destroy(this.gameObject);
        }
	}
}
