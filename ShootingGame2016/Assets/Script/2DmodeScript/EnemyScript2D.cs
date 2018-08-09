using UnityEngine;
using System.Collections;

//使用Scene:2Dmode
//用途:敵の挙動の指定
//Addするオブジェクト:Enemy

public class EnemyScript2D : MonoBehaviour {

	
	private GameObject playerObj;
	private PlayerScript2DKey plIns;
	void Start () {
	// PlayerScript2Dのインスタンス
	playerObj = GameObject.Find("Player");
	plIns = playerObj.GetComponent<PlayerScript2DKey>();
	}
	
	// Update is called once per frame
	void Update () {
		//その場で回転
		transform.Rotate(new Vector3(1,1,1));
	}
	
	
	public Transform Bomb;
	//何かにぶつかった時に実行されるメソッド
	void OnCollisionEnter(Collision collision){
	//	Debug.Log("collision");
		//弾に当たったかどうかの判定
		if(collision.gameObject.name == "Bullet(Clone)"){
			//爆発エフェクトの表示
			Instantiate(Bomb,transform.position,transform.rotation);
			//スコアの加算
			plIns.score +=  100;
			//このオブジェクトの破壊
			Destroy(this.gameObject);
		//	Debug.Log("judge");
		}
	
	}
}
	