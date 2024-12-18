using UnityEngine;

public class UIToggle : MonoBehaviour
{
	[SerializeField] private UI uI;


	//check if we are allowed to turn on ui
	//check dictionary key for value
	//set that canvas value to true to turn ui on
	//we are not allowed to turn ui on for now
	public void TurnOnActorUI(Actor actor)
	{
		if (!uI.CanTurnOnUI) return;
		if (uI.ActorCanvasMap.TryGetValue(actor, out Canvas canvas))

		{
			canvas.gameObject.SetActive(true);
			uI.CanTurnOnUI = false;
		}
		uI.CanTurnOnUI = false;
	}

	//check our canvas hierarchy
	//if active
	//turn off
	//we can turn on ui from now on
	public void TurnOffActorUI()
	{
		for (int i = 0; i < uI.ActorsCanvas.Length; i++)
		{
			if (uI.ActorsCanvas[i].gameObject.activeSelf)
			{
				uI.ActorsCanvas[i].gameObject.SetActive(false);
			}
		}
		uI.CanTurnOnUI = true;
	}
}
