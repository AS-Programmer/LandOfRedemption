using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items {

    //���߳�����
    public abstract class Item
    {
        //��������
        protected string name;
        //���߳�����
        protected GameObject holder;
        //���ߵ��÷���
        public abstract void ItemInvoke();

        public virtual void SetName(string name)
        {
            this.name = name;  
        }

        public virtual string GetName()
        {
            return this.name;
        }

        public static bool IsHolder(GameObject obj)
        {
            return (obj.GetComponent("ItemHolder")) ? true : false;
        }

        public virtual void SetHolder(GameObject obj)
        {
            this.holder = obj;
        }
    }
}
