using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : BasePanel
{
    public Button btnClose;
    public Toggle togMusic;
    public Toggle togSound;
    public Slider sliderMusic;
    public Slider sliderSound;
    public override void Init()
    {
        //��ʼ�������ʾ���� ���ݱ��ش洢������ ��������ʼ��
        MusicData data = GameDataMgr.Instance.musicData;
        //��ʼ�����ؿؼ���״̬
        togMusic.isOn = true;
        togSound.isOn = true;  
        //��ʼ���϶����ؼ���С
        sliderMusic.value=data.musicValue; 
        sliderSound.value=data.soundValue;
        btnClose.onClick.AddListener(() =>
        {
            //Ϊ�˽�Լ���� ֻ�е�������ɺ� �ر����ʱ �Ż�ȥ��¼���� ������ д��Ӳ���ϣ��ļ��У�
            GameDataMgr.Instance.SavaMusicData();
            //�����������
            UIManager.Instance.HidePanel<SettingPanel>();
        });
        togMusic.onValueChanged.AddListener((v) =>
        {
            //�ñ������ֽ��п���
            BKMusic.Instance.SetIsOpen(v);
            //��¼���ص�����
            GameDataMgr.Instance.musicData.musicOpen = v;
        });
        togSound.onValueChanged.AddListener((v) =>
        {
            //��¼��Ч�Ŀ�������
            GameDataMgr.Instance.musicData.soundOpen = v;   
        });
        sliderMusic.onValueChanged.AddListener((v) =>
        {
            //�ñ������ִ�С�ı�
            BKMusic.Instance.ChangeValue(v);
            //��¼�������ִ�С
            GameDataMgr.Instance.musicData.musicValue = v;
        });
        sliderSound.onValueChanged.AddListener((v) =>
        {
            //��¼��Ч��С������
            GameDataMgr.Instance.musicData.soundValue = v;
        });
    }
}
