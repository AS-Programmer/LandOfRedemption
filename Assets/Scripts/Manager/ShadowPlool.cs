using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPlool : MonoBehaviour
{
    public static ShadowPlool instance; // ����

    [SerializeField]
    private GameObject shadowPrefabs; // ��ӰԤ����
    [SerializeField]
    private int shadowCount; // ��Ӱ����

    // ʹ�ö��д洢��Ӱ
    private Queue<GameObject> shadowQueue = new Queue<GameObject>();

    private void Start()
    {
        // ��ʼ�������
        if (instance != null)
        {
            Destroy(instance);
            return;
        }
        instance = this;
    }

    #region �������
    public void FillPool()
    {
        for (int i = 0; i < shadowCount; i++)
        {
            // ����һ�� shadowPrefabs
            var newShadow = Instantiate(shadowPrefabs);
            // ��ǰ����Ϊ��������ĸ�������
            newShadow.transform.SetParent(transform);

            // ȡ�����ã����ض����
            ReturnPool(newShadow);
        }
    }
    #endregion

    #region ���ض����
    public void ReturnPool(GameObject gameObject)
    {
        // ȡ������
        gameObject.SetActive(false);
        // ��ӽ��Ӷ�β
        shadowQueue.Enqueue(gameObject);
    }
    #endregion

    #region �Ӷ������ȡ��Ԥ����
    public GameObject GetFromPool()
    {
        // ������Ԫ�ز��������ٴ����
        if(shadowQueue.Count == 0)
        {
            FillPool();
        }
        // �Ӷ��׻��
        var outShadow = shadowQueue.Dequeue();
        // �������ã�����������ű��е�OnEnable����
        outShadow.SetActive(true);
        return outShadow;
    }
    #endregion
}
