using UnityEngine;
using System.Collections;

//使用Scene:3Dmode
//用途:Playerの操作
//Addするオブジェクト:Player

public class PlayerScript : MonoBehaviour {
	
	public Vector3 place;
	public float score; 	//スコア
	public float speed; 	//スピード
	private  float drive = 1.55f;	 //動きやすさ
	void Start () {
		place = transform.position;	//今の位置
		score = 0;
		speed = 0.5f;
	}
	
	
	// Update is called once per frame
	void Update () {
		
		
		//前進
		transform.Translate(0, 0, -speed, Space.Self);
		
		//入力
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		float sp = Input.GetAxis("UpDown");
		float yo = Input.GetAxis("RightLeft");
		
		
		//z軸回転 ヨー
		transform.RotateAround(transform.position,transform.forward,x*drive);
		//x軸回転 上下
		transform.RotateAround(transform.position,transform.right,z*drive);
		//y軸回転 ロール
		transform.RotateAround(transform.position,transform.up,yo*1f);
		
		//スピード調節
		if(sp<0&&speed>0.2f){
			speed -= 0.05f;
		}else if(sp>0&&speed<2f){
			speed += 0.05f;
		//	Debug.Log("speedUp");
		}
		
	//	Debug.Log(transform.rotation);
	
	
		place = transform.position;	//現在位置の更新
	
	//デバッグ用
/*		if(x==0&&z==0){
			float angle_y = Vector3.Angle(transform.up,Vector3.up);
			
			float angle_x = Vector3.Angle(transform.right,Vector3.up);
			
			float angle_z = Vector3.Angle(transform.forward,Vector3.up);
			
	//		Debug.Log("y="+angle_y+"\nx="+angle_x+"  z="+angle_z);
			
			//上下補助
			if(angle_y<89){
				transform.RotateAround(transform.position,transform.right,-2f);
			}else if(angle_y>91){
				transform.RotateAround(transform.position,transform.right,22f);
			}
			
			//ロール補助
			if(angle_x<88){
				transform.RotateAround(transform.position,transform.up,2.5f);
			}else if(angle_x>92){
				transform.RotateAround(transform.position,transform.up,-2.5f);
			}
		

	
		}
*/
	
	}
	//敵に当たると減点
	void OnCollisionEnter(Collision collision){
		Debug.Log("collision");
		if(collision.gameObject.name == "Enemy2(Clone)"){
			score -= 1000;
		}
	
	}
	public Vector3 getPlace(){
		return place;
	}
	

}
