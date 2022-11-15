using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : MonoBehaviour
{
    public static int HP=50;
    public float speed = 10;
    public Joystick joyStick;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject RstButton;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        StartCoroutine(KeepShooting());
    }

    void Update()
    {
        // 取得方向鍵輸入
        // float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");

        // 取得虛擬搖桿輸入
        float h = joyStick.Horizontal;
        float v = joyStick.Vertical;

        // 合成方向向量
        Vector3 dir = new Vector3(h, 0, v);

        // 調整角色面對方向
        // 判斷方向向量長度是否大於 0.1（代表有輸入）
        if (dir.magnitude > 0.1f )
        {
            // 將方向向量轉為角度
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;

            // 使用 Lerp 漸漸轉向
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }

        // 地心引力 (y)
        if (!controller.isGrounded)
        {
            dir.y = -9.8f * 30 * Time.deltaTime;
        }

        // 移動角色位置
        controller.Move(dir * speed * Time.deltaTime);
       
        //血量
        if(HP<=0)
        {
            //Debug.Log("died");
            Destroy(this,1);
            Time.timeScale=0f;
            RstButton.SetActive(true);
        }
    }

    void Fire()
    {
        // 產生出子彈
        Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
    }
IEnumerator KeepShooting()
    {
        while (true)
        {
            // 找到最近的一個目標
            // 取得所有場上 tag 為 Enemy 的物件
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            float miniDist = 9999;
            GameObject miniEnemys = null;
            foreach (GameObject enemy in enemys)
            {
                // 計算距離
                float d = Vector3.Distance(transform.position, enemy.transform.position);
                // 跟上一個最近的比較，有比較小就記錄下來
                if (d < miniDist)
                {
                    miniDist = 5;
                    miniEnemys = enemy;
                }
            }
            // 轉向它
            if (miniEnemys)//最近距離內存在
            {
                var enemydir=Quaternion.LookRotation(miniEnemys.transform.position-transform.position);
                //敵向四元數
                transform.rotation = Quaternion.Slerp(transform.rotation,enemydir,800f*Time.deltaTime);
                //圓轉頭到敵人向用速
            }
            // 射擊
            Fire();

            // 暫停 0.5 秒
            yield return new WaitForSeconds(0.5f);
        }
    }
}