using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseWindow : BaseMonoBehaviour
{
    private static PauseWindow sharedInstence;

    private void Awake()
    {
        sharedInstence = this;

        transform.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        transform.GetComponent<RectTransform>().sizeDelta = Vector2.zero;

        Hide();
    }

    public static void ShowStatic()
    {
        sharedInstence.Show();
    }

    public static void HideStatic()
    {
        sharedInstence.Hide();
    }

    public void OpenMainMenu()
    {
        Debug.Log("Loading MainManu");
        //LoaderManager.Load(Scenes.MainMenu);
    }

}
