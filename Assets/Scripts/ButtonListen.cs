using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListen : MonoBehaviour
{
    public Button GameStartButton;//��Ϸ��ʼ��ť
    public Button GameOptionButton;//��Ϸѡ�ť
    public Button GameOverButton;//��Ϸ������ť

    void Start()
    {
        GameStartButton = GameObject.Find("btnPlay").GetComponent<Button>();//ͨ��Find�������ƻ������Ҫ��Button���
        GameStartButton.onClick.AddListener(GameStartClickListener);//��������¼�
    }

    //��ʼ��Ϸ�������
    public void GameStartClickListener()
    {
        print("StartGameButtonIsClick");
        //SceneManager.LoadScene(1);//��ת���ؿ�1
    }

    //��Ϸѡ��������
    public void GameOptionButtonClickListener()
    {

    }

    //�˳���Ϸ�������
    public void GameOverClickListener()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
