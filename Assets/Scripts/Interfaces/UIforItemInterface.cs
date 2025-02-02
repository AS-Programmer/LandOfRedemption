﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interfaces
{
    public interface IUIforItemInterface
    {
        //与黑板互动时显示密码UI
        public void ShowBlackBoardContent();

        //与黑板互动时关闭密码UI
        public void HideBlackBoardContent();

        //查看日记本内容UI
        public void ShowDiaryContent();

        //收起日记本内容UI
        public void HideDiaryContent();

        //打开保险箱的密码界面
        public void ShowPasswordUI();

        //关闭保险箱的密码界面
        public void HidePasswordUI();

        //输入密码UI， number：0-9的数字字符
        public void InputPassword(char number);

        //输入密码清空
        public void InputClear();

        //道具添加时的UI展示，name：道具名称
        public void AddItem(string name);

        //道具移除时的UI展示，name：道具名称
        public void RemoveItem(string name);

        //展示道具时的UI展示，name：道具名称
        public void ShowItem(string name);

        //使用道具UI展示
        public void UseItem();
    }
}