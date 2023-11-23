using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum Scene
    {
        MainMenu, Freeroam, BattleScene1
    }

    public static void Load(Scene scene) 
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
