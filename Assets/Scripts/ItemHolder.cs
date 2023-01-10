using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Items;

public class ItemHolder : MonoBehaviour
{
    // �б�洢��������
    private List<string> itemNames;
    //�ֵ�洢���߶���
    private Dictionary<string, Item> collectedItems;
    // ��ǰָ��ĵ���
    private int itemIndex;

    private bool isItemUsed;
    private bool isItemSwitched;
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
}

    // Update is called once per frame
    void Update()
    {
        KeyBoardItemInvoke();
        KeyBoardItemSwitch();
    }

    #region ����itemIndexָ��ĵ���: K��ʹ��
    void KeyBoardItemInvoke()
    {
        if (!this.isItemUsed && Input.GetKey(KeyCode.K))
        {
            this.isItemUsed = true;
            if (this.collectedItems.ContainsKey(this.itemNames[this.itemIndex]))
            {
                print("ʹ�û��ܵ���");
                this.collectedItems[this.itemNames[this.itemIndex]].ItemInvoke();
            }
            Invoke("SetIsItemUsed", this.coolDownTime);
            Debug.Log("ʣ���������" + collectedItems.Count);
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
                this.SetItemIndex(-1);
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

    #region ���߳�������ӵ���
    public void AddItem(Item item)
    {
        this.itemNames.Add(item.GetName());
        this.collectedItems.Add(item.GetName(), item);
        this.SetItemIndex(0);
        Debug.Log("��ӵ���" + item.GetName());
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
}
