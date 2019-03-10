using UnityEngine;
using System.Collections;

//使用Scene:2Dmode
//用途:Playerの操作(キーボード用)
//Addするオブジェクト:Player

public class PlayerScript2DKey : MonoBehaviour {

    public Vector3 place;
    //スコアを格納する変数
    public float score;
    void Start()
    {
        place = transform.position; //今の位置
        score = 0;              //スコアを初期化
    }


    void Update () {
	
		//キーボードの入力を受けとる
		float x = Input.GetAxis("RightLeft");
		float z = Input.GetAxis("Vertical");

        //平行移動(左右)
        if (x > 0 && place.x >= -180)
        {
            transform.Translate(-1f, 0, 0, Space.Self);
        } else if (x < 0 && place.x <= 180) {
            transform.Translate(1f, 0, 0, Space.Self);

        }
        //機体を傾ける限界の角度
        float axis_angle = 60;
		
		//軸との角度
		float angle_z = Vector3.Angle(transform.forward,Vector3.up);

        //デバッグ用
        //Debug.Log("z="+z+"\naxis="+angle_z);

        //機体を上下に傾ける
        if (z > 0 && 90+axis_angle > angle_z) {//上方向

            transform.RotateAround(transform.position, transform.right, 1.1f);
            
        }
        else if (z < 0 && 90-axis_angle < angle_z){//下方向

            transform.RotateAround(transform.position, transform.right, -1.1f);

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
