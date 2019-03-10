using UnityEngine;
using System.Collections;

//使用Scene:2Dmode
//用途:Playerの操作
//Addするオブジェクト:Player

public class PlayerScript2D : MonoBehaviour {

    public Vector3 place;
    //スコアを格納する変数
    public float score;
	void Start () {
        place = transform.position;	//今の位置
		score = 0;              //スコアを初期化
    }


	void Update () {
	
		//ジョイスティックの入力を受けとる
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		//平行移動(左右)
		transform.Translate(-x*0.8f, 0, 0, Space.Self);
		
		//ジョイスティックの傾きを角度に変換
		float axis_angle = -z*70+90;
		
		//それぞれの軸との角度
		float angle_y = Vector3.Angle(transform.up,Vector3.up);
			
		float angle_x = Vector3.Angle(transform.right,Vector3.up);
			
		float angle_z = Vector3.Angle(transform.forward,Vector3.up);
		
		//デバッグ用
		//Debug.Log("z="+angle_z+"\naxis="+axis_angle);
		
		//ジョイスティックの角度と機体の角度の差
		float sub = axis_angle-angle_z;
		
		//ガタツキ防止のマージン
		if((sub<1.2f&&sub>0)||(sub>-1.2f&&sub<0)){
		
		}else if(axis_angle<angle_z){//ジョイスティックの角度と一致するように機体を傾ける
			transform.RotateAround(transform.position,transform.right,-1f);
		}else if(axis_angle>angle_y){
			transform.RotateAround(transform.position,transform.right,1f);
		}

        place = transform.position; //現在位置の更新

        //以下デバッグ用
        /*
        if (x==0&&z==0){
			
		//	Debug.Log("y="+angle_y+"\nx="+angle_x+"  z="+angle_z);
			
			//上下補助
			if(angle_y<88){
				transform.RotateAround(transform.position,transform.right,-0.5f);
			}else if(angle_y>92){
				transform.RotateAround(transform.position,transform.right,0.5f);
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
}
