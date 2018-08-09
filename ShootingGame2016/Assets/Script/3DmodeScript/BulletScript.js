#pragma strict
//使用Scene:3Dmode・2Dmode
//用途:弾の挙動の指定
//Addするオブジェクト:Bullet

function Start () {
	//一定時間後に破壊
	Destroy(this.gameObject,2);
}

function Update () {
	//前にまっすぐ進む
	transform.Translate(transform.up*8,Space.World);

}

function OnCollisionEnter(){
	//何かにぶつかると破壊
	Destroy(this.gameObject);
}