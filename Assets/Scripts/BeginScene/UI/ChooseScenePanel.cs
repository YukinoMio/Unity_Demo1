using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseScenePanel : BasePanel
{
    public Button btnLeft;
    public Button btnRight;
    public Button btnStart;
    public Button btnBack;
    //�����ı���ͼƬ����
    public Text txtInfo;
    public Image imgScene;
    //��¼��ǰ��������
    private int nowIndex;
    //��¼��ǰѡ�������
    private SceneInfo nowSceneInfo;
    public override void Init()
    {
        btnLeft.onClick.AddListener(() =>
        {
            --nowIndex;
            if (nowIndex < 0)
            {
                nowIndex = GameDataMgr.Instance.sceneInfoList.Count - 1;
            }
            ChangeScene();
        });
        btnRight.onClick.AddListener(() =>
        {
            ++nowIndex;
            if (nowIndex >=GameDataMgr.Instance.sceneInfoList.Count)
            {
                nowIndex = 0;
            }
            ChangeScene();
        });
        btnStart.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ChooseScenePanel>();
            //�л�����

        });
        btnBack.onClick.AddListener(() =>
        {
            //
            UIManager.Instance.HidePanel<ChooseScenePanel>();
            //�����ϼ�
            UIManager.Instance.ShowPanel<ChooseHeroPanel>();
        });
        //һ������ʼ��ʱ ҲӦ�ø���
        ChangeScene();
    }
    /// <summary>
    /// �л�������ʾ����Ϣ
    /// </summary>
    public void  ChangeScene()
    {
        nowSceneInfo = GameDataMgr.Instance.sceneInfoList[nowIndex];
        //����ͼƬ����ʾ��������Ϣ
        imgScene.sprite = Resources.Load<Sprite>(nowSceneInfo.imgRes);
        txtInfo.text = "���ƣ�\n" + nowSceneInfo.name + "\n" + "����:\n" + nowSceneInfo.tips;
    }
}
