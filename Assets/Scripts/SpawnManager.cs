using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Configuration")]
    
    [Tooltip("Minimum Height")]public float minHeight;
    [Tooltip("Maximum Height")] public float maxHeight;
    [Tooltip("Spawn amount")] public float numOfPlatform;
    [Tooltip("Maximum number of platforms put 0 for endless")] public float maxPlatform;
    [Tooltip("Minimum Width")] public float minWidth;
    [Tooltip("Maxmium Width")] public float maxWidth;
    public GameObject objectSpawn;

    Vector2 rootPosition;
    Vector2 randomPosition;
    GameObject[] platforms;
   
    // Start is called before the first frame update
    void Start()
    {
        rootPosition = transform.position;
        platforms = new GameObject[(int)numOfPlatform];
        GameObject startPlat = Instantiate(objectSpawn, rootPosition, Quaternion.identity, GameObject.Find("Platforms").transform);
        objectSpawn.SetActive(false);       

        Spawn();


    }

    void Spawn()
    {
        for (int i = 0; i < platforms.Length; i++)
        {
            if (objectSpawn)
            {
                randomPosition = rootPosition + new Vector2(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight));
                rootPosition = randomPosition;
                GameObject cPlat = Instantiate(objectSpawn, randomPosition, Quaternion.identity, GameObject.Find("Platforms").transform) as GameObject;
                cPlat.SetActive(true);
                platforms[i] = cPlat;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (GameObject.Find("Player").transform.position.x >= randomPosition.x - (objectSpawn.transform.lossyScale.x/2) )
        {


            MarkForDespawn();
            Spawn();
            Debug.Log("Generated!");
            

        }
    }

    private void OnDrawGizmos()
    {
        Debug.Log(randomPosition.x);
        Gizmos.DrawLine(GameObject.Find("Player").transform.position, new Vector3(randomPosition.x - objectSpawn.transform.lossyScale.x/2, randomPosition.y));
    }
    void MarkForDespawn()
    {
        foreach (GameObject stands in platforms)
        {
           if (stands)
            {
                stands.tag = "MarkedForDespawn";
            }
        }
    }
}



