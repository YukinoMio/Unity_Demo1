using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    private Animator animator;
    //1.玩家属性的初始化
    //攻击力
    private int atk;
    //玩家拥有的钱
    public int money;
    //旋转速度
    private float roundSpeed = 50;
    //持枪对象才有的开火点
    public Transform gunPoint;
   

    // Start is called before the first frame update
    void Start()
    {
        animator=this.GetComponent<Animator>();
    }
    /// <summary>
    /// 初始化玩家基础属性
    /// </summary>
    /// <param name="atk"></param>
    /// <param name="money"></param>
    public void InitPlayerInfo(int atk,int money)
    {
        this.atk = atk;
        this.money = money;
        UpdateMoney();
    }
    // Update is called once per frame
    void Update()
    {
        //2.移动变化 动作变化
        //移动动作的变换 
        animator.SetFloat("VSpeed", Input.GetAxis("Vertical"));
        animator.SetFloat("HSpeed", Input.GetAxis("Horizontal"));
        //旋转
        this.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * roundSpeed*Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetLayerWeight(1, 1);
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetLayerWeight(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Roll");
        }
        if(Input.GetMouseButton(0))
        {
            animator.SetTrigger("Fire");
        }
    }
    //3.攻击动作的不同处理
    /// <summary>
    /// 用于处理刀武器攻击动作的伤害检测事件
    /// </summary>
    public void KnifeEvent()
    {
        //进行伤害检测
        Collider[] colliders = Physics.OverlapSphere(this.transform.position + this.transform.forward + this.transform.up, 1, 1 << LayerMask.NameToLayer("Monster"));
        for (int i = 0; i < colliders.Length; i++)
        {
            //得到碰撞刀的对象上的怪物脚本 让其受伤

        }
    }
    public void ShootEvent()
    {
        //进行射线检测
        //前提是需要开火点
        RaycastHit[] hits=Physics.RaycastAll(new Ray(gunPoint.position, gunPoint.forward), 1000, 1 << LayerMask.NameToLayer("Monster"));
        for(int i = 0; i < hits.Length; i++)
        {

        }
    }
    //4.血量更新 和钱变化的逻辑
    public void UpdateMoney()
    {
        UIManager.Instance.GetPanel<GamePanel>().UpdateMoney(money);
    }
    public void AddMoney(int money)
    {
        //杀怪物加钱 
        this.money += money;
        UpdateMoney();  
    }
}
