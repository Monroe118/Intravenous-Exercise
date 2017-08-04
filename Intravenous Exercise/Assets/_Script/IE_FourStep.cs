using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IE_FourStep : MonoBehaviour {


	public AudioSource _GY0004;

	public GameObject _Hands;
	public GameObject _Tourniquet;
	public GameObject _TourniquetHide;

	private bool isTourniquet;

	// Use this for initialization
	void Start () {

		// 播放语音提示
		_GY0004.Play();

		// 动画引导

	}

	private void OnTriggerEnter(Collider other)
	{

		// 抓取止血带
		if (other.gameObject.name == "Tourniquet") {

            Debug.Log("Tourniquet");
			// 绑定止血带
			_Tourniquet.SetActive(false);
			_TourniquetHide.SetActive(true);

			isTourniquet = true;
		}

		if (isTourniquet) {

			_Hands.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_SnowAmount", 0f);

			// 进行下一步

		}
	}

}
