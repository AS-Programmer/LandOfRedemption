using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorTextLoad : MonoBehaviour
{

    [Header("UI")]
    [Tooltip("�ı���")]
    [SerializeField]
    public Text textLabel;

    [Header("�ı��ļ�")]
    public TextAsset textFile;

    [Header("����Ի���")]
    public GameObject TalkUI;

    [Header("�Ի�����")]
    [Tooltip("����")]
    [SerializeField]
    public int index;
    [Tooltip("�ı�����")]
    [SerializeField]
    public int columnNum;
    [Tooltip("�����ı��ٶ�")]
    [SerializeField]
    public float textSpeed;

    bool textFinished;
    bool isDoor;




    List<string> textList = new List<string>();
    void Awake()
    {
        GetTextFormFile(textFile);
        index = 0;
    }

    private void OnEnable()
    {
        //textLabel.text = textList[index];
        //index++;
        textFinished = true;
        StartCoroutine(SetTextUI());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && index == columnNum)  // index һ���ж����� �ص��Ի���
        {
            index = 0;
            TalkUI.SetActive(false);
            Invoke("LoadScene", 1f);
            return;
        }

        if (Input.GetButtonDown("Fire1") && textFinished)  // ����������
        {
            //textLabel.text = textList[index];
            //index++;
            StartCoroutine(SetTextUI());
        }
    }

    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();  // ��list���涫�����
        index = 0;

        var lineDate = file.text.Split('\n');   // �ûس����ָ�

        foreach (var line in lineDate)
        {
            textList.Add(line);  // ���ָ��õĶ�����ӽ�LIst
        }
    }

    void LoadScene()
    {
        if (isDoor)
            Invoke("LoadSceneManager",1f);
            
    }

    void LoadSceneManager()
    {
        SceneManager.LoadScene("StartGame");
    }

    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";
        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }
        textFinished = true;
        index++;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isDoor = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isDoor = false;
    }
}
