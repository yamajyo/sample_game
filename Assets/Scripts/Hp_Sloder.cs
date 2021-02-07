using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp_Sloder : MonoBehaviour {
    //Hpバー（Slider）オブジェクトにアタッチ

    public Player p;
    Slider hpSlider;
    
	void Start () {
        //Sliderコンポーネントを取得した上でPlayer.csよりHpを取得し代入
        hpSlider = GetComponent<Slider>();
        hpSlider.maxValue = p.Hp;
        hpSlider.value = p.Hp;       
	}
	
	void Update () {
        hpSlider.value = p.Hp;
	}
}
