using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Update is called once per frame
    void Update()
    {
        if (String.IsNullOrEmpty(GameManager.gameManager.bestPlayerName))
        {
            scoreText.text = "No Record Yet!";
        }
        else
        {
            scoreText.text = "Best Score: " + GameManager.gameManager.bestPlayerName + " : "+GameManager.gameManager.bestPlayerScore;
        }
    }
}
