using UnityEngine;
using System.Collections;

//使用Scene:3Dmode・2Dmode
//用途:敵の爆発のエフェクト操作
//Addするオブジェクト:Bonb

public class BonbScript : MonoBehaviour {

	void Start () {
		AudioSource Bonbsound= GetComponent<AudioSource>();
		//このオブジェクトにセットされているAudioを鳴らす
		Bonbsound.PlayOneShot(Bonbsound.clip);
		//しばらくしたらこのオブジェクトを破壊
		Destroy(this.gameObject,2f);
	}
	
}
