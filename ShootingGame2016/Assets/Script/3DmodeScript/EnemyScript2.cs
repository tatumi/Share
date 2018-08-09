using UnityEngine;
using System.Collections;

//使用Scene:3Dmode
//用途:プレイヤーを追いかけるエネミーの挙動の指定
//Addするオブジェクト:Enemy
//他のEnemyScriptも参照
public class EnemyScript2 : MonoBehaviour {

	// Use this for initialization
	private GameObject playerObj;
	private PlayerScript plIns;
	private int Enemytype = 0;
	private float Enemypara = 0;
	private float Enemyspeed = 0;
	void Start () {
		playerObj = GameObject.Find("Player");
		plIns = playerObj.GetComponent<PlayerScript>();
		Enemytype = 2;
		Enemypara = Random.Range(1f,3f);
		Enemyspeed = Random.Range(0.2f,0.7f);
		transform.LookAt(plIns.getPlace());

	//	Debug.Log(Enemytype);
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(plIns.getPlace(),Vector3.zero);
		transform.Translate( 0,0,Enemyspeed*0.2f , Space.Self);
		
		if(Time.frameCount % 300 ==0){//300フレームごとに
		//	Debug.Log(plIns.getPlace);
			
			
			//プレイヤーとの距離
			float distance = Vector3.Distance(plIns.getPlace(),transform.position);
			if(distance>=1000){
				Destroy(this.gameObject);
			}
		}
	}
	
	public Transform Bomb;
	void OnCollisionEnter(Collision collision){
		Debug.Log("collision");
		if(collision.gameObject.name == "Bullet(Clone)"){
			Instantiate(Bomb,transform.position,transform.rotation);
			float a;
			a = 1.5f;
			

			plIns.score +=  a*Enemypara*(Enemyspeed+0.5f)*10000;
			Destroy(this.gameObject);
		//	Debug.Log("judge");
		}
	
	}
}
