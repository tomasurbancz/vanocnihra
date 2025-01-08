using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    public Image present1;
    public Image present2;
    public Image present3;
    public Image present4;
    public Image present5;
    public Image coal;
    public TextMeshProUGUI levelText;
    public Slider _progressBar;

    // Start is called before the first frame update
    void Start()
    {
        PresentManager.Initialize(present1, present2, present3, present4, present5, coal);
        LevelManager.Initialize(levelText, 0);
        ProgressBarManager.Initialize(_progressBar);
        WaitForNextInvoke();
    }

    void WaitForNextInvoke()
    {
        float minValue = 1 - (LevelManager._level / 10);
        float maxValue = Mathf.Max(minValue, 0.5f);
        float randomTime = Random.Range(minValue, maxValue);
        Invoke("SpawnPresentOnRandomPosition", randomTime);
    }

    void SpawnPresentOnRandomPosition()
    {
        PresentManager.CreateNewPresent();
        WaitForNextInvoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
