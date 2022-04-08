using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainHUBScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI coinText;

    [SerializeField]
    scriptTest1 phPlayer;

    void Start()
    {
        
    }

    void Update()
    {
        coinText.text = phPlayer.CoinCollected.ToString();
    }
}
