using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_AssetSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject Boat;
    [SerializeField]
    private GameObject Island;
    [SerializeField]
    private GameObject BeachBucket;
    [SerializeField]
    private GameObject BeachUmbrella;

    public float SpawnRangeMin;
    public float SpawnRangeMax;

    public float SpawnGroundRangeMin;
    public float SpawnGroundRangeMax;

    private int CurrentBoatActive;
    private int CurrentIslandActive;
    private int CurrentBucketActive;
    private int CurrentUmbrellaActive;

    private float StartPositionX = 12.0f;

    // Use this for initialization
    void Start()
    {

        SpawnIsland();

        SpawnUmbrella();

        StartCoroutine(SpawningOceanEnvironment());

        StartCoroutine(SpawningGroundEnvironment());
    }

    IEnumerator SpawningOceanEnvironment()
    {
        while (true)
        {
            int WaitBeforeSpawning = Random.Range(4, 12);

            yield return new WaitForSeconds(WaitBeforeSpawning);

            // Spawning of Ocean Environment
            SpawnOceanEnvironment();
        }
    }

    IEnumerator SpawningGroundEnvironment()
    {
        while(true)
        {
            int WaitBeforeSpawning = Random.Range(3, 6);

            yield return new WaitForSeconds(WaitBeforeSpawning);

            SpawnGroundEnvironment();
        }
    }

    private void SpawnOceanEnvironment()
    {
        /// Spawning of Ocean Environment
        if (Random.Range(0, 2) == 0)
        {
            if (CurrentBoatActive < 2)
            {

                SpawnBoat();
            }
        }
        else
        {
            if (CurrentIslandActive < 2)
            {
                SpawnIsland();
            }
        }
    }

    private void SpawnGroundEnvironment()
    {        
        /// Spawning of Ocean Environment
        if (Random.Range(0, 3) == 0)
        {
            if (CurrentBoatActive < 2)
            {

                SpawnBeachBucket();
            }
        }
        else
        {
            if (CurrentIslandActive < 2)
            {
                SpawnUmbrella();
            }
        }
    }

    private void SpawnBoat()
    {
        float StartPositionY = Random.Range(SpawnRangeMin, SpawnRangeMax);

        Instantiate(Boat, new Vector3(StartPositionX, StartPositionY, 0.0f), Quaternion.identity);

        CurrentBoatActive++;
    }

    private void SpawnIsland()
    {
        float StartPositionY = Random.Range(SpawnRangeMin, SpawnRangeMax);

        Instantiate(Island, new Vector3(StartPositionX, StartPositionY, 0.0f), Quaternion.identity);

        CurrentIslandActive++;
    }

    private void SpawnBeachBucket()
    {
        float StartPositionY = Random.Range(SpawnGroundRangeMin, SpawnGroundRangeMax);

        GameObject bucket = Instantiate(BeachBucket, new Vector3(StartPositionX, StartPositionY, 0.0f), Quaternion.identity);
        float difference = StartPositionY - SpawnGroundRangeMin;
        difference *= 0.25f;

        bucket.transform.localScale = new Vector3(bucket.transform.localScale.x - difference, bucket.transform.localScale.y - difference, 0);

        CurrentBucketActive++;
    }

    private void SpawnUmbrella()
    {
        float StartPositionY = Random.Range(SpawnGroundRangeMin, SpawnGroundRangeMax);    

        GameObject umbrella = Instantiate(BeachUmbrella, new Vector3(StartPositionX, StartPositionY, 0.0f), Quaternion.identity);

        float difference = StartPositionY - SpawnGroundRangeMin;
        difference *= 0.25f;

        umbrella.transform.localScale = new Vector3(umbrella.transform.localScale.x - difference, umbrella.transform.localScale.y - difference, 0);

        CurrentUmbrellaActive++;
    }

    // 0 = boat, 1 = island
    public void ReduceOceanEnvironment(int ID)
    {
        if (ID == 0)
        {
            CurrentBoatActive--;
        }
        else
        {
            CurrentIslandActive--;
        }
    }

    // 0 = bucket, 1 = umbrella
    public void ReduceGroundEnvironment(int ID)
    {
        if (ID == 0)
        {
            CurrentBucketActive--;
        }
        else
        {
            CurrentUmbrellaActive--;
        }
    }
}
