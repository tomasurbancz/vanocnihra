using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PresentManager : MonoBehaviour
{
    private static List<Present> _presents;
    private static List<Present> _toRemove;
    private static Image _present1;
    private static Image _present2;
    private static Image _present3;
    private static Image _present4;
    private static Image _present5;
    private static Image _coal;


    public static void Initialize(Image present1, Image present2, Image present3, Image present4, Image present5, Image coal)
    {
        _presents = new List<Present>();
        _toRemove = new List<Present>();
        _present1 = present1;
        _present2 = present2;   
        _present3 = present3;
        _present4 = present4;
        _present5 = present5;
        _coal = coal;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private static Vector2 GetRandomPosition()
    {
        Vector2 position;
        int random = (int)Mathf.Floor(Random.Range(0f, 50f));
        if(random < 25)
        {
            random = (int)Mathf.Floor(Random.Range(0f, 50f));
            int randomXPosition = (int) Mathf.Floor(Random.Range(0, 2000f)) - 1000;
            if(random < 25)
            {
                position = new Vector2(randomXPosition, -1000);
            }
            else
            {
                position = new Vector2(randomXPosition, 1000);
            }
        }
        else
        {
            random = (int)Mathf.Floor(Random.Range(0f, 50f));
            int randomYPosition = (int)Mathf.Floor(Random.Range(0, 2000f)) - 1000;
            if (random < 25)
            {
                position = new Vector2(-1000, randomYPosition);
            }
            else
            {
                position = new Vector2(1000, randomYPosition);
            }
        }
        return position;
    }

    public static void CreateNewPresent()
    {
        Image image = null;
        int random =  (int) Mathf.Floor(Random.Range(0f, 4f));
        bool isCoal = false;
        if(random == 0)
        {
            isCoal = true;
            image = Instantiate(_coal, _coal.transform.parent);
        }
        else
        {
            random = (int)Mathf.Floor(Random.Range(0f, 4f));
            if (random == 0)
            {
                image = Instantiate(_present1, _present1.transform.parent);
            }
            if (random == 1)
            {
                image = Instantiate(_present2, _present2.transform.parent);
            }
            if (random == 2)
            {
                image = Instantiate(_present3, _present3.transform.parent);
            }
            if (random == 3)
            {
                image = Instantiate(_present4, _present4.transform.parent);
            }
            if (random == 4)
            {
                image = Instantiate(_present5, _present5.transform.parent);
            }
        }
        Vector2 _position = GetRandomPosition();

        Vector2 _direction = new Vector2((0 - _position.x) / (1000f - (LevelManager._level * 10)), (0 - _position.y) / (1000f - (LevelManager._level * 10)));

        _presents.Add(new Present(image, _position, _direction, isCoal));
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Present present in _toRemove)
        {
            _presents.Remove(present);
            Destroy(present._image);
        }

        _toRemove.Clear();

        foreach(Present present in _presents)
        {
            present.Update();
            if(present._throwedAway)
            {
                if(present._image.color.a <= 0)
                {
                    _toRemove.Add(present);
                }
            }
            else if(present.CheckForCollisionWithSantaMid())
            {
                if(present._isCoal)
                {
                    ProgressBarManager.UpdateProgress(-30);
                }
                else
                {
                    ProgressBarManager.UpdateProgress(10);
                }
                _toRemove.Add(present);
            }
        }
    }
}
