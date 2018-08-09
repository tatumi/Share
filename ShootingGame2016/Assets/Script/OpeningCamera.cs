using UnityEngine;
using System.Collections;

//使用Scene:Main
//用途:オープニング画面でカメラを動かす
//Addするオブジェクト:Cameraの親のオブジェクト

public class OpeningCamera : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		//一定の速さで回転する
		transform.Rotate(new Vector3(0,0,0.3f));
	}
}
