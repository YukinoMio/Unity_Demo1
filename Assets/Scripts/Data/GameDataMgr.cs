using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataMgr 
{
   private static GameDataMgr instance=new GameDataMgr();
    public static GameDataMgr Instance=>instance;
    //��¼ѡ��Ľ�ɫ���� ����֮�������Ϸ�����д���
    public RoleInfo nowSelRole;
    //��Ч�������
   public MusicData musicData;
    //����������
    public PlayerData playerData;

    public List<RoleInfo> roleInfoList;

    //���еĳ�������
    public List<SceneInfo> sceneInfoList;
    private GameDataMgr() 
    {
        //��ʼ��һЩ����
        musicData = JsonMgr.Instance.LoadData<MusicData>("MusicaData");
        //��ȡ��ʼ���������
        playerData = JsonMgr.Instance.LoadData<PlayerData>("PlayerData");
        //��ȡ��ɫ����
        roleInfoList = JsonMgr.Instance.LoadData<List<RoleInfo>>("RoleInfo");
        //��ȡ��������
        sceneInfoList = JsonMgr.Instance.LoadData<List<SceneInfo>>("SceneInfo");
    }
    /// <summary>
    /// �洢��Ч����
    /// </summary>
    public void SavaMusicData()
    {
        JsonMgr.Instance.SaveData(musicData, "MusicData");
    }
    /// <summary>
    /// �洢�������
    /// </summary>
    public void SavePlayerData() 
    {
        JsonMgr.Instance.SaveData(playerData, "PlayerData");
    }
}
