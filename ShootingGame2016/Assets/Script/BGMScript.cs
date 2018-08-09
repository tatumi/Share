using UnityEngine;
using System.Collections;

//使用Scene:2Dmode・3Dmode
//用途:BGMを鳴らすためのスクリプト
//Addするオブジェクト:AudioSouceが付いたオブジェクト

public class BGMScript : MonoBehaviour {

	
	//publicにするとInspectorからAudioClipを変更できる
	public AudioClip necro;
    	public AudioClip kurerappu;
    	public AudioClip sumizome;
    	public AudioClip badapple;
    	private AudioSource audioSource;

    	void Start () {
    		//このスクリプトが付いているオブジェクトのAudioSouceを取得
    		audioSource = gameObject.GetComponent<AudioSource>();
    	    
    	    //BadAppleだけ3分しかないので3分未満の時はBadAppleを含まない
    	    int b;
    	    if(OpeningMenu.getMinite()<=3){
    	    	b=1;
    	    }else{
    	    	b=0;
    	    }
    	    int a = Random.Range(1,4+b);
    	    
    	    //ランダムで4曲のうちどれかが鳴る(3分未満の時は3曲)
    	    if(a==1){
    	    	audioSource.clip = necro;
    	    }else if(a==2){
    	    	audioSource.clip = kurerappu;
    	    }else if(a==3){
    	    	audioSource.clip = sumizome;
    	    }else if(a==4){
    	    	audioSource.clip = badapple;
    	    }
    	    
    	    audioSource.Play ();
   	}
	
}
