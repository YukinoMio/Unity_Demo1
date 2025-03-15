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
            //隐藏自己 显示选角面板
        });
        btnSetting.onClick.AddListener(() =>
        {
            //显示设置界面
        });
        btnQuit.onClick.AddListener(() =>
        {
            //退出
            Application.Quit();
        });
    }
}
