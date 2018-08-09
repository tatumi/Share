using UnityEngine;
using System.Collections;

//�g�pScene:3Dmode
//�p�r:Player�̑���
//Add����I�u�W�F�N�g:Player

public class PlayerScript : MonoBehaviour {
	
	public Vector3 place;
	public float score; 	//�X�R�A
	public float speed; 	//�X�s�[�h
	private  float drive = 1.55f;	 //�����₷��
	void Start () {
		place = transform.position;	//���̈ʒu
		score = 0;
		speed = 0.5f;
	}
	
	
	// Update is called once per frame
	void Update () {
		
		
		//�O�i
		transform.Translate(0, 0, -speed, Space.Self);
		
		//����
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		float sp = Input.GetAxis("UpDown");
		float yo = Input.GetAxis("RightLeft");
		
		
		//z����] ���[
		transform.RotateAround(transform.position,transform.forward,x*drive);
		//x����] �㉺
		transform.RotateAround(transform.position,transform.right,z*drive);
		//y����] ���[��
		transform.RotateAround(transform.position,transform.up,yo*1f);
		
		//�X�s�[�h����
		if(sp<0&&speed>0.2f){
			speed -= 0.05f;
		}else if(sp>0&&speed<2f){
			speed += 0.05f;
		//	Debug.Log("speedUp");
		}
		
	//	Debug.Log(transform.rotation);
	
	
		place = transform.position;	//���݈ʒu�̍X�V
	
	//�f�o�b�O�p
/*		if(x==0&&z==0){
			float angle_y = Vector3.Angle(transform.up,Vector3.up);
			
			float angle_x = Vector3.Angle(transform.right,Vector3.up);
			
			float angle_z = Vector3.Angle(transform.forward,Vector3.up);
			
	//		Debug.Log("y="+angle_y+"\nx="+angle_x+"  z="+angle_z);
			
			//�㉺�⏕
			if(angle_y<89){
				transform.RotateAround(transform.position,transform.right,-2f);
			}else if(angle_y>91){
				transform.RotateAround(transform.position,transform.right,22f);
			}
			
			//���[���⏕
			if(angle_x<88){
				transform.RotateAround(transform.position,transform.up,2.5f);
			}else if(angle_x>92){
				transform.RotateAround(transform.position,transform.up,-2.5f);
			}
		

	
		}
*/
	
	}
	//�G�ɓ�����ƌ��_
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
