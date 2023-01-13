using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using System.Linq;

public class UIController : MonoBehaviour , IUIforItemInterface
{
    Dictionary<string, GameObject> dic_total_ui = new Dictionary<string, GameObject>();
    //Dictionary<string, GameObject> dic_current = new Dictionary<string, GameObject>();
    public GameObject skillReversePanel;
    public GameObject skillShieldPanel;
    public GameObject skillDashPanel;
    public GameObject inputListen;
    void Start()
    {
        dic_total_ui.Add("Shadow", skillReversePanel);
        dic_total_ui.Add("Sheild", skillShieldPanel);
        dic_total_ui.Add("Flash", skillDashPanel);
        this.HideAll();
    }
    //��ʾ�ض�����
    public void ShowItem(string name)
    {
        if (name.Equals(""))
        {
            this.HideAll();
        }
        else
        {
            this.HideAll();
            foreach(var dic in dic_total_ui)
            {
                if (name.Contains(dic.Key))
                {
                    dic_total_ui[dic.Key].SetActive(true);
                }
            }
        }
    }
    //�����Ƴ�ʱ��UIչʾ��name���������ƣ�type����������
    public void AddItem(string name)
    {
        /*for (int i = 0; i < dic_total_ui.Count; i++)
        {
            if (name.Equals(dic_total_ui.ElementAt(i).Key))
            {
                dic_current.Add(name,dic_total_ui.ElementAt(i).Value);
                ShowItem(name);
            }
        }*/
    }
    //�����Ƴ�ʱ��UIչʾ��name���������ƣ�type����������
    public void RemoveItem(string name)
    {
        /*for (int i = 0; i < dic_total_ui.Count; i++)
        {
            if (name.Equals(dic_total_ui.ElementAt(i).Key))
            {
                dic_current.Remove(name);
            }
        }*/
    }
    //ʹ�õ��ߺ�ķ���
    public void UseItem()
    {
        //����SkillCoolControl���е�SetIsUsed�����ü���ͼ�꿪ʼ��ȴ
        FindObjectOfType<SkillCoolControl>().SetIsUsed(true);
    }
    //��ڰ廥��ʱ��ʾ����UI
    public void ShowBlackBoardContent()
    {
        
    }
    //��ڰ廥��ʱ�ر�����UI
    public void HideBlackBoardContent()
    {
        
    }

    //�鿴�ռǱ�����UI
    public void ShowDiaryContent()
    {
        
    }
    //�����ռǱ�����UI
    public void HideDiaryContent()
    {

    }
    //�򿪱�������������
    public void ShowPasswordUI()
    {
        
    }
    //�رձ�������������
    public void HidePasswordUI()
    {
        
    }

    //��������UI�� number��0-9�������ַ�
    public void InputPassword(char number)
    {
        
    }

    public void InputClear()
    {

    }

    public void HideAll()
    {
        foreach (var each in dic_total_ui)
        {
            each.Value.SetActive(false);
        }
    }

    
}
