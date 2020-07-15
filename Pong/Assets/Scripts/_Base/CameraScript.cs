using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraScript : MonoBehaviour
{
    public SpriteRenderer backgroundSprite;

    // Use this for initialization
    void OnGUI()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = backgroundSprite.bounds.size.x / backgroundSprite.bounds.size.y;

        //if (screenRatio >= targetRatio)
        //{
        //    Camera.main.orthographicSize = backgroundSprite.bounds.size.y / 2;
        //}
        //else
        //{
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = backgroundSprite.bounds.size.y / 2 * differenceInSize;
        //}
    }
}
