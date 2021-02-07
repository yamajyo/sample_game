using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetFluits : MonoBehaviour {
    //フルーツオブジェクトにアタッチ
   
    public GameController gameController;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            gameController.GetFruitCount++;
            //敵オブジェクトの回転の中心となるオブジェクトが子オブジェクトにあるため
            //Destroy関数ではなくSetActiveで表示を消す
            this.gameObject.SetActive(false);        
        }
    }

  
}
