using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;  

//TimeractScriptの3Dmode版．詳細はそちらへ
public class TimeractScript3D : MonoBehaviour {

	// Use this for initialization
	private GameObject playerObj;
	private PlayerScript plIns;
	public TextMesh txt;
	private int minite;
	private float second;
	void Start () {
		playerObj = GameObject.Find("Player");
		plIns = playerObj.GetComponent<PlayerScript>();
		
		minite = OpeningMenu.getMinite();
		second = 0;
		txt.text = "0"+minite.ToString()+":0"+second.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if(second>0){
			second -= Time.deltaTime;
		}else{
			second = 60;
			second -= Time.deltaTime;
			minite--;
		}
		
		string str;
		if(second<10){
		 	str="0";
		}else{
			str="";
		}
		txt.text = "0"+minite.ToString()+":"+str+((int)second).ToString();
		
		if(second<=0&&minite<=0){
	//		this.textSave((plIns.score).ToString());
			Application.LoadLevel("Gameover");
		}
	}
	
	public void textSave(string txt){
		StreamWriter sw = new StreamWriter("C:/Users/Katen/Documents/CopyShooting/ScoreData.txt",true); //true=追記 false=上書き
		sw.WriteLine(txt);
		sw.Flush();
		sw.Close();
	}
}
