using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;  
//使用Scene:2Dmode
//用途:制限時間の管理とゲームオーバー判定
//Addするオブジェクト:制限時間を表示しているオブジェクトの親のオブジェクト

public class TimeractScript : MonoBehaviour {

	//PlayerScript2Dのインスタンス取得のための変数
	private GameObject playerObj;
	private PlayerScript2DKey plIns;
	
	//Timer
	public TextMesh txt;
	
	//時間
	private int minite;
	private float second;
	
	
	void Start () {
		//PlayerScript2Dのインスタンスの取得
		playerObj = GameObject.Find("Player");
		plIns = playerObj.GetComponent<PlayerScript2DKey>();
		
		//miniteをOpeningMenuのminiteで初期化
		minite = OpeningMenu.getMinite();
		
		second = 0;
		//表示
		txt.text = "0"+minite.ToString()+":0"+second.ToString();
	}
	
	
	void Update () {
		//時間減少
		if(second>0){
			second -= Time.deltaTime;
		}else{
			second = 60;
			second -= Time.deltaTime;
			minite--;
		}
		
		//表示
		string str;
		if(second<10){
		 	str="0";
		}else{
			str="";
		}
		txt.text = "0"+minite.ToString()+":"+str+((int)second).ToString();
		
		//修了判定
		if(second<=0&&minite<=0){
			textSave((plIns.score).ToString());
			Application.LoadLevel("Gameover");
		}
	}
	
	//現在のスコアをテキストファイルの最終行に追加するメソッド
	public void textSave(string txt){
		StreamWriter sw = new StreamWriter("ScoreData.txt",true); //true=追記 false=上書き
		sw.WriteLine(txt);
		sw.Flush();
		sw.Close();
	}
}
