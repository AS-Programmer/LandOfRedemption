using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class SheildItemObject : MonoBehaviour
{
    //�Ƿ�ʰȡ
    private bool isPicked;
    private SheildItem item;

    [SerializeField]
    [Tooltip("��������")]
    private string sheildName;
    [SerializeField]
    [Tooltip("���ܳ���ʱ�䣨��λ�룩")]
    private float sheildDurationTime;
    [SerializeField]
    [Tooltip("������Ч����")]
    private int sheildCount;

    // Start is called before the first frame update
    void Start()
    {
        isPicked = false;
        item = new SheildItem(this.sheildName, this.sheildDurationTime, this.sheildCount);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPicked)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(this.sheildName + "���ߴ�����ײ");
        this.item.SetHolder(collider.gameObject);
        collider.gameObject.SendMessage("AddItem", this.item);
        this.isPicked = true;
    }
}

namespace Items
{
    public class SheildItem : Item
    {
        //����ʣ����
        private int count;
        //���ܳ���ʱ��
        private float time;

        public SheildItem(string name, float time, int count)
        {
            this.name = name;
            this.time = time;
            this.count = count;
        }

        public override void ItemInvoke()
        {
            this.count--;
            this.holder.SendMessage("ActivateSheild", time);
            if (this.count <= 0)
            {
                this.holder.SendMessage("RemoveItem", this.GetName());
            }
        }
    }
}
