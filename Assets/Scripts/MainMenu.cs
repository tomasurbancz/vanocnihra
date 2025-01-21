using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highscore;

    // Start is called before the first frame update
    void Start()
    {
        highscore.text = "High score: " + Saver.GetInt("highscore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
