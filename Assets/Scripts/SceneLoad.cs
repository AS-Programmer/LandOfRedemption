using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    // ��һ����Ϸ�����л��ĵ���Ч��
    [Header("����ת�� ����")]
    [Tooltip("UI ���뵭��ͼ��")]
    [SerializeField]
    public UnityEngine.UI.Image transtionImage;
    [Tooltip("UI ��������ʱ��")]
    [SerializeField]
    float fadeTime = 1f;

    // ���������� Ҫת������������
    const string GAMEPLAY = "TestDemo";
    const string REPLAY = "TestDemo";
    const string GoBack = "StartGame";

    Color color;

    IEnumerator LoadCoroutine(string newScene)
    {
        // �첽���� ������濨������
        var loadingOperation = SceneManager.LoadSceneAsync(newScene);
        loadingOperation.allowSceneActivation = false;

        transtionImage.gameObject.SetActive(true);
        // ����
        while (color.a < 1f)  // ����ͼƬalpha ͸����
        {
            color.a = Mathf.Clamp01(color.a + Time.unscaledDeltaTime / fadeTime); // unscaledDetaltaTime�����ܵ�ʱ���ģ��Ӱ��
            //Mathf.Clamp01()  ������������������0����1ֱ�� ��ֹ���
            transtionImage.color = color;
            yield return null;
        }

        //yield return new WaitUntil(() => loadingOperation.progress >= 0.9);
        loadingOperation.allowSceneActivation = true;// ���س���
        //Load(sceneName);


        // ����
        while (color.a > 0f)
        {
            color.a = Mathf.Clamp01(color.a - Time.unscaledDeltaTime / fadeTime);
            transtionImage.color = color;
            yield return null;
        }

        transtionImage.gameObject.SetActive(false);
    }

    public void NextScene()
    {
        StopAllCoroutines();

        StartCoroutine(LoadCoroutine(GAMEPLAY));

    }

    public void LoadRePlay()
    {
        StopAllCoroutines();

        StartCoroutine(LoadCoroutine(REPLAY));
    }

    public void LoadGoBack()
    {
        StopAllCoroutines();

        StartCoroutine(LoadCoroutine(GoBack));
    }

}
