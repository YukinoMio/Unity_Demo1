using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr 
{
   private static GameDataMgr instance=new GameDataMgr();
    public static GameDataMgr Instance=>instance;
    //记录选择的角色数据 用于之后的在游戏场景中创建
    public RoleInfo nowSelRole;
    //音效相关数据
   public MusicData musicData;
    //玩家相关数据
    public PlayerData playerData;

    public List<RoleInfo> roleInfoList;

    //所有的场景数据
    public List<SceneInfo> sceneInfoList;
    private GameDataMgr() 
    {
        //初始化一些数据
        musicData = JsonMgr.Instance.LoadData<MusicData>("MusicaData");
        //获取初始化玩家数据
        playerData = JsonMgr.Instance.LoadData<PlayerData>("PlayerData");
        //读取角色数据
        roleInfoList = JsonMgr.Instance.LoadData<List<RoleInfo>>("RoleInfo");
        //读取场景数据
        sceneInfoList = JsonMgr.Instance.LoadData<List<SceneInfo>>("SceneInfo");
    }
    /// <summary>
    /// 存储音效数据
    /// </summary>
    public void SavaMusicData()
    {
        JsonMgr.Instance.SaveData(musicData, "MusicData");
    }
    /// <summary>
    /// 存储玩家数据
    /// </summary>
    public void SavePlayerData() 
    {
        JsonMgr.Instance.SaveData(playerData, "PlayerData");
    }
}
