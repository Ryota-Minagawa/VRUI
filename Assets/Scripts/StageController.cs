
using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
	[SerializeField]GameObject[] _radioButtonItems;
	private string _radioButtonTag;

	public void ChageStage()
	{

		foreach (var _radioButtonItem in _radioButtonItems)
		{
			if ( _radioButtonItem.GetComponent<Image>().color == Color.red)
			{
				_radioButtonTag = _radioButtonItem.tag;
				break;
			}

		}

		switch (_radioButtonTag)
		{
			case "Blue":
				gameObject.GetComponent<Renderer>().material.color = Color.blue;
				break;

			case "Red":
				gameObject.GetComponent<Renderer>().material.color = Color.red;
				break;

			case "Yellow":
				gameObject.GetComponent<Renderer>().material.color = Color.yellow;
				break;
		}
	}
}



