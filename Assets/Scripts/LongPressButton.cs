using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class LongPressButton : MonoBehaviour, ISelectableByRay
{
	private bool isHitLongPressButton;
	[SerializeField] private Image buttonGauge;
	Vector3 firstButtonGaugePosition;
	private int endPositionX = -4; 
	float gaugeTime;
	[SerializeField]private GameObject stage;
	private StageController _stageController;
	[SerializeField] private GameObject UI;
	
	void Start()
	{
		firstButtonGaugePosition = buttonGauge.rectTransform.localPosition;
		_stageController = stage.GetComponent<StageController>();	
	}


	private void Update()
	{
		if (isHitLongPressButton)
		{
			gaugeTime += Time.deltaTime * 0.01f;
			buttonGauge.rectTransform.localPosition = Vector3.Lerp(buttonGauge.rectTransform.localPosition,new Vector3(0, 0, 1), gaugeTime);
		}
		else
		{
			gaugeTime = 0;
			buttonGauge.rectTransform.localPosition = firstButtonGaugePosition;
		}

		if (buttonGauge.rectTransform.localPosition.x > endPositionX)
		{
			UI.SetActive(false);
			_stageController.ChageStage();
		}
	}


	public void RayEnter()
	{
		isHitLongPressButton = true;
	}

	public void RayExit()
	{
		if (buttonGauge.rectTransform.localPosition.x < endPositionX)
		isHitLongPressButton = false;
	}
}
