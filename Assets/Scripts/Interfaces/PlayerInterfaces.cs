using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerInterfaces
{
    ////激活护盾，参数time：持续时间
    public void ActivateSheild(float time);

    //将人物移动到vector位置
    public void ToPosition(Vector3 vector);

    //将人物根据朝向闪现distance个单位
    public void ActivateFlash(float distance);

    public bool IsDie();
    public bool IsHurt();
}
