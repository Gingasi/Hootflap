using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FCG_DataPersistance : MonoBehaviour
{
    /*This script is the one were data persistances is stablished so it detects each score at each play so you can save it for the ranking score*/

    public static FCG_DataPersistance SharedInstance;

    public int FirstrstPlace;
    public int SecondPlace;
    public int ThirdPlace;
    public int FourthPlace;
    public int FifthPlace;

    public int scoreBeated;

    public void SaveForFutureGames()
    {
        PlayerPrefs.SetInt("firstrstplace", FirstrstPlace);
        PlayerPrefs.SetInt("SecondPlace", SecondPlace);
        PlayerPrefs.SetInt("ThirdPlace", ThirdPlace);
        PlayerPrefs.SetInt("FourthPlace", FourthPlace);
        PlayerPrefs.SetInt("FifthPlace", FifthPlace);
        PlayerPrefs.SetInt("ScoreBeated" , scoreBeated);
    }

    public void LoadUserData()
    {
        FCG_DataPersistance.SharedInstance.FirstrstPlace = PlayerPrefs.GetInt("firstrstplace");
        FCG_DataPersistance.SharedInstance.SecondPlace = PlayerPrefs.GetInt("SecondPlace");
        FCG_DataPersistance.SharedInstance.ThirdPlace = PlayerPrefs.GetInt("ThirdPlace");
        FCG_DataPersistance.SharedInstance.FourthPlace = PlayerPrefs.GetInt("FourthPlace");
        FCG_DataPersistance.SharedInstance.FirstrstPlace = PlayerPrefs.GetInt("FifthPlace");
        FCG_DataPersistance.SharedInstance.scoreBeated = PlayerPrefs.GetInt("ScoreBeated");

    }

    private void Awake()
    {
        
        if (SharedInstance == null)
        {
            
            SharedInstance = this;
            
            DontDestroyOnLoad(SharedInstance);
        }
        else
        {
            
            Destroy(this);
        }
    }
}
