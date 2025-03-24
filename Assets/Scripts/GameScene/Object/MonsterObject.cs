using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterObject : MonoBehaviour
{
    //出生过后再移动
    private Animator animator;
    //移动--寻路组件
    private NavMeshAgent agent;

    //一些不变的基础数据
    private MonsterInfo monsterInfo;
    //当前血量
    private int hp;
    //怪物是否死亡
    public bool isDead=false;
  
    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    //初始化
    public void IninInfo(MonsterInfo info)
    {
        monsterInfo = info;
        //状态机加载
        animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(info.animator);
        //要变的当前血量
        hp=info.hp;
        //速度和 加速度 初始化 
        agent.speed =agent.acceleration= info.moveSpeed;
        //旋转速度
        agent.angularSpeed = info.roundSpeed;
    }
    //受伤
    public void Wound(int dmg)
    {
        if (isDead)
            return;
        hp -=dmg;
        //播放受伤动画
        animator.SetTrigger("Wound");
        if(hp<=0)
        {
            //死亡

        }
        else
        {
            //播放音效
        }
    }
    //死亡
    public void  IsDead()
    {
        isDead = true;
        //停止移动
        agent.isStopped = true;
        //播放死亡动画
        animator.SetBool("Dead", true);
        //播放音效

        //加钱
    }
    public void DeadEvent()
    {
        //死亡动画播放完后 移除对象
    }
    //出生后再移动
    public void BornOver()
    {
        agent.SetDestination(MainTowerObject.Instance.transform.position);
        //播放移动动画
        animator.SetBool("Run", true);

    }



    //上一次攻击的时间
    private float frontTime = 0;
    // Update is called once per frame
    void Update()
    {
        //检测什么时候停下来攻击
        if(isDead)
        {
            return;
        }
        //根据速度来决定动画播放什么
        animator.SetBool("Run", agent.velocity != Vector3.zero);
        //检测和目标点达到移动条件时 就攻击
        if (Vector3.Distance(this.transform.position, MainTowerObject.Instance.transform.position) < 5&&
            Time.time-frontTime>=monsterInfo.atkOffset)
        {
            frontTime = Time.time;
            animator.SetTrigger("Atk");
        }
          
    }

    //攻击--伤害检测
    public void AtkEvent()
    {
        //范围检测 进行伤害判断
        Collider[] colliders=Physics.OverlapSphere(this.transform.position + this.transform.forward + this.transform.up, 1, 1 << LayerMask.NameToLayer("MainTower"));
        for(int i= 0; i < colliders.Length; i++)
        {
            if (MainTowerObject.Instance.gameObject == colliders[i].gameObject)
            {
                //让保护区域受到伤害
                MainTowerObject.Instance.Wound(monsterInfo.atk);
            }
        }
    }
}
