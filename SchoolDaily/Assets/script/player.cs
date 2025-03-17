using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    // 单例实例
    private static player _instance;
    public static player Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<player>();
                if (_instance == null)
                {
                    GameObject obj = new GameObject("player");
                    _instance = obj.AddComponent<player>();
                }
            }
            return _instance;
        }
    }

    [SerializeField]
    public float speed = 3;
    public Animator anim;
    Vector2 deirction = Vector2.zero;
    private bool isPlayerControlEnabled = true;
    void Update()
    {
        if (isPlayerControlEnabled && deirction.magnitude > 0)
        {
            anim.SetBool("iswalking", true);
            print(anim.GetBool("iswalking"));
            anim.SetFloat("Horizontal", deirction.x);
            anim.SetFloat("Vertical", deirction.y);

        }
        else
        {
            anim.SetBool("iswalking", false);

        }
    }
    void FixedUpdate()
    {
        if (isPlayerControlEnabled)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            deirction.x = x;
            deirction.y = y;
            transform.Translate(speed * deirction * Time.deltaTime);

        }

    }
    public void SetPlayerControl(bool enabled)
    {
        isPlayerControlEnabled = enabled;
    }


    // 移动到目标位置的逻辑
    public void MoveToTarget(Vector3 targetPosition)
    {
        StartCoroutine(MoveToPosition(targetPosition));
    }
    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        anim.SetBool("iswalking", true);

        while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            // 计算移动方向
            Vector3 direction = (targetPosition - transform.position).normalized;

            // 更新动画参数
            anim.SetFloat("Horizontal", direction.x);
            anim.SetFloat("Vertical", direction.y);

            // 移动玩家
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            yield return null; // 等待下一帧
        }

        anim.SetBool("iswalking", false);
        Debug.Log("玩家到达目标位置");
    }

}
