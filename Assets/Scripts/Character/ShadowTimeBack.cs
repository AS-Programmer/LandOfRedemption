using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowTimeBack : MonoBehaviour
{
    private Transform player; // Player ����

    private SpriteRenderer currentSprite; // ��ǰͼ��
    private SpriteRenderer playerSprite; // ���ͼ��

    private Color color;

    [Header("ʱ����Ʋ���")]
    [SerializeField]
    private float activeTime; // ��ʾʱ��
    [SerializeField]
    private float activeStart; // ��ʼʱ��

    [Header("��͸����")]
    [SerializeField]
    private float alpha; // ��͸����
    [SerializeField]
    [Range(0f, 1f)]
    private float alphaSet; // ��ʼ͸����
    [SerializeField]
    [Range(0f, 1f)]
    private float alphaMultiplier; // ͸��������

    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        currentSprite.sprite = playerSprite.sprite;
        transform.position = player.position;
        transform.rotation = player.rotation;
        transform.localScale = player.localScale;
        activeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        alpha *= activeTime*alphaMultiplier;
        color = new Color(1, 1, 1, alpha);
        currentSprite.color = color;
        if (Time.time > activeTime + activeStart)
        {
            // ɾ��ջ����Ķ���
            Destroy(gameObject);
        }
    }
}
