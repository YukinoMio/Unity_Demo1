using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKMusic : MonoBehaviour
{
    private static BKMusic instance;
    public static BKMusic Instance=>instance;
    private AudioSource bkSource;
    private void Awake()
    {
        instance = this; 
        bkSource = GetComponent<AudioSource>();
        //ͨ������ ������ ���ֵĴ�С�Ϳ���
        MusicData data = GameDataMgr.Instance.musicData;
        SetIsOpen(data.musicOpen);
        ChangeValue(data.musicValue);
    }

    //���ر������ֵķ���
    public void SetIsOpen(bool isOpen)
    {
        bkSource.mute = !isOpen;
    }

    //�����������ִ�С�ķ���
    public void ChangeValue(float v)
    {
        bkSource.volume = v;
    }
    // Start is called before the first frame update
 
}
