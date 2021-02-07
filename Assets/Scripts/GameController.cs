using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    //空オブジェクトGameControllerにアタッチ

    public GameObject[] fruitsObjects;//取得するフルーツオブジェクトの配列
    public GameObject playModeOnBuuton; //メインシーンに入りゲームの説明をするボタンオブジェクト
    public Text getFruitaCountText;//現在のフルーツの取得数を表示するテキスト
    public Text gameText;//ゲームオーバーかゲームクリア時に表示するテキスト
    public Text playTimeCountText;//現在のプレイタイムを表示するテキスト
    public Player p;//ゲームクリア、ゲームオーバーを管理するためプレイヤーcsを取得
    int playTime;//プレイタイム
    int getFruitCount;//フルーツカウント数
    bool isPlayMode;//ゲームを開始してよいかの真偽値
    bool isGameOver;//ゲームクリアしたかどうかの真偽値
    bool isGameClear;//ゲームオーバーしたかどうかの真偽値

    //以下各フィールドのプロパティ、GetFruitCountのみGetFluitu.csでインクリメントしているため
    //setを記述、それ以外はget(読み取り)のみ

    //フルーツカウントのプロパティ
    public int GetFruitCount
    {
        get
        {
            return this.getFruitCount;
        }

        set
        {
            this.getFruitCount = value;
        }
    }

    //プレイモードのプロパティ
    public bool PlayMode
    {
        get
        {
            return this.isPlayMode;
        }

    }

    //ゲームオーバーのプロパティ
    public bool IsGameOver
    {
        get
        {
            return this.isGameOver;
        }
    }

    //ゲームクリアのプロパティ
    public bool IsGameClear
    {
        get
        {
            return this.isGameClear;
        }
    }
	void Start () {
        //ゲームクリアかゲームオーバーかのテキストは非表示にする
        gameText.enabled = false;   
	}
	
	
	void Update () {
        //現在のプレイタイムをToStringで文字列連結させる
        playTimeCountText.text = "Time" + playTime.ToString();
        //現在の取得したフルーツの数をToStringで文字列連結させる
        getFruitaCountText.text = "GetFruits" + GetFruitCount.ToString();
        

        if (isPlayMode)
        {
            //プレイタイムが0かHpが0になったらゲームオーバー
            if (p.Hp <= 0.0f || playTime <= 0)
            {
                isGameOver = true;
            }

            //取得したフルーツの数が配列の要素数と一緒ならゲームクリア
            if(getFruitCount == fruitsObjects.Length)
            {
                isGameClear = true;
            }

            //ゲームクリアかゲームオーバーならゲームクリア又はゲームオーバーのテキストを表示
            if (isGameOver || isGameClear)
            {
                gameText.enabled = true;
                
                if (isGameOver)
                {
                    gameText.text = "GAMEOVER";//ゲームオーバーならテキストをゲームオーバーに変える
                }
                else
                {
                    gameText.text = "GAMECLEAR!";//ゲームクリアならゲームクリアにテキストを変える
                }
                Invoke("ReturnToTitle", 2.0f);//2秒後にタイトルシーンへ遷移
            }
        }
                  
    }

    //ゲームをスタートさせるボタンに使うイベントハンドラ
    public void PlayModeOn()
    {
        //押されたらゲームスタートにさせる
        this.isPlayMode = true;
        //押されたらボタンの表示を切る
        playModeOnBuuton.SetActive(false);
        //プレイタイムのカウントを開始させるためのコルーチン
        StartCoroutine(PlayTimeCount());
    }

    //プレイタイムのカウントを開始させるためのコルーチン
    IEnumerator PlayTimeCount()
    {
        playTime = 60;
        //プレイタイムが0又はゲームクリアまでプレイタイムをデクリメント
        while (playTime > 0 && !IsGameClear)
        {
            yield return new WaitForSeconds(1.0f);
            playTime--;
        }
    }

    //ゲームクリアかゲームオーバー時にタイトルシーンに遷移させるための関数
    void ReturnToTitle()
    {
        SceneManager.LoadScene("title");
    }

   
}
