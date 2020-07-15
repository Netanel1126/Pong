using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuWindow : MonoBehaviour
{

    private enum SubMenu
    {
        MainMenuWindow,
        ToturialWidow,
        PlayerPopup,
    }

    private void Awake()
    {
        transform.Find(SubMenu.ToturialWidow.ToString()).GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        transform.Find(SubMenu.PlayerPopup.ToString()).GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        ShowMain();
    }

    public void StartMainGame()
    {
        ShowSub(SubMenu.PlayerPopup);
    }

    public void GoToMainScene(bool isMultiplayer)
    {
        PlayerPrefs.SetInt("is_mulitplayer", isMultiplayer? 1 : 0);
        LoaderManager.Load(Scenes.MainScene);
    }

    public void ShowToturial()
    {
        ShowSub(SubMenu.ToturialWidow);
    }

    public void ShowMain()
    {
        ShowSub(SubMenu.MainMenuWindow);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void ShowSub(SubMenu sub)
    {
        transform.Find(SubMenu.MainMenuWindow.ToString()).gameObject.SetActive(false);
        transform.Find(SubMenu.ToturialWidow.ToString()).gameObject.SetActive(false);
        transform.Find(SubMenu.PlayerPopup.ToString()).gameObject.SetActive(false);
        transform.Find(sub.ToString()).gameObject.SetActive(true);

    }
}
