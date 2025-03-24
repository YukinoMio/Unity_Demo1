using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelMgr 
{
   private static GameLevelMgr instance=new GameLevelMgr();
    public static GameLevelMgr Instance => instance;
    public PlayerObject player;

    private GameLevelMgr()
    { 
        
    }
    //1.切换到游戏场景时 需要动态创建玩家
    public void InitInfo(SceneInfo info)
    {
        //显示游戏界面
        UIManager.Instance.ShowPanel<GamePanel>();
        //玩家创建
        //获取之前记录的当前选中的玩家数据
        RoleInfo roleInfo = GameDataMgr.Instance.nowSelRole;
        //首先获取到场景中  玩家的出生位置
        Transform heroPos = GameObject.Find("HeroBornPos").transform;
        GameObject heroObj = GameObject.Instantiate(Resources.Load<GameObject>(roleInfo.res),heroPos.position,heroPos.rotation);
        //让玩家对象进行初始化
        player=heroObj.GetComponent<PlayerObject>();
        //初始化玩家的基础属性
        player.InitPlayerInfo(roleInfo.atk, info.money);
        //让摄像机看向动态创建出来的玩家
        Camera.main.GetComponent<CameraMove>().SetTarget(heroObj.transform);
    }
}
