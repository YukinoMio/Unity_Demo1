using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr 
{
   private static GameDataMgr instance=new GameDataMgr();
    public static GameDataMgr Instance=>instance;
    //��Ч�������
   public MusicData musicData;
    private GameDataMgr() 
    {
        //��ʼ��һЩ����
        musicData = JsonMgr.Instance.LoadData<MusicData>("MusicaData");
    }
    /// <summary>
    /// �洢��Ч����
    /// </summary>
    public void SavaMusicData()
    {
        JsonMgr.Instance.SaveData(musicData, "MusicData");
    }
}
