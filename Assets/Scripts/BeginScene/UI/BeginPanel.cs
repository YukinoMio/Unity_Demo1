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
        btnStart.onClick.AddListener(() =>
        {
            //�����Լ� ��ʾѡ�����
        });
        btnSetting.onClick.AddListener(() =>
        {
            //��ʾ���ý���
        });
        btnQuit.onClick.AddListener(() =>
        {
            //�˳�
            Application.Quit();
        });
    }
}
