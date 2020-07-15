using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    MainScene,
    MainMenu
}

public static class LoaderManager
{
    public static void Load(Scenes scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
