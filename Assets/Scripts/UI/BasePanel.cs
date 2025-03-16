using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour//抽象类不能new出来 只能继承使用
{
    //专门用于控制面板透明度的组件
    private CanvasGroup canvasGroup;
    //淡入淡出的速度
    private float alphaSpeed = 10;
    //当前是隐藏还是显示
    public bool isShow = false;
    //当隐藏完毕后想要做的事情
    private UnityAction hideCallBack = null;
    protected virtual void Awake()
    {
        //一开始就获取面板上挂载的组件
        canvasGroup = GetComponent<CanvasGroup>();  
        //如果忘记添加 CanvasGroup组件
        if(canvasGroup == null)
        {
            canvasGroup = this.gameObject.AddComponent<CanvasGroup>();  
        }
    }
    // Start is called before the first frame update
   protected virtual void Start()
    {
        Init();
    }
    /// <summary>
    /// 注册控件事件的方法 所有子面板 都需要去注册一些控件事件
    /// </summary>
    public abstract void Init();
    /// <summary>
    /// 显示自己时做的逻辑
    /// </summary>
    public virtual void ShowMe()
    {
        canvasGroup.alpha = 0;
        isShow = true;
    }
    /// <summary>
    /// 隐藏时
    /// </summary>
    public virtual void HideMe(UnityAction callBack)
    {
        canvasGroup.alpha = 1;
        isShow = false;
        hideCallBack = callBack;
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        //当处于显示状态时 如果透明度不为1 就会不停的加到1  加到1 过后 就停止变化了
        //淡入
        if(isShow&&canvasGroup.alpha!=1)
        {
            canvasGroup.alpha += alphaSpeed*Time.deltaTime;
            if(canvasGroup.alpha >=1 )
            {
                canvasGroup.alpha = 1;
            }
        }
        else if (!isShow&&canvasGroup.alpha!=0)
        {
            canvasGroup.alpha -= alphaSpeed*Time.deltaTime;
            if(canvasGroup.alpha<=0 ) 
            { 
                canvasGroup.alpha=0;
                //让面板 透明度 淡出完成后 想要执行的逻辑
                hideCallBack?.Invoke();
            }
        }
    }
}
