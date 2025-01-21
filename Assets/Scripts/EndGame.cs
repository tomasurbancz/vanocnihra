using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public TextMeshProUGUI EndGameText;

    // Start is called before the first frame update
    void Start()
    {
        if(Saver.GetString("status").Equals("lost"))
        {
            EndGameText.text = "Nepodaøilo se ti porazit úroveò " + (Saver.GetInt("goal") - 1);
        }
        else
        {
            EndGameText.text = "Podaøilo se ti porazit úroveò " + (Saver.GetInt("goal") - 1);
            Saver.SaveInt("goal", Saver.GetInt("goal") + 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
