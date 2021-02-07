using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleControler : MonoBehaviour {
    //空オブジェクトのTitleContorollerにアタッチ

    public GameObject[] gameObjects;//タイトルシーンで回転させるためのオブジェクト配列
	
    //演出のためオブジェクトを回転させる
	void Update () {
		foreach(GameObject gameObject in gameObjects)
        {
            gameObject.transform.Rotate(0, 40 * Time.deltaTime, 0);
        }
	}

    //スタートボタンをクリックした時に使用するイベントハンドラ
    public void OnStartBuutonClicekd()
    {
        SceneManager.LoadScene("main");
    }

    //endボタンをクリックした時に使用するイベントハンドラ
    public void OnEndButtonClicked()
    {
        Application.Quit();
    }
}
