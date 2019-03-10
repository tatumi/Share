using UnityEngine;
using System.Collections;

//使用Scene:2Dmode
//用途:敵を出現させる
//Addするオブジェクト:EnemyBox2D

public class EnemyBoxScript2D : MonoBehaviour {
	
	//出現させる敵のオブジェクトをInspectorから指定
	public Transform Enemy;
	
	void Update () {
	//120フレームごとに敵を生成
	if(Time.frameCount % 120 == 0){
		Vector3 mine = transform.position;
		//生成位置のばらつき(変更可)
		float x = Random.Range(-180,180);//左右
		float y = Random.Range(-60,60);//上下
		float z = Random.Range(-20,20);//前後
		
		//敵の生成
		Instantiate(Enemy,new Vector3(mine.x+x,mine.y+y,mine.z+z),transform.rotation);
	}
	
	}
}
