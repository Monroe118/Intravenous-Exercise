using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IE_SecondStep : MonoBehaviour {

	private int isRight;
	private bool isHand_Use;
	private bool isTrashcan;

	public AudioSource _GY0003;
	public GameObject _Swab002;
    public GameObject _Hands;
    public GameObject _Infusion;

    // Use this for initialization
    void Start () {

		_GY0003.Play();

		// 消毒范围光环效果
	}

    void OnCollisionEnter(Collision other)
	{

		if (other.gameObject.name == "IsHand_Right")
		{
            isHand_Use = true;
            isRight = isRight + 1;

            // 皮肤切换颜色
            Debug.Log(" IsHand_Right True ");
            _Hands.GetComponent<SkinnedMeshRenderer>().material.SetFloat("_Normal", 0f);

        }

        if (other.gameObject.name == "IsHand_Up")
        {

            // 错误提示：动画提示和音效提示方向错误
            Debug.Log(" IsHand_Left True ");
        }

        if (other.gameObject.name == "IsHand")
		{

			if (isRight < 1)
			{
				// 错误提示：动画和音效提示消毒范围不够
				Debug.Log(" IsHand True ");

			}
			
		}

		if (isHand_Use) {

			// 调用丢垃圾动画指导方法
			AnimationGuide();

			if (other.gameObject.name == "IsTrashcan")
			{
				Debug.Log(" TRUE ");

				// 正确就把对象隐藏
				_Swab002.SetActive(false);

				isTrashcan = true;

			}

			if(other.gameObject.name == "IsTrashcanb" 
				|| other.gameObject.name == "IsBox") {

				// 错误提示：动画和音效，正确直接投入垃圾桶
				Debug.Log(" FALSE ");
			}
		}

		// 到撕输液贴过程
		if (isTrashcan) {
            _Infusion.GetComponent<IE_ThirdStep>().enabled = true;
        }
	}

	// 动画指导
	private void AnimationGuide() {
		
		// 打开隐藏的动画

	}
    
}
