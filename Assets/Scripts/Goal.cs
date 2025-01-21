using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI goal;

    // Start is called before the first frame update
    void Start()
    {
        if (Saver.GetInt("goal") <= 0) Saver.SaveInt("goal", 2);
        goal.text = "Dostaò se na level: " + Saver.GetInt("goal");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
