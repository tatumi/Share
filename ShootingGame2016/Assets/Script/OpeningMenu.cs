using UnityEngine;
using System.Collections;

//使用Scene:Main
//用途:オープニングのメニューの表示と操作
//Addするオブジェクト:Camera

//このスクリプトは改良の余地があるので出来る人はより良いプログラムに書き換えてください
public class OpeningMenu : MonoBehaviour {

	int pin=0;	//カーソルの位置
	int option;	//オプションモード
	int re=1;	//ジョイスティックがニュートラル状態になったか
	public static int minite=3;	//ゲームの制限時間の分
	
	void Start () {
		pin=0;
		option =0;
	}
	
	// Update is called once per frame
	
	void Update () {
		//ジョイスティックの前後移動の検知
		float z = Input.GetAxis("Vertical");
		
		if(option==0&&re==1){
			if(z>0.3&&pin!=0){
				pin--;
				re=0;
			}else if(z<-0.3&&pin!=2){
				pin++;
				re=0;
			}
		}else if(option==1&&re==1){
			if(z>0.3&&pin!=0){
				pin--;
				re=0;
			}else if(z<-0.3&&pin!=4){
				pin++;
				re=0;
			}
		}
		
		if(z==0){
			re=1;
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			if(option ==0 ){
				if(pin==0){
					Application.LoadLevel("3Dmode");
				}else if(pin==1){
					Application.LoadLevel("2Dmode");
				}else if(pin==2){
					option=1;
					pin =0;
				}
			}else if(option ==1){
				switch(pin){
				case 0: minite = 1;
					break;
				case 1: minite = 2;
					break;
				case 2: minite = 3;
					break;
				case 3: minite = 4;
					break;
				case 4: minite = 5;
					break;
				}
				
				option =0;
				pin=0;
			}
		}
		
	
	}
	public GUIStyle style,menustyle;
	void OnGUI () {
		GUI.Label(new Rect(93,20,100,100), "SpaceShooting",style);
		
		if(option == 0){
			GUI.Label(new Rect(150,80,100,100), "3Dモード",menustyle);
			GUI.Label(new Rect(150,110,100,100), "2Dモード",menustyle);
			GUI.Label(new Rect(150,140,100,100), "制限時間の変更",menustyle);
			if(pin==0){
				GUI.Label(new Rect(120,80,100,100), ">>",menustyle);
			}else if(pin==1){
				GUI.Label(new Rect(120,110,100,100), ">>",menustyle);
			}else if(pin==2){
				GUI.Label(new Rect(120,140,100,100), ">>",menustyle);
			} 
		}else {
			switch(pin){
				case 0: GUI.Label(new Rect(150,80,100,100), "01:00",menustyle);
					break;
				case 1: GUI.Label(new Rect(150,80,100,100), "02:00",menustyle);
					break;
				case 2: GUI.Label(new Rect(150,80,100,100), "03:00",menustyle);
					break;
				case 3: GUI.Label(new Rect(150,80,100,100), "04:00",menustyle);
					break;
				case 4: GUI.Label(new Rect(150,80,100,100), "05:00",menustyle);
					break;
				}
		}
	}
	public static int getMinite(){
		return minite;
	}
}
