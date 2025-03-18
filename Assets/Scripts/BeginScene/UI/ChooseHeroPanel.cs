using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ChooseHeroPanel : BasePanel
{
    public Button btnLeft;
    public Button btnRight;
    //购买按钮
    public Button btnUnlock;
    public Text txtUnLock;

    public Button btnStart;
    public Button btnBack;
    //左上角拥有的钱
    public Text txtMoney;
    //角色信息
    public Text txtName;
    //英雄预设体 需要创建在的位置
    private Transform heroPos;
    //当前场景中显示的对象
    private GameObject heroObj;
    //当前使用的数据
    private RoleInfo nowRoleData;
    //当前使用数据的索引
    private int nowIndex;
    public override void Init()
    {
        //找到场景中 放置对象预设体的位置
        heroPos = GameObject.Find("HeroPos").transform;
        //更新左上角玩家拥有的钱
        txtMoney.text=GameDataMgr.Instance.playerData.haveMoney.ToString();
        btnLeft.onClick.AddListener(() =>
        {
            --nowIndex;
            if (nowIndex < 0)
            {
                nowIndex=GameDataMgr.Instance.roleInfoList.Count-1;
            }
            //模型的更新
            ChangeHero();
        });
        btnRight.onClick.AddListener(() =>
        {
            ++nowIndex;
            if (nowIndex>=GameDataMgr.Instance.roleInfoList.Count)
            {
                nowIndex = 0;
            }
            //模型的更新
            ChangeHero();
        });
        btnUnlock.onClick.AddListener(() =>
        {
            //点击解锁按钮的逻辑
            PlayerData data= GameDataMgr.Instance.playerData;
            //有钱时
            if(data.haveMoney>=nowRoleData.lockMoney)
            {
                //购买逻辑
                data.haveMoney-=nowRoleData.lockMoney;
                //更新左上角钱数
                txtMoney.text=data.haveMoney.ToString();
                //记录购买的id
                data.buyHero.Add(nowRoleData.id);
                //保存数据
                GameDataMgr.Instance.SavePlayerData();
                //更新解锁按钮
                UpdateLockBtn();
                //提示面板 显示购买成功
                UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("购买成功");
            }
            else
            {
                //提示面板 显示 金钱不足
                UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("金钱不足");
            }
        });
        btnStart.onClick.AddListener(() =>
        {
            // 记录当前选择的角色
            GameDataMgr.Instance.nowSelRole=nowRoleData;
            //隐藏自己 显示场景选择面板
            UIManager.Instance.HidePanel<ChooseHeroPanel>();
            UIManager.Instance.ShowPanel<ChooseScenePanel>();
            
        });
        btnBack.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ChooseHeroPanel>();
            //让摄像机右转后再显示开始界面
            Camera.main.GetComponent<CameraAnimator>().TurnRight(() =>
            {
                UIManager.Instance.ShowPanel<BeginPanel>();
            });
        });
        //更新模型显示刚开始创建一个
        ChangeHero();
    }
    /// <summary>
    /// 更新场景上要显示的模型
    /// </summary>
    private void ChangeHero()
    {
        if(heroObj != null)
        {
            Destroy(heroObj);
            heroObj = null;
        }
        //取出数据的一条 根据索引值
        nowRoleData = GameDataMgr.Instance.roleInfoList[nowIndex];

        //GameObject prefab = Resources.Load<GameObject>(nowRoleData.res);
        //if (prefab == null)
        //{
        //    Debug.LogError($"加载资源失败: {nowRoleData.res}");
        //    return;
        //}
        //实例化对象并记录下来
        heroObj =Instantiate(Resources.Load<GameObject>(nowRoleData.res), heroPos.position, heroPos.rotation);
        //更新上方显示的 描述信息
        txtName.text = nowRoleData.tips;
        //根据解锁相关数据 来决定是否显示解锁按钮
        UpdateLockBtn();
    }
    /// <summary>
    /// 更新解锁按钮显示情况
    /// </summary>
   private void UpdateLockBtn()
    {
        //如果该角色需要解锁 并且没有解锁的话 就应该显示解锁按钮 并且隐藏开始按钮 
        if (nowRoleData.lockMoney > 0 && !GameDataMgr.Instance.playerData.buyHero.Contains(nowRoleData.id))
        {
            btnUnlock.gameObject.SetActive(true);
            txtUnLock.text="¥"+nowRoleData.lockMoney;
            //隐藏开始按钮 因为该角色没有解锁
            btnStart.gameObject.SetActive(false);
        }
        else
        {
            btnUnlock.gameObject.SetActive(false);
            btnStart.gameObject.SetActive(true);
        }
    }
    public override void HideMe(UnityAction callBack)
    {
        base.HideMe(callBack);
        //每次隐藏面板时 删除创建的角色模型
        if(heroObj!=null)
        {
            DestroyImmediate(heroObj); 
            heroObj = null;
        }
    }
}
