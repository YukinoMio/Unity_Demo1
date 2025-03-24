using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPoint : MonoBehaviour
{
    //怪物有多少波
    public int maxWave;
    //每波怪物有多少只
    public int monsterNumOneWave;
    private int nowNum;

    //怪物ID 这样就可以随机创建不同的怪物 更具多样性
    public List<int> monsterIDs;
    //用于记录当前波 要创建什么id的怪物
    private int nowID;
    //单只怪物创建间隔时间
    public float createOffsetTime;
    //波与波之间的间隔时间
    public float delayTime;
    //第一波怪物创建的间隔时间
    public float firstDelayTime;

    void Start()
    {
        Invoke("CreatWave", firstDelayTime);
    }
    /// <summary>
    /// 开始创建一波的怪物
    /// </summary>
    private void CreatWave()
    {
        //得到当前波怪物的ID是什么
        nowID = monsterIDs[Random.Range(0,monsterIDs.Count)];
        //当前波怪物有多少只
        nowNum = monsterNumOneWave;
        //创建怪物
        CreateMonster();
        //减少波数
        --maxWave;
    }
   //创建怪物
   private void CreateMonster()
    {
        //直接创建怪物
        //取出怪物数据
        MonsterInfo info = GameDataMgr.Instance.monsterInfoList[nowID - 1];

        //创建怪物预设体
        GameObject obj = Instantiate(Resources.Load<GameObject>(info.res), this.transform.position, Quaternion.identity);
        //创建怪物预设体
        MonsterObject monsterObj=obj.AddComponent<MonsterObject>();
        monsterObj.IninInfo(info);

        //创建完一只怪物后 减去要创建的怪物数量1
        --nowNum;
        if(nowNum == 0)
        {
            if(maxWave> 0)
            {
                Invoke("CreatWave", delayTime);
            }
        }
        else
        {
            Invoke("CreateMonster", createOffsetTime);
        }
    }
    public bool CheckOver()
    {
        return nowNum == 0 && maxWave == 0;
    }
}
