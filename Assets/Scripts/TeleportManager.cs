using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeleportManager : MonoBehaviour
{
    public static TeleportManager instance;
    public Image fadePanel;
    public float fadeDuration = 2f; 
    Vector3 mouseWorldPos=> Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Clicked");
            CheckTeleport();
        }
    }

    private void CheckTeleport()
    {
        //检测是否点击了含有Teleport脚本的2DColider物体
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);
        if (hit.collider != null)
        {
            Teleport teleport = hit.collider.GetComponent<Teleport>();
            if (teleport != null)
            {
                Debug.Log("Hit!=null");
                teleport.Transition(teleport.sceneFrom, teleport.sceneTo);
            }
        }
    }

   public IEnumerator Fade(string sceneFrom, string sceneTo)
    {
        StartCoroutine(FadeIn(sceneFrom, sceneTo));
        yield return new WaitForSeconds(fadeDuration); // 等待淡入完成
        StartCoroutine(FadeOut());
        yield return new WaitForSeconds(fadeDuration); // 等待淡出完成
    }

    public IEnumerator FadeIn(string sceneFrom, string sceneTo)
    {
        float elapsedTime = 0f;
        Color startColor = fadePanel.color;
        startColor.a = 0f; // 初始透明度为0
        fadePanel.color = startColor;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = elapsedTime / fadeDuration; // 计算当前透明度(根据时间比渐变)
            fadePanel.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        SceneManager.UnloadSceneAsync(sceneFrom); 
        SceneManager.LoadScene(sceneTo, LoadSceneMode.Additive);

        fadePanel.color = new Color(startColor.r, startColor.g, startColor.b, 1f); // 最终透明度为1，即黑屏
    }

    public IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color startColor = fadePanel.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = 1f - (elapsedTime / fadeDuration); // 计算当前透明度
            fadePanel.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        fadePanel.color = new Color(startColor.r, startColor.g, startColor.b, 0f); // 最终透明度为0
    }
}
