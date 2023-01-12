using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    private Animator anim; // Monster ��������
    private Rigidbody2D rbody; // �����˶�ȷ��λ��
    float changeTimer;  // ����һ����ʱ�� ����ʱ��͸ı䷽��
    Vector2 moveDirection;
    private PlayerMovement pm; // ������ ��ҽű�
    private static float y;  // ��¼��ʼy��λ��

    [Header("Monster ����")]
    [Tooltip("Monster �ƶ��ٶ�")]
    [SerializeField]
    public float moveSpeed = 1f;
    [Tooltip("��ʱ������")]
    [SerializeField]
    public float changeDirectionTime = 2f;
    [Header("׷������")]
    [Tooltip("�Ƿ��Զ�׷�����")]
    [SerializeField]
    public bool isChasing = false;
    [Tooltip("�������")]
    [SerializeField]
    public Transform target;
    [Tooltip("׷����Χ")]
    [SerializeField]
    public float rangDistance = 1f;
    [Tooltip("Monster ׷���ٶ�")]
    [SerializeField]
    public float chaseSpeed = 1.5f;

    public Animator playerAnim;



    void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        changeTimer = changeDirectionTime;  // ��ʼ����ʱ��
        moveDirection = Vector2.left;
        //pm = GameObject.Find("Player").GetComponent<PlayerMovement>();  // �ҵ���ҽű�
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if (isChasing && Vector2.Distance(transform.position, target.position) < rangDistance)
        {
            ChasingAnim();
            Chase();
            //Debug.Log("��ʼ׷��");
        }
        else
        {

            if (transform.position.y != y)
            {
               //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, y, 0), 2 * Time.deltaTime);
            }
            ChangeMoving();
        }

    }

    #region ������ײ����
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            // ��������� ���� �ű� �� �������� ����
            playerAnim.SetTrigger("die");
            Debug.Log("�����군");
            Invoke("LoadScene",1f);
        }

        if (collision.gameObject.tag == "Monster")
        {
            gameObject.SetActive(false);
            Debug.Log("�����군");
        }

    }
    #endregion

    void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    #region �ı��ƶ�����
    private void ChangeMoving()
    {
        changeTimer -= Time.deltaTime;  // ʱ��һ������
        if (changeTimer < 0)  // ��ʱ��С��0 �ı䷽��
        {
            moveDirection = moveDirection * -1;
            changeTimer = changeDirectionTime; // ���³�ʼ��
            //Debug.Log("ת�䷽��");
        }

        UsingAnim();
        rbody.velocity = moveDirection * moveSpeed;

    }
    #endregion

    #region ׷�𷽷�
    public void Chase()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, chaseSpeed * Time.deltaTime);

    }

    #endregion

    #region ����׷�𶯻�����
    public void ChasingAnim()
    {
        if (transform.position.x > target.position.x)
        {
            anim.SetBool("turn", false);
        }
        else
        {
            anim.SetBool("turn", true);
        }
    }
    #endregion

    #region ����Ѳ�߶���
    public void UsingAnim()
    {
        if (moveDirection == Vector2.left)
        {
            anim.SetBool("turn", false);
        }
        else
        {
            anim.SetBool("turn", true);
        }
    }
    #endregion

}
