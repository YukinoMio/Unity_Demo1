using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraAnimator : MonoBehaviour
{
    private Animator animator;
    //���ڼ�¼����������ɺ� ����Ҫ��������ĺ���
    private UnityAction overAction;
    // Start is called before the first frame update
    void Start()
    {
        animator=this.GetComponent<Animator>();
        
    }
    //��ת
    public void TurnLeft(UnityAction action)
    {
        animator.SetTrigger("Left");
        overAction=action;
    }
    //��ת
    public void TurnRight(UnityAction action)
    {
        animator.SetTrigger("Right");
        overAction =action;
    }
    //������������ʱ ����õķ���
    public void PlayerOver()
    {
        overAction?.Invoke();
        overAction = null;
    }

}
