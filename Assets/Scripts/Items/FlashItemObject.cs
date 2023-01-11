using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class FlashItemObject : MonoBehaviour
{
    private bool isPicked;
    private FlashItem item;

    [SerializeField]
    [Tooltip("��������")]
    private string itemName;

    [SerializeField]
    [Tooltip("ʹ����ȴʱ��")]
    private float coolDownTime;

    [SerializeField]
    [Tooltip("���־���")]
    private float flashDistance;

    // Start is called before the first frame update
    void Start()
    {
        this.isPicked = false;
        this.item = new FlashItem(this.itemName, this.coolDownTime, this.flashDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isPicked)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(this.itemName + "���ߴ�����ײ");
        if (Item.IsHolder(collider.gameObject))
        {
            this.item.SetHolder(collider.gameObject);
            this.item.Start();
            collider.gameObject.SendMessage("AddItem", this.item);
            this.isPicked = true;
        }
    }


}

namespace Items
{
    public class FlashItem: Item
    {
        private bool isReady;
        private float coolDownTime;
        private float flashDistance;

        public FlashItem(string name, float time, float dis)
        {
            this.name = name;
            this.coolDownTime = time;
            this.flashDistance = dis;
            this.isReady = false;
        }

        public void Start()
        {
            this.isReady = true;
        }

        private void CoolDown()
        {
            Timer timer = new Timer(args =>
            {
                try
                {
                    this.isReady = true;
                    Debug.Log(this.name + "��ȴʱ�����");
                } catch (Exception)
                {
                    Debug.Log(this.name + "��ȴʱ�׳��쳣,�Ժ�����");
                    Thread.Sleep(100);
                    this.CoolDown();
                }
            }, null, (int)(this.coolDownTime * 1000), Timeout.Infinite);
        }

        public override void ItemInvoke()
        {
            if (this.isReady)
            {
                this.isReady = false;
                this.holder.SendMessage("ActivateFlash", this.flashDistance);
                this.CoolDown();
            } 
        }
    }
}
