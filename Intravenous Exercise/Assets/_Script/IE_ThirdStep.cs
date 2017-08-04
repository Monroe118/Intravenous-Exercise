using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IE_ThirdStep : MonoBehaviour {

    private bool isInfusion;

	public IE_FourStep _FourStep;
    
	public GameObject _Bag001;
	public GameObject _Infusionstick;
	public GameObject _Infusionstick01;


	void Start()
    {
        // 动画引导

    }

    private void OnTriggerEnter(Collider other)
    {
		// 抓取输液贴包装
		if (this.gameObject.name == "DM_clinic_packagingbag") {

            Debug.Log("DM_clinic_packagingbag");

            _Bag001.GetComponent<Animator>().enabled = true;

            _Infusionstick.SetActive(false);
            _Infusionstick01.SetActive(true);

            isInfusion = true;
        }

		// 进行下一步
		if (isInfusion)
        {
			_FourStep.GetComponent<IE_FourStep>().enabled = true;

		}
    }
}
