using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCG_SpawnManager : MonoBehaviour
{
    public GameObject Obstacle;
    private float Initialtime = 2f;
    private float Repetitiontime = 4f;
    private float Uplim = -168f;
    private float Lowlim = -508f;
    private float Xlim = 1708f;
    private float zLim = 0f;
    private FCG_Score FCG_ScoreScript;

    public int RiseSpeed = 20;
    public int ScoreDistance = 1929;


    void Start()
    {
        FCG_ScoreScript = GameObject.Find("FCG_ObstacleSpawn").GetComponent<FCG_Score>();
        InvokeRepeating("InstanceObstacle", Initialtime, Repetitiontime);
    }

    public Vector3 RandomSpawnPosition()
    {
        
        float randomY = Random.Range(Lowlim, Uplim);
        return new Vector3(Xlim, randomY, zLim);
    }

    public void InstanceObstacle()
    {
        Instantiate(Obstacle, RandomSpawnPosition(), Obstacle.transform.rotation);
    }
   
   /*public void IncreaseSpeedSpawn()
    {
        if (FCG_ScoreScript.ScoreUp >= ScoreDistance)
        {

        }
    }*/
}
