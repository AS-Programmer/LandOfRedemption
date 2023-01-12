using ClearSky;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Sprint����")]
    [SerializeField]
    private float sprintTime; // ���ʱ��
    private float sprintLeftTime; // ʣ��ʱ��
    private float lastSprint = -10f; // ��һ�γ��ʱ��
    [SerializeField]
    private float sprintCoolTime; // ��ȴʱ��
    [SerializeField]
    private float sprintSpeed; // ����ٶ�
    private bool isSprint = false;
    private float currentGrivity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentGrivity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Time.time >= (lastSprint + sprintCoolTime))
            {
                ReadySprint();
            }
        }
    }

    private void FixedUpdate()
    {
        SprintRun();
        if (isSprint)
        {
            return;
        }
    }

    void ReadySprint()
    {
        isSprint = true;
        // ���ʣ��ʱ�� = ���ʱ��
        sprintLeftTime = sprintTime;
        // ��һ��ʱ����ڰ��³�̼���ʱ��
        lastSprint = Time.time;
    }

    void SprintRun()
    {
        if (isSprint)
        {
            if (sprintLeftTime > 0)
            {
                rb.gravityScale = 0;
                GetComponent<PlayController>().enabled = false;
                rb.velocity = Vector2.right * sprintSpeed * transform.localScale.x;
                sprintLeftTime -= Time.deltaTime;
                ShadowPlool.instance.GetFromPool();
            }
            if (sprintLeftTime < 0)
            {
                isSprint = false;
                rb.gravityScale = currentGrivity;
                GetComponent<PlayController>().enabled = true;
            }
        }
    }
}
