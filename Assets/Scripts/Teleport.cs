using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public SceneName sceneFrom;
    public SceneName sceneTo;

    public void Transition(SceneName sceneFrom,SceneName sceneTo)
    {
        string from=sceneFrom.ToString();
        string to=sceneTo.ToString();

        //TeleportManager.instance.StartCoroutine(TeleportManager.instance.FadeIn());
        //TeleportManager.instance.StartCoroutine(TeleportManager.instance.FadeOut());
        TeleportManager.instance.StartCoroutine(TeleportManager.instance.Fade(from, to));
        //SceneManager.UnloadSceneAsync(sceneFrom);
        //SceneManager.LoadScene(sceneTo, LoadSceneMode.Additive);
    }
}
