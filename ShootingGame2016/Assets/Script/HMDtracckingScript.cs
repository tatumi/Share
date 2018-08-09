using UnityEngine;
using System.Collections;
using UnityEngine.VR;

//�g�pScene:Main�E2Dmode�E3Dmode�EGameOver
//�p�r:HMD�̑O�̈ʒu�����������
//Add����I�u�W�F�N�g:�ǂ��ł�ǂ�(MainCamera����)

public class HMDtracckingScript : MonoBehaviour {


	void Update () {
		//R�������HMD���O�����
		if(Input.GetKeyDown(KeyCode.R)){
			UnityEngine.XR.InputTracking.Recenter();
		}

	
	}
}
