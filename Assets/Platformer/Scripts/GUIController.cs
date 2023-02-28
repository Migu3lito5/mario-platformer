using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIController : MonoBehaviour
{
    public float maxTime;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI cointText;
    public TextMeshProUGUI scoreText;

    public AudioManager audioManager;

    [HideInInspector]
    public int currentTime;
    [HideInInspector]
    private int currentAmountOfCoins;
    [HideInInspector]
    private int currentScore;

    private bool timeUp = true;

    private void Start()
    {
        setDefualtVariables();
        audioManager.GetComponent<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdataTimeText();
    }

    private void UpdataTimeText()
    {
        if (timeUp && currentTime < 0)
        {
            timeUp = false;
            Debug.Log("Time Up!");
        }

        currentTime = (int)(Time.realtimeSinceStartup - maxTime) * -1;
        timerText.text = $"Time\n{currentTime.ToString()}";
    }

    public void UpdateCoinText()
    {
        audioManager.Play("Coin");
        currentAmountOfCoins++;
        cointText.text = $"x{currentAmountOfCoins.ToString()}";
    }

    public void updateScoreText()
    {
        audioManager.Play("BreakBlock");
        currentScore += 100;
        scoreText.text = currentScore.ToString();
    }

    private void setDefualtVariables()
    {
        currentTime = 0;
        maxTime += 2;
        currentAmountOfCoins = 0;
        currentScore = 0;
    }


    public void completeLevel()
    {
        currentScore += 100;
        scoreText.text = currentScore.ToString();
    }
}
