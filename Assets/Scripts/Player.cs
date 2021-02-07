using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    //プレイヤーオブジェクトにアタッチするcs
    public GameController gameController;
    public float moveSpeed;//前進速度
    public float roteSpeed;//回転速度

    Vector3 derection;
    Animator animator;
    CharacterController controller;

    float hp = 100f;

    //他クラスからhpを取得するためのプロパティ
    public float Hp
    {
        get
        {
            return this.hp;
        }

        set
        {
            this.hp = value;
        }
    }

	void Start () {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();       
	}
		
	void Update () {
        //まずフルーツオブジェクトの位置をプレイヤーに確認させるため
        //オブジェクトを回転させる
        if (gameController.PlayMode)
        {
            //ゲームクリア又はゲームオーバーならプレイヤーの動きを止める
            if (gameController.IsGameOver || gameController.IsGameClear)
            {
                derection.z = 0.0f;
            }
            else
            {
                //前進のみさせたいためZ軸には-の値が入らない様にする
                if (Input.GetAxis("Vertical") > 0.0f)
                {
                    derection.z = Input.GetAxis("Vertical");
                }
                else
                {
                    derection.z = 0.0f;
                }
                transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
            }
            Vector3 globalDerection = transform.TransformDirection(derection);
            controller.Move(globalDerection * moveSpeed * Time.deltaTime);
            animator.SetFloat("Speed", controller.velocity.magnitude);
        }
        else
        {
            transform.Rotate(0, 30 * Time.deltaTime, 0);
        }             
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "enemy")
        {
            //ゲームクリアした時にタイトルシーンに遷移する前にもしHpが0になれば
            //ゲームオーバーとなるためそうならない様に条件を付ける
            if (!gameController.IsGameClear)
            {
                this.hp -= 35f;
                Destroy(other.gameObject);
            }
            
        }
    }
}
