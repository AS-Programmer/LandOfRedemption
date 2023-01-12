using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Items;

public class SafeBoxItemObject : MonoBehaviour, ISceneItem
{
    [SerializeField]
    [Tooltip("����")]
    private string itemName;
    [SerializeField]
    [Tooltip("�ռǱ�")]
    private GameObject diaryItem;
    [SerializeField]
    [Tooltip("������ȴʱ��")]
    private float coolDownTime;
    [SerializeField]
    [Tooltip("����")]
    private string password;

    private SafeBoxItem item;
    private bool isUsing;
    private bool isOpen;
    private bool isPressed;
    private Dictionary<KeyCode, char> keyToNumMaps;
    private StringBuilder inputChars;

    // Start is called before the first frame update
    void Start()
    {
        this.item = new SafeBoxItem(this.itemName);
        this.item.SetHolder(this.gameObject);
        this.isUsing = false;
        this.isOpen = false;
        this.isPressed = false;
        this.keyToNumMaps = new Dictionary<KeyCode, char>()
        {
            {KeyCode.Alpha0, '0' },
            {KeyCode.Alpha1, '1' },
            {KeyCode.Alpha2, '2' },
            {KeyCode.Alpha3, '3' },
            {KeyCode.Alpha4, '4' },
            {KeyCode.Alpha5, '5' },
            {KeyCode.Alpha6, '6' },
            {KeyCode.Alpha7, '7' },
            {KeyCode.Alpha8, '8' },
            {KeyCode.Alpha9, '9' },
            {KeyCode.Keypad0, '0' },
            {KeyCode.Keypad1, '1' },
            {KeyCode.Keypad2, '2' },
            {KeyCode.Keypad3, '3' },
            {KeyCode.Keypad4, '4' },
            {KeyCode.Keypad5, '5' },
            {KeyCode.Keypad6, '6' },
            {KeyCode.Keypad7, '7' },
            {KeyCode.Keypad8, '8' },
            {KeyCode.Keypad9, '9' }
        };
        this.inputChars = new StringBuilder("");
        //
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isOpen)
        {
            Instantiate(this.diaryItem, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    void OnGUI()
    {
        if (this.isUsing)
        {
            //Debug.Log("Enter");
            if (!this.isPressed && Input.anyKey)
            {
                Event e = Event.current;
                if (e.isKey && this.keyToNumMaps.ContainsKey(e.keyCode))
                {
                    this.isPressed = true;
                    this.inputChars.Append(this.keyToNumMaps[e.keyCode]);
                    Debug.Log(this.inputChars.ToString());
                    Invoke("SetIsPressed", this.coolDownTime);
                }
            }

            if (this.password == this.inputChars.ToString())
            {
                //Invoke("SetIsOpen", this.coolDownTime);
                this.SetIsOpen();
                Debug.Log("�������");
            }

            if (this.inputChars.Length >= this.password.Length)
            {
                this.inputChars.Clear();
                Debug.Log("�������");
            }
        }
        else
        {
            this.inputChars.Clear();
            //Debug.Log("�������");
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (Item.IsHolder(collider.gameObject))
        {
            this.item.ItemInvoke();
        }
    }

    public void ItemInvoke()
    {
        this.item.ItemInvoke();
    }

    public void SetIsUsing(bool status)
    {
        this.isUsing = status;
    }

    private void SetIsPressed()
    {
        this.isPressed = false;
    }

    private void SetIsOpen()
    {
        this.isOpen = true;
    }

}

namespace Items
{
    public class SafeBoxItem : Item
    {
        private bool isUsing;
        public SafeBoxItem(string name)
        {
            this.name = name;
            this.isUsing = false;
        }

        public override void ItemInvoke()
        {
            if (!this.isUsing)
            {
                Debug.Log("ʹ��" + this.name);
                //
            }
            else
            {
                Debug.Log("ȡ��" + this.name);
                //
            }
            this.isUsing = !this.isUsing;
            this.holder.SendMessage("SetIsUsing", this.isUsing);
        }
    }
}
