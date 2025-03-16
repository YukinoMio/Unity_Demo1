using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public abstract class BasePanel : MonoBehaviour//�����಻��new���� ֻ�ܼ̳�ʹ��
{
    //ר�����ڿ������͸���ȵ����
    private CanvasGroup canvasGroup;
    //���뵭�����ٶ�
    private float alphaSpeed = 10;
    //��ǰ�����ػ�����ʾ
    public bool isShow = false;
    //��������Ϻ���Ҫ��������
    private UnityAction hideCallBack = null;
    protected virtual void Awake()
    {
        //һ��ʼ�ͻ�ȡ����Ϲ��ص����
        canvasGroup = GetComponent<CanvasGroup>();  
        //���������� CanvasGroup���
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
    /// ע��ؼ��¼��ķ��� ��������� ����Ҫȥע��һЩ�ؼ��¼�
    /// </summary>
    public abstract void Init();
    /// <summary>
    /// ��ʾ�Լ�ʱ�����߼�
    /// </summary>
    public virtual void ShowMe()
    {
        canvasGroup.alpha = 0;
        isShow = true;
    }
    /// <summary>
    /// ����ʱ
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
        //��������ʾ״̬ʱ ���͸���Ȳ�Ϊ1 �ͻ᲻ͣ�ļӵ�1  �ӵ�1 ���� ��ֹͣ�仯��
        //����
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
                //����� ͸���� ������ɺ� ��Ҫִ�е��߼�
                hideCallBack?.Invoke();
            }
        }
    }
}
