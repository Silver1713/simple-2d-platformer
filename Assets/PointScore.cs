using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScore : MonoBehaviour
{
    [Header("Configurations")]
    GameObject platformGround;
    [Tooltip("Amount of point per platforms")] public int points;
    bool pointScored = false;

    private void Awake()
    {
        if (pointScored)
        {
            Destroy(this);
            
        }
    }

    private void Start()
    {
        platformGround = transform.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        pointScored = true;
        //Call GameManagerPointAdder
        GameManager.instance.AddScore(points);
        Destroy(this);
    }

}
