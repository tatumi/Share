using UnityEngine;
using System.Collections;

//使用Scene:3Dmode
//用途:エネミーの挙動の指定
//Addするオブジェクト:Enemy
//他のEnemyScriptも参照
public class EnemyScript : MonoBehaviour {

	
	private GameObject playerObj;
	private PlayerScript plIns;
	private int Enemytype = 0;
	private float Enemypara = 0;
	private float Enemyspeed = 0;
	void Start () {
		//PlayerScriptのインスタンス
		playerObj = GameObject.Find("Player");
		plIns = playerObj.GetComponent<PlayerScript>();
		
		Enemytype = Random.Range(1,4);//敵の挙動の種類
		Enemypara = Random.Range(1f,3f);//敵のさまざまなパラメータ
		Enemyspeed = Random.Range(0.2f,0.7f);//敵の速さ
		transform.LookAt(plIns.getPlace());
//		Debug.Log(Enemytype);
	}
	
	void Update () {
		
		
		//挙動
		if(Enemytype==1){
			//一定の速さで同じ場所をくるくる回る
			transform.Translate( 0,0, Enemyspeed, Space.Self);
			//z軸回転 ロール
			transform.RotateAround(transform.position,transform.up,Enemypara);
			//x軸回転 上下
			transform.RotateAround(transform.position,transform.forward,0.01f);
		}else if(Enemytype==2){
			//Playerに目がけて体当たり
			transform.LookAt(plIns.getPlace());
			transform.Translate( 0,0, Enemyspeed*0.3f, Space.Self);
		//	Debug.Log("type2");
		}else if(Enemytype==3){
			//60フレームごとに挙動を変える
			transform.Translate( 0,0, Enemyspeed, Space.Self);
			if(Time.frameCount % 60 == 0){
				Enemypara = Random.Range(1f,3f);
			}
			if(Time.frameCount % 120 <= 60){
				transform.RotateAround(transform.position,transform.up,Enemypara);
			}else{
				transform.RotateAround(transform.position,transform.forward,Enemypara);
			}
		}
		
		//消滅処理
		if(Time.frameCount % 300 ==0){//300フレームごとに
		//	Debug.Log(plIns.getPlace);
			
		//	plIns = playerObj.GetComponent<PlayerScript>();
			
			//プレイヤーとの距離
			float distance = Vector3.Distance(plIns.getPlace(),transform.position);
			if(distance>=1000){
				Destroy(this.gameObject);
			}
		}
	//	transform.LookAt(playerObj.transform);
		
	}
	public Transform Bomb;
	void OnCollisionEnter(Collision collision){
		Debug.Log("collision");
		if(collision.gameObject.name == "Bullet(Clone)"){
			Instantiate(Bomb,transform.position,transform.rotation);
			//スコアに加算
			float a;
			if(Enemytype==1){
				a = 1.2f;	
			}else if(Enemytype==2){
				a = 1.5f;
			}else{
				a = 1.3f;
			}

			plIns.score +=  a*Enemypara*(Enemyspeed+0.5f)*10000;
			Destroy(this.gameObject);
		//	Debug.Log("judge");
		}
	
	}
}
