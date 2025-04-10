using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlyerScript : MonoBehaviour
{
    public CharacterController characterController;

    //移動の最高速度
    private float maxSpeed = 5.0f;
    //最低速度
    private float minSpeed = 2.0f;
    //旋回速度
    private float turnRate = 7.0f;
    //ベクトル
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        //コントローラー取得
        this.characterController = this.GetComponent<CharacterController>();
        //速度を0にする
        this.velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = this.velocity;
        //移動速度
        float speed = 0.0f;

        //キャラクターが地面に接しているかを判定
        if (this.characterController.isGrounded)
        {
            //パッドのスティック入力を所得して移動ベクトルを作成
            vec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            //入力値が0.1以上なら速さを設定
            if(vec.magnitude > 0.1)
            {
                //スティックの倒し具合で速さを変更
                speed = Mathf.Lerp(this.minSpeed, this.maxSpeed, vec.magnitude);

                //向きの変更
                Vector3 dir = vec.normalized;
                float rotate = Mathf.Acos(dir.z);
                if (dir.x < 0) rotate = -rotate;
                rotate *= Mathf.Rad2Deg;
                Quaternion Q = Quaternion.Euler(0, rotate, 0);

                //モデルの向きを変更
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Q, this.turnRate);
                
            }
            //移動ベクトルを正規化
            vec = vec.normalized;
        }

        //移動速度を設定
        this.velocity.x = vec.x * speed;
        this.velocity.y = vec.y;
        this.velocity.z = vec.z * speed;

        //重力による落下を設定
        this.velocity.y += Physics.gravity.y * Time.deltaTime;

        //移動させる
        this.characterController.Move(this.velocity * Time.deltaTime);

    }
}
