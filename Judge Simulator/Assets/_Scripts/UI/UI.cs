using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
	[SerializeField] private UIToggle uiToggle;
    [SerializeField] private Actor[] actors;
	[SerializeField] private Canvas[] actorsCanvas;
	public Canvas[] ActorsCanvas => actorsCanvas;
	[SerializeField] private Button[] stopButton;
	private Dictionary<Actor, Canvas> actorCanvasMap;
	public Dictionary<Actor, Canvas> ActorCanvasMap => actorCanvasMap;
	private bool canTurnOnUI = true;
	public bool CanTurnOnUI
	{
		get => canTurnOnUI;
		set => canTurnOnUI = value;
	}


	//initialize Dictionary of actors and their canvases
	//add every actor key with their canvas entry
	//subscribe to every actor on click event
	//subscribe to every button on click event
	private void OnEnable()
	{
		DictionarySetup();
		UtilityClass.SubscribeObjectsToEvent(actors, actor => actor.onActorClick += uiToggle.TurnOnActorUI);
		UtilityClass.SubscribeObjectsToEvent(stopButton, button => button.onClick.AddListener(uiToggle.TurnOffActorUI));
	}

	//unsubscribe to every actor on click event
	//unsubscribe to every button on click event
	private void OnDisable()
	{
		UtilityClass.UnsubscribeObjectFromEvent(actors, actor => actor.onActorClick -= uiToggle.TurnOnActorUI);
		UtilityClass.UnsubscribeObjectFromEvent(stopButton, button => button.onClick.RemoveListener(uiToggle.TurnOffActorUI));
	}

	private void DictionarySetup()
	{
		actorCanvasMap = new Dictionary<Actor, Canvas>();
		for (int i = 0; i < actors.Length; i++)
		{
			actorCanvasMap.Add(actors[i], actorsCanvas[i]);
		}
	}
}
