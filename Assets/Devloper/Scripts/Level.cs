using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public static Level level;

  
    private void OnEnable()
    {
     
        GameManager.gameManager.TriggerRoad = 0;        
        for (int i = 0; i < GameManager.gameManager.LevelButton.Length; i++)
        {
            if (i > PlayerPrefs.GetInt("Level"))
            {
                GameManager.gameManager.LevelButton[i].interactable = false;
            }
            else
            {
                GameManager.gameManager.LevelButton[i].interactable = true;
            }            
        }
    }
    
}
