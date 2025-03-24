using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    //摄像机看向的对象
    public Transform target;
    //摄像机相对目标对象 在xyz上的偏移位置
    public Vector3 offsetPos;
    //看向位置的y偏移值
    public float bodyHeight;
    //移动和旋转速度
    public float moveSpeed;
    public float rotationSpeed;

    private Vector3 targetPos;
    private Quaternion targetRotation;
  

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }
        //根据目标对象 来计算 摄像机当前的位置和角度

        //位置的计算
        //向后偏移z坐标
        targetPos = target.position + target.forward * offsetPos.z;
        //向上偏移Y坐标
        targetPos += Vector3.up * offsetPos.y;
        //左右偏移X坐标
        targetPos += target.right*offsetPos.x;
        //插值运算 让摄像机不断向摄像机偏移
        this.transform.position = Vector3.Lerp(this.transform.position, targetPos, moveSpeed * Time.deltaTime);
        //旋转的计算
        //得到最终要看向某个点时的四元数
        targetRotation = Quaternion.LookRotation(target.position + Vector3.up * bodyHeight - this.transform.position);
        //让摄像机不停地向目标角度靠拢
        this.transform.rotation=Quaternion.Slerp(this.transform.rotation,targetRotation,rotationSpeed * Time.deltaTime);
    }
    //设置摄像机看向的对象
    public void SetTarget(Transform player)
    {
        target = player;
    }
}
