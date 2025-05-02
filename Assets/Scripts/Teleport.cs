using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public string sceneFrom;
    public string sceneTo;

    public void Transition(string sceneFrom,string sceneTo)
    {
        
        //TeleportManager.instance.StartCoroutine(TeleportManager.instance.FadeIn());
        //TeleportManager.instance.StartCoroutine(TeleportManager.instance.FadeOut());
        TeleportManager.instance.StartCoroutine(TeleportManager.instance.Fade(sceneFrom, sceneTo));
        //SceneManager.UnloadSceneAsync(sceneFrom);
        //SceneManager.LoadScene(sceneTo, LoadSceneMode.Additive);
    }
}
