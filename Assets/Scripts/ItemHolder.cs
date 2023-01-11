using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class ItemHolder : MonoBehaviour
{
    // �б��洢��������
    private List<string> itemNames;
    //�ֵ�洢���߶���
    private Dictionary<string, Item> collectedItems;
    // ��ǰָ��ĵ���
    private int itemIndex;

    //Я����������֡�Ƿ�ʹ��
    private bool isItemUsed;
    //Я�������л�������֡�Ƿ���
    private bool isItemSwitched;
    //�����ĳ�������
    private List<GameObject> nearbyItems;

    [SerializeField]
    [Tooltip("����������ȴʱ��")]
    private float coolDownTime;

    // Start is called before the first frame update
    void Start()
    {
        this.itemNames = new List<string>();
        this.collectedItems = new Dictionary<string, Item>();
        this.itemIndex = 0;
        this.isItemUsed = false;
        this.isItemSwitched = false;
        this.nearbyItems = new List<GameObject>();
}

    // Update is called once per frame
    void Update()
    {
        KeyBoardItemInvoke();
        KeyBoardItemSwitch();
        /*if (Input.GetKey(KeyCode.M))
        {
            string s = "Item Names: ";
            foreach (string name in itemNames)
            {
                s += (name + ", ");
            }
            Debug.Log(s);
            s = "Items: ";
            foreach (string name in collectedItems.Keys)
            {
                s += (name + ", ");
            }
            Debug.Log(s);
        }*/
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (Item.IsItem(collider.gameObject))
        {
            this.nearbyItems.Add(collider.gameObject);
        }
        Debug.Log(collider.gameObject.name + "��ײ����⵽" + this.nearbyItems.Count.ToString() + "����������");
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        this.nearbyItems.Remove(collider.gameObject);
        Debug.Log(collider.gameObject.name + "�뿪����⵽" + this.nearbyItems.Count.ToString() + "����������");
    }

    #region ����itemIndexָ��ĵ���: K��ʹ�� / ���ó������ߣ�E��ʹ��
    void KeyBoardItemInvoke()
    {
        if (!this.isItemUsed && Input.GetKey(KeyCode.K) && this.itemNames.Count > 0)
        {
            this.isItemUsed = true;
            string itemName = this.itemNames[this.itemIndex];
            if (this.collectedItems.ContainsKey(itemName))
            {
                Debug.Log("ʹ��" + itemName + "����");
                this.collectedItems[itemName].ItemInvoke();
            }
            Invoke("SetIsItemUsed", this.coolDownTime);
            Debug.Log("ʣ���������" + collectedItems.Count);
        }

        if (!this.isItemUsed && Input.GetKey(KeyCode.E) && this.nearbyItems.Count > 0)
        {
            this.isItemUsed = true;
            this.nearbyItems[0].SendMessage("ItemInvoke");
            Invoke("SetIsItemUsed", this.coolDownTime);
            Debug.Log("ʹ������" + this.nearbyItems[0].name);
        }
    }

    private void SetIsItemUsed()
    {
        this.isItemUsed = false;
    }
    #endregion

    #region �����л�: J��L���л����ҵ���
    void KeyBoardItemSwitch()
    {
        if (!this.isItemSwitched && itemNames.Count > 0)
        {
            if (Input.GetKey(KeyCode.J))
            {
                this.isItemSwitched = true;
                this.SetItemIndex(this.itemNames.Count - 1);
                Invoke("SetIsItemSwitched", this.coolDownTime);
                Debug.Log("ѡ�е�" + this.itemIndex.ToString() + "������" + this.itemNames[this.itemIndex] + " ��������Ϊ" + this.itemNames.Count.ToString());
            } else if (Input.GetKey(KeyCode.L))
            {
                this.isItemSwitched = true;
                this.SetItemIndex(1);
                Invoke("SetIsItemSwitched", this.coolDownTime);
                Debug.Log("ѡ�е�" + this.itemIndex.ToString() + "������" + this.itemNames[this.itemIndex] + " ��������Ϊ" + this.itemNames.Count.ToString());
            }
        }
    }

    private void SetIsItemSwitched()
    {
        this.isItemSwitched = false;
    }

    private void SetItemIndex(int offset)
    {
        this.itemIndex = (this.itemIndex + offset) % this.itemNames.Count;
    }
    #endregion

    #region ���߳��������ӵ���
    public void AddItem(Item item)
    {
        this.itemNames.Add(item.GetName());
        this.collectedItems.Add(item.GetName(), item);
        this.SetItemIndex(0);
        Debug.Log("���ӵ���" + item.GetName());
    }
    #endregion

    #region ���߳������Ƴ�����
    public void RemoveItem(string name)
    {
        this.itemNames.Remove(name);
        this.collectedItems.Remove(name);
        Debug.Log("�Ƴ�����" + name);
    }
    #endregion

    public bool Contains(string name)
    {
        return this.itemNames.Contains(name);
    }

}