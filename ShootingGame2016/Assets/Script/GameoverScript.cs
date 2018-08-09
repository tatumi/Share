using UnityEngine;
using System.Collections;
using System.IO; //System.IO.FileInfo, System.IO.StreamReader, System.IO.StreamWriter
using System; //Exception
using System.Text; //Encoding

//使用Scene:GameOver
//用途:GAMEOVER画面の文字表示をする
//Addするオブジェクト:カメラ

public class GameoverScript : MonoBehaviour {


	void Update () {
		//Sが押されるとメインメニューに戻る
		if(Input.GetKeyDown(KeyCode.S)){
			Application.LoadLevel("Main");
		}
	
	}
	
	//Inspectorで変更可能なスタイル
	public GUIStyle style,style2,style3;
	void OnGUI () {
		
		//以下のパスは環境に合わせて変えてください
		string sc = this.OpenTextFile("ScoreData.txt");
		
		//文字表示
		GUI.Label(new Rect(120,0,100,100), "GameOver",style);
		GUI.Label(new Rect(120,50,100,100), "Score\n"+sc,style2);
		GUI.Label(new Rect(60,140,100,100), "S button to opening menu",style3);
		
	}
	
	//テキストファイルを読んで，最後の行をstringで返すメソッド
	public string OpenTextFile( string _filePath ){
		FileInfo fi = new FileInfo(_filePath);
		string returnSt = "";
		
		try {
			using (StreamReader sr = new StreamReader(fi.OpenRead(), Encoding.UTF8)){
			while(sr.Peek() >= 0){
				returnSt = sr.ReadLine();
			}
				
			}
		} catch (Exception e){
			print (e.Message);
			returnSt = "READ ERROR: " + _filePath;
		}
		return returnSt;
	}
}
