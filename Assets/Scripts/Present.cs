using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Present
{
    public Image _image;
    private Vector2 _position;
    private Vector2 _direction;
    public bool _throwedAway;
    public bool _isCoal;

    public Present(Image image, Vector2 position, Vector2 direction, bool isCoal)
    {
        _image = image;
        _position = position;
        _direction = direction;
        _throwedAway = false;
        _isCoal = isCoal;
    }

    public void Update()
    {
        if(Input.GetMouseButton(0))
        {
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;

            Vector2 mousePosition = Input.mousePosition;
            mousePosition = new Vector2(mousePosition.x - screenWidth / 2, mousePosition.y - screenHeight / 2);
            Vector2 _positionS = new Vector2(_position.x - 30, _position.y - 60);
            if(IsColliding(mousePosition, _positionS, new Vector2(150, 200)))
            {
                ThrowAway();
                if (_isCoal)
                {
                    ProgressBarManager.UpdateProgress(10);
                }
                else
                {
                    ProgressBarManager.UpdateProgress(-30);
                    if (Saver.GetInt("mistakes") < 0)
                    {
                        Saver.SaveInt("mistakes", 5);
                        Saver.SaveString("status", "lost");
                        SceneChanger.LoadScene("EndGame");
                    }
                }
            }
        }
        _position = new Vector2(_position.x + _direction.x, _position.y + _direction.y);
        _image.rectTransform.anchoredPosition = _position;
        if(_throwedAway)
        {
            Color color = _image.color;

            if(color.a > 0)
            {
                color.a = Mathf.Max(0, color.a - 0.01f);
            }

            _image.color = color;
        }
    }

    public void ThrowAway()
    {
        _direction = new Vector2(-_direction.x, -_direction.y);
        _throwedAway = true;
    }

    public bool CheckForCollisionWithSantaMid()
    {
        Vector2 positionOfSantaCollisionBox = new Vector2(-25, -25);
        Vector2 sizeOfCollision = new Vector2(50, 50);
        return IsColliding(_position, positionOfSantaCollisionBox, sizeOfCollision);
    }

    private bool IsColliding(Vector2 position1, Vector2 position2, Vector2 size)
    {
        if(position1.x >= position2.x && position1.x <= position2.x + size.x)
        {
            if(position1.y >= position2.y && position1.y <= position2.y + size.y)
            {
                return true;
            }
        }
        return false;
    }
}
