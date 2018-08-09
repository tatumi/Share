using UnityEngine;
using System.Collections;

//使用Scene:3Dmode・2Dmode
//用途:銃口の挙動
//Addするオブジェクト:Enemy

public class MuzzleScript : MonoBehaviour {

	//短時間に連続して撃てないようにインターバルタイムを設ける
	float intervalTime;
	void Start () {
		intervalTime = 0f;
	}
	public Transform Bullet;
	
	
	// Update is called once per frame
	void Update () {
		intervalTime +=  Time.deltaTime;
		if(Input.GetButtonUp("Fire1")){
			if(intervalTime >= 0.2f){
				intervalTime = 0f;
				Instantiate(Bullet, transform.position, transform.rotation);
			}
		}
	
	
	}
}
