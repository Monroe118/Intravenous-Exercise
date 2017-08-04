using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.UnityEventHelper;


public class IE_FristEnven : MonoBehaviour {

	public GameObject tips;

	public GameObject _Again;

	public GameObject _Exit;

	public GameObject rightController;

	public AudioSource _GY0001;

    public GameObject _Swab002;

	private bool isTipShowing = true;

	// Use this for initialization
	void Start ()
    {
        rightController.GetComponent<VRTK_ControllerEvents_UnityEvents>().OnTriggerClicked.AddListener(TriggerEvents_HideTips);
	}

	// 按钮事件
	private void TriggerEvents_HideTips(object sender, ControllerInteractionEventArgs e) {

		HideTips();

		// 移除按钮事件
		rightController.GetComponent<VRTK_ControllerEvents_UnityEvents>().OnTriggerClicked.RemoveListener(TriggerEvents_HideTips);

	}

	public void ShowOrHideTips() {
		if (isTipShowing)
		{
			HideTips();
		}
		else {
			ShowTips();
		}
	}

	private void ShowTips() {
		tips.SetActive(true);
		isTipShowing = true;
	}

	public void HideTips() {
		tips.SetActive(false);

		
		isTipShowing = false;

		// Image
		_Again.SetActive(true);
		_Exit.SetActive(true);

		_GY0001.Play();
        
        _Swab002.GetComponent<IE_FirstStep>().enabled = true;
       
	}
}
