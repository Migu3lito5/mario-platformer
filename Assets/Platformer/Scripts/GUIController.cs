using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIController : MonoBehaviour
{
    public float maxTime;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI cointText;
    


    

    [HideInInspector]
    public int currentTime;
    [HideInInspector]
    private int currentAmountOfCoins;


    private void Start()
    {
        currentTime = 0;
        maxTime += 2;
        currentAmountOfCoins = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Time.unscaledTime 
        UpdataTimeText();
       
    }

    private void UpdataTimeText()
    {
        currentTime = (int)(Time.realtimeSinceStartup - maxTime) * -1;
        timerText.text = $"Time\n{currentTime.ToString()}";
    }

    public void UpdateCoinText()
    {
        currentAmountOfCoins++;
        cointText.text = $"x{currentAmountOfCoins.ToString()}";
    }

}
