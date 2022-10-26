using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Beach BG LIST Storage
public class BeachBG
{
    public GameObject beachbg;

    public BeachBG(GameObject inBeachBg)
    {
        beachbg = inBeachBg;
    }
}

// Ocean BG LIST Storage
public class OceanBG
{
    public GameObject oceanbg;

    public OceanBG(GameObject inOceanBG)
    {
        oceanbg = inOceanBG;
    }
}

// Ground BG LIST Storage
public class GroundBG
{
    public GameObject groundbg;

    public GroundBG(GameObject inGroundBG)
    {
        groundbg = inGroundBG;
    }
}

public class SpriteMover : MonoBehaviour {

    public int MinX;
    public int MaxX;

    [Header("Beach BG")]
    [SerializeField]
    private GameObject BeachBG;

    List<BeachBG> BeachBGStorage = new List<BeachBG>();

    public float BeachBgYLevel;
    public int NumberOfBeachBG;
    public float BeachBGSpeed;

    private float SizeofSpriteBeachBG;

    [Header("Ocean BG")]
    [SerializeField]
    private GameObject OceanBG;

    List<OceanBG> OceanBGStorage = new List<OceanBG>();

    public float OceanBgYLevel;
    public int NumberOfOceanBG;
    public float OceanBGSpeed;

    private float SizeofSpriteOceanBG;

    [Header("Ground BG")]
    [SerializeField]
    private GameObject GroundBG;

    List<GroundBG> GroundBGStorage = new List<GroundBG>();

    public float GroundBgYLevel;
    public int NumberOfGroundBG;
    public float GroundBGSpeed;

    private float SizeofSpriteGroundBG;

    // Use this for initialization
    void Start ()
    {
        // Get Width of Beach BG Sprite
        SizeofSpriteBeachBG = BeachBG.GetComponent<SpriteRenderer>().bounds.size.x;
        // Get width of Ocean BG Sprite
        SizeofSpriteOceanBG = OceanBG.GetComponent<SpriteRenderer>().bounds.size.x;
        // Get width of Ground BG Sprite
        SizeofSpriteGroundBG = GroundBG.GetComponent<SpriteRenderer>().bounds.size.x;

        // Spawn Beach background
        SpawnBeachBG();

        // Spawn Ocean background
        SpawnOceanBG();

        // Spawn Ground background
        SpawnGroundBG();
    }   

    // Update is called once per frame
    void Update ()
    {
        // Move BeachBG
        BeachBGMove();

        // Move OceanBG
        OceanBGMove();

        // Move GroundBG
        GroundBGMove();
    }

    // Move BeachBG
    private void BeachBGMove()
    {
        for(int i=0; i<BeachBGStorage.Count; i++)
        {
            Vector3 MovingLeftVelocity = Vector3.left;
            MovingLeftVelocity *= Time.deltaTime * BeachBGSpeed;
            BeachBGStorage[i].beachbg.transform.Translate(MovingLeftVelocity);

            float destroyPosX = MinX - SizeofSpriteBeachBG;

            if(BeachBGStorage[i].beachbg.transform.position.x < destroyPosX)
            {
                AddBeachBGAtEnd();

                DestroyFirstBeachBG();
            }
        }
    }

    // Spawn Moving Beach BG
    private void SpawnBeachBG()
    {
        float currentX = MinX;

        // Spawn Multiple sprites horizontally
        for (int i = 0; i < NumberOfBeachBG; i++)
        {
            BeachBGStorage.Add(new BeachBG(Instantiate(BeachBG, new Vector3(currentX, BeachBgYLevel, 0), Quaternion.identity) as GameObject));

            currentX += SizeofSpriteBeachBG;
        }
    }

    private void DestroyFirstBeachBG()
    {
        Destroy(BeachBGStorage[0].beachbg);

        BeachBGStorage.RemoveAt(0);
    }

    private void AddBeachBGAtEnd()
    {
        //Get X of last remaining Beach BG . we get 3rd element (4th in list)
        float LastBeachBGX = BeachBGStorage[3].beachbg.transform.position.x;        

        float currentX = LastBeachBGX + SizeofSpriteBeachBG;

        BeachBGStorage.Add(new BeachBG(Instantiate(BeachBG, new Vector3(currentX, BeachBgYLevel, 0), Quaternion.identity) as GameObject));
    }


    private void SpawnOceanBG()
    {
        float currentX = MinX;

        // Spawn Multiple sprites horizontally
        for (int i = 0; i < NumberOfOceanBG; i++)
        {
            OceanBGStorage.Add(new OceanBG(Instantiate(OceanBG, new Vector3(currentX, OceanBgYLevel, 0), Quaternion.identity) as GameObject));

            currentX += SizeofSpriteOceanBG;
        }
    }

    private void OceanBGMove()
    {
        for (int i = 0; i < OceanBGStorage.Count; i++)
        {
            Vector3 MovingLeftVelocity = Vector3.left;
            MovingLeftVelocity *= Time.deltaTime * OceanBGSpeed;
            OceanBGStorage[i].oceanbg.transform.Translate(MovingLeftVelocity);

            float destroyPosX = MinX - SizeofSpriteOceanBG;

            if (OceanBGStorage[i].oceanbg.transform.position.x < destroyPosX)
            {
                AddOceanBGAtEnd();

                DestroyFirstOceanBG();
            }
        }
    }

    private void DestroyFirstOceanBG()
    {
        Destroy(OceanBGStorage[0].oceanbg);

        OceanBGStorage.RemoveAt(0);
    }

    private void AddOceanBGAtEnd()
    {
        //Get X of last remaining Beach BG . we get 3rd element (4th in list)
        float LastOceanBGX = OceanBGStorage[3].oceanbg.transform.position.x;

        float currentX = LastOceanBGX + SizeofSpriteOceanBG;

        OceanBGStorage.Add(new OceanBG(Instantiate(OceanBG, new Vector3(currentX, OceanBgYLevel, 0), Quaternion.identity) as GameObject));
    }

    private void SpawnGroundBG()
    {
        float currentX = MinX;

        // Spawn Multiple sprites horizontally
        for (int i = 0; i < NumberOfGroundBG; i++)
        {
            GroundBGStorage.Add(new GroundBG(Instantiate(GroundBG, new Vector3(currentX, GroundBgYLevel, 0), Quaternion.identity) as GameObject));

            currentX += SizeofSpriteGroundBG;
        }
    }

    private void GroundBGMove()
    {
        for (int i = 0; i < GroundBGStorage.Count; i++)
        {
            Vector3 MovingLeftVelocity = Vector3.left;
            MovingLeftVelocity *= Time.deltaTime * GroundBGSpeed;
            GroundBGStorage[i].groundbg.transform.Translate(MovingLeftVelocity);

            float destroyPosX = MinX - SizeofSpriteGroundBG;

            if (GroundBGStorage[i].groundbg.transform.position.x < destroyPosX)
            {
                AddGroundBGAtEnd();

                DestroyFirstGroundBG();
            }
        }
    }

    private void AddGroundBGAtEnd()
    {
        //Get X of last remaining Beach BG . we get 3rd element (4th in list)
        float LastGroundBGX = GroundBGStorage[3].groundbg.transform.position.x;

        float currentX = LastGroundBGX + SizeofSpriteGroundBG;

        GroundBGStorage.Add(new GroundBG(Instantiate(GroundBG, new Vector3(currentX, GroundBgYLevel, 0), Quaternion.identity) as GameObject));
    }

    private void DestroyFirstGroundBG()
    {
        Destroy(GroundBGStorage[0].groundbg);

        GroundBGStorage.RemoveAt(0);
    }

}
