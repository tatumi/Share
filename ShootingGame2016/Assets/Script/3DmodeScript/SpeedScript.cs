using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//使用Scene:3Dmode
//用途:スピードを表示する
//Addするオブジェクト:Speed

public class SpeedScript : MonoBehaviour {

	private GameObject playerObj;
	private PlayerScript plIns;
	
	void Start () {
		playerObj = GameObject.Find("Player");
		plIns = playerObj.GetComponent<PlayerScript>();
		
		this.GetComponent<Text>().text = "Speed:"+(plIns.speed).ToString("F1") +"f";
	}
	
	void Update () {
		this.GetComponent<Text>().text = "Speed:"+(plIns.speed).ToString("F1") +"f";
	}
}
