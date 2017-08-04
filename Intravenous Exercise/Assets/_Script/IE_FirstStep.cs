using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IE_FirstStep : MonoBehaviour {

	public AudioSource _GY0002;

	public GameObject guides;

	private bool isCollider;

	public GameObject _Lid;
    public GameObject _Lid01;


    public Material _SwabColor;

	// Use this for initialization
	void Start() {
        
        StartCoroutine(GetSwab());
        isCollider = false;
	}

	private void AnimationGuide() {

		// 开始播放语音GY0002
		_GY0002.Play();

        // 开始引导
		guides.SetActive(true);
        
	}

	void OnCollisionEnter(Collision other) {

        // 关闭引导
        if (isCollider)
        {
            guides.SetActive(false);
        }

        // 开始抓取棉签
        if (this.gameObject.name == "DM_clinic_Swab002") {

			isCollider = true;
            
		}

		// 检测棉签和药瓶盖的碰撞
		if (other.gameObject.name == "SM_clinic_ lid") {

            _Lid.GetComponent<Animator>().enabled = true;
            Debug.Log(" SM_clinic_ lid ");

		}
		
		// 切换棉签棉花材质
		if (other.gameObject.name == "Tincture")
		{

			Debug.Log(" Tincture Off ");
			GameObject.Find("DM_clinic_Swab002").GetComponent<MeshRenderer>().material = _SwabColor;
		}

	}

    private void OnCollisionExit(Collision other)
    {
        // 碰撞完毕，关闭药瓶盖
        if (other.gameObject.name == "Tincture")
        {
            Debug.Log(" Tincture No ");

            _Lid.SetActive(false);
            _Lid01.SetActive(true);
            this.GetComponent<IE_SecondStep>().enabled = true;

        }
	}

	private IEnumerator GetSwab() {
		float coroutinesTime = 0f;

		while (coroutinesTime < 8f) {

			coroutinesTime += Time.deltaTime;

			yield return new WaitForEndOfFrame();
		}
		if (coroutinesTime >= 8.0f) {
            
			// 开始引导
			AnimationGuide();

			// 停止所有协程
			StopAllCoroutines();
		}
	}
}
