using UnityEngine;
using System.Collections;

//使用Scene:3Dmode
//用途:エネミーの生成
//Addするオブジェクト:EnemyBox
//EnemyBoxScript2Dも参照
public class EnemyBoxScript : MonoBehaviour {

	//Inspectorから敵のオブジェクトを指定
	public Transform Enemy,Enemy2;
	

	void Update () {
	
	if(Time.frameCount % 100 == 0){
		Vector3 mine = transform.position;
		float x = Random.Range(-100,100);//左右
		float y = Random.Range(-100,100);//上下
		float z = Random.Range(-90,-220);//前後
		int t = Random.Range(1,4);
		if(t==2){
			Instantiate(Enemy2,new Vector3(mine.x+x,mine.y+y,mine.z+z),transform.rotation);
		}else{
			Instantiate(Enemy,new Vector3(mine.x+x,mine.y+y,mine.z+z),transform.rotation);
		}
	}
	
	}
}
