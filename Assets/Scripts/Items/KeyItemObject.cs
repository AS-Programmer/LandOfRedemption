using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class KeyItemObject : MonoBehaviour
{
    //�Ƿ�ʰȡ
    private bool isPicked;
    private KeyItem item;

    [SerializeField]
    [Tooltip("Կ������")]
    private string itemName;

    // Start is called before the first frame update
    void Start()
    {
        this.isPicked = false;
        this.item = new KeyItem(this.itemName);
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
        Debug.Log(this.itemName + "���ߴ�����ײ");
        if (Item.IsHolder(collider.gameObject))
        {
            this.item.SetHolder(collider.gameObject);
            collider.gameObject.SendMessage("AddItem", this.item);
            this.isPicked = true;
        }
    }
}

namespace Items
{
    public class KeyItem: Item
    {
        public KeyItem(string name)
        {
            this.name = name;
        }

        public override void ItemInvoke()
        {
            Debug.Log("ʹ��" + this.GetName() + "��������ʲô��û������");
        }
    }
}