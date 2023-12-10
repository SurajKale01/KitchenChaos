using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loder 
{
    public enum Scene
    {
        MainMenuScene,
        GameScene,
        LoadingScene
    }



    private static Scene targetScene;



    public static void Load(Scene targetScene)
    {
        Loder.targetScene = targetScene;

        SceneManager.LoadScene(Scene.LoadingScene.ToString());

        
    }

    public static void LoderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
