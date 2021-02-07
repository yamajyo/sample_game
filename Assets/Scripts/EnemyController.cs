using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    //フルーツオブジェクトを回っている敵オブジェクトにアタッチ

    public GameController gameController;
    public float moveSpeed;//回転速度
    public GameObject target;//回転の基準となるオブジェクト
  
    void Update () {
        //プレイモードになるまで回転はさせない
        if (gameController.PlayMode)
        {
            if(!gameController.IsGameClear && !gameController.IsGameOver)
            {
                //設置したオブジェクトを基準に回転させる
                transform.RotateAround(target.transform.position, Vector3.up, moveSpeed * Time.deltaTime);
            }
            else
            {
                //ゲームオーバーかゲームクリアになると回転を止める
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            
        }
       
	}
}
