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
        //Debug.Log("BeginPanel 初始化完成");
        btnStart.onClick.AddListener(() =>
        {
            //播放摄像机左转动画 然后再显示选角面板
            Camera.main.GetComponent<CameraAnimator>().TurnLeft(() =>
            {
                UIManager.Instance.ShowPanel<ChooseHeroPanel>();
            });
            //隐藏自己 显示选角面板
            UIManager.Instance.HidePanel<BeginPanel>();

        });
        btnSetting.onClick.AddListener(() =>
        {
            //显示设置界面
            UIManager.Instance.ShowPanel<SettingPanel>();
        });
        btnQuit.onClick.AddListener(() =>
        {
            //退出
            Application.Quit();
        });
    }
}
