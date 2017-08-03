/************************************************************
************************************************************/
using UnityEngine;
using System.Collections;

/************************************************************
■description
'C' buttonでカメラ切り替え。
使用するカメラは、

ちなみに、シーン上で2つ以上のcameraがactiveになっていると、
	audio listnerが2つ以上あるよ
と警告が出る

************************************************************/
public class CameraChanger : MonoBehaviour {
	public GameObject[] cameras;
	public CameraPathAnimator cameraPathAnimator;
	
	public KeyCode debugKey = KeyCode.C;
	private int ActiveCam_id = 0;

	// Use this for initialization
	void Start () {
		ChangeActiveCam();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(this.debugKey)){
			ActiveCam_id++;
			if(cameras.Length <=ActiveCam_id)	ActiveCam_id = 0;
			
			ChangeActiveCam();
		}
	}
	
	void ChangeActiveCam()
	{
		int i = 0;
		foreach(GameObject cam in cameras){
			if(i == ActiveCam_id)	cam.SetActive(true);
			else					cam.SetActive(false);
			
			i++;
		}
		
		if(ActiveCam_id == 0){
			cameraPathAnimator.Seek(0);
			cameraPathAnimator.Play();
		}else{
			cameraPathAnimator.Stop();
		}
	}
}
