using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCG_SpawnManager : MonoBehaviour
{
    /*This script is made with the intention that every few seconds an obstacle is spawned into the game 
     * so the character has to avoid*/
    

    public GameObject Obstacle;
    private float Initialtime = 2f;
    private float Repetitiontime = 4f;
    private float Uplim = -168f;
    private float Lowlim = -508f;
    private float Xlim = 1708f;
    private float zLim = 0f;
    private FCG_Score FCG_ScoreScript;

    private int NextLevel = 5;
    public bool NextLevelisOn = true;





    void Start() //At the start it indicates that it has to search for the FCG_ScoreScript and that the next level is yet not to be activated.
    {
        FCG_ScoreScript = GameObject.Find("FCG_ObstacleSpawn").GetComponent<FCG_Score>();
        NextLevelisOn = false;
        RepeatingSpawn();
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
   
    public void RepeatingSpawn()
    {
       if(FCG_ScoreScript.score >= NextLevel)
        {
            NextLevelisOn = true;
            SpeedSpawn();
        }
        else
        {
            NextLevelisOn = false;
            SpeedSpawn();
        }
        
    }

    public void SpeedSpawn() //This was meant for the spawn to increase its velocity once the score hits 5 points. 
    {
        if (NextLevelisOn == true)
        {
            InvokeRepeating("InstanceObstacle", Initialtime * 2, Repetitiontime * 2);
        }
        else
        {
            InvokeRepeating("InstanceObstacle", Initialtime, Repetitiontime);
        }
    }

    private void Update()
    {
        
    }
}
