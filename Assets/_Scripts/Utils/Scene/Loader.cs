using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader 
{
    public enum Scenes {
        BattleScene,
        EventScene, 
        MainMenu,
        WinScene,
        LoadingScreen
    }

    private static Action onLoaderCallback;

    public static void Load(Scenes scene) 
    {
        onLoaderCallback = () =>
        {
            SceneManager.LoadScene(scene.ToString());
        };

        SceneManager.LoadScene(Scenes.LoadingScreen.ToString());
    }
    public static void Load(BaseRoom room) 
    {
        if(room is EventRoom) Load(Scenes.EventScene);
        else if(room is BattleRoom) Load(Scenes.BattleScene);
    }

    public static void LoaderCallback() {

        if (onLoaderCallback is not null) {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
