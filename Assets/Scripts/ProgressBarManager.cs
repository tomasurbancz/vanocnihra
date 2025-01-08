using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarManager : MonoBehaviour
{

    public static Slider _slider;
    private static int _progress;
    private static int _toNextLevel;

    public static void Initialize(Slider slider)
    {
        _slider = slider;
        _progress = 0;
        _toNextLevel = 100;
        UpdateProgress(0);
    }

    public static void UpdateProgress(int progress)
    {
        _progress = Mathf.Max(0, _progress + progress);
        if(_progress > _toNextLevel)
        {
            _toNextLevel = (int) Mathf.Round(1.1f * _toNextLevel);
            _progress = 0;
            LevelManager.UpdateLevel(1);
        }
        _slider.value = ((float) _progress / _toNextLevel);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
