using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr 
{
   private static GameDataMgr instance=new GameDataMgr();
    public static GameDataMgr Instance=>instance;
    //音效相关数据
   public MusicData musicData;
    private GameDataMgr() 
    {
        //初始化一些数据
        musicData = JsonMgr.Instance.LoadData<MusicData>("MusicaData");
    }
    /// <summary>
    /// 存储音效数据
    /// </summary>
    public void SavaMusicData()
    {
        JsonMgr.Instance.SaveData(musicData, "MusicData");
    }
}
