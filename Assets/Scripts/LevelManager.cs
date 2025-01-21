using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{

    public static TextMeshProUGUI _text;
    public static int _level;

    public static void Initialize(TextMeshProUGUI text, int level)
    {
        _text = text;
        _level = level;
        UpdateLevel(0);
    }

    public static void UpdateLevel(int level)
    {
        _level += level;
        _text.text = $"Level: {_level}";
        if(_level >= Saver.GetInt("goal"))
        {
            Saver.SaveInt("mistakes", 5);
            Saver.SaveString("status", "won");
            Saver.SaveInt("highscore", Saver.GetInt("highscore") + 1);
            SceneChanger.LoadScene("EndGame");
        }
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
