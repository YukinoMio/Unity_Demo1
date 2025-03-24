using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTowerObject : MonoBehaviour
{
    //血量相关
    private int hp;
    private int maxHp;
    //是否死亡
    private bool isDead;

    //能够被别人快速获取到位置
    private static MainTowerObject instance;
    public static MainTowerObject Instance=>instance;
    private void Awake()
    {
        instance = this;
        UpdateHp(100, 100);
    }

    //更新血量
    private void UpdateHp(int hp,int maxHP)
    {
        this.hp = hp;
        this.maxHp = maxHP;
        //更新界面上血量上的显示
        UIManager.Instance.GetPanel<GamePanel>().UpdateTowerHp(hp,maxHp);
    }

    //自己受到伤害
    public void Wound(int dmg)
    {
        //如果保护区域被打死
        if(isDead)
            return;
        //受到伤害
        hp -= dmg;
        if (hp <= 0)
        {
            hp = 0;
            isDead= true;   
            //游戏结束
        }
        //更新血量
        UpdateHp(hp, maxHp);    
    }
    private void OnDestroy()
    {
        instance=null;
    }
}
