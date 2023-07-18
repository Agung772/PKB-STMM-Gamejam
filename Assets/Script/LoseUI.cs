using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseUI : MonoBehaviour
{
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI score;

    public void SetScore(int value)
    {
        highScore.text = "Skor tertinggi : " + GameSave.instance.highScore;
        score.text = "Skor : " + value;

        if (value > GameSave.instance.highScore)
        {
            PlayerPrefs.SetFloat(GameSave.instance._HighScore, value);
            GameSave.instance.highScore = value;
            highScore.text = "Skor tertinggi : " + GameSave.instance.highScore;
        }
    }
}
