using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    private Transform player; // Player ������

    private SpriteRenderer currentSprite; // ��ǰͼ��
    private SpriteRenderer playerSprite; // ���ͼ��

    private Color color; // ��ɫ

    [Header("ʱ����Ʋ���")]
    [SerializeField]
    private float activeTime; // ��ʾʱ��
    [SerializeField]
    private float activeStart; // ��ʼʱ��

    [Header("��͸����")]
    private float alpha; // ��͸����
    [SerializeField]
    [Range(0f,1f)]
    private float alphaSet; // ��ʼ͸����
    [SerializeField]
    [Range(0f, 1f)]
    private float alphaMultiplier; // ��͸��������ֵ

    /// <summary>
    /// ����ʱ��ִ��һ��
    /// </summary>
    private void OnEnable()
    {
        // �ҵ�Player������,��ǰͼ��playerͼ��
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;

        // �ѵ�ǰ��Ҫ��¼��player����ȫ�����
        currentSprite.sprite = playerSprite.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        transform.localScale = player.localScale;
        activeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // ÿ֡����͸����
        alpha *= alphaMultiplier;
        color = new Color(1, 1, 1, alpha);
        // �޸Ĳ�Ӱ��ɫ
        currentSprite.color = color;
        // ��ǰʱ�� >= ��ʼʱ�� + ��ʾʱ��
        if (Time.time >= activeStart + activeTime)
        {
            // ���ض����
            ShadowPlool.instance.ReturnPool(this.gameObject);
        }
    }
}
