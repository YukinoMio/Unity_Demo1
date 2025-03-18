using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginPanel : BasePanel
{
    public Button btnStart;
    public Button btnSetting;
    public Button btnQuit;
    public override void Init()
    {
        //Debug.Log("BeginPanel ��ʼ�����");
        btnStart.onClick.AddListener(() =>
        {
            //�����������ת���� Ȼ������ʾѡ�����
            Camera.main.GetComponent<CameraAnimator>().TurnLeft(() =>
            {
                UIManager.Instance.ShowPanel<ChooseHeroPanel>();
            });
            //�����Լ� ��ʾѡ�����
            UIManager.Instance.HidePanel<BeginPanel>();

        });
        btnSetting.onClick.AddListener(() =>
        {
            //��ʾ���ý���
            UIManager.Instance.ShowPanel<SettingPanel>();
        });
        btnQuit.onClick.AddListener(() =>
        {
            //�˳�
            Application.Quit();
        });
    }
}
