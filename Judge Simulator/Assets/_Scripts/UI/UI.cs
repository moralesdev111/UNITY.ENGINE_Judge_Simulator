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
		SubscribeToEvents();
		SubscribeToButtonEvent();
	}

	//unsubscribe to every actor on click event
	//unsubscribe to every button on click event
	private void OnDisable()
	{
		UnsubscribeToEvents();
		UnsubscribeToButtonEvent();
	}

	private void SubscribeToEvents()
	{
		for (int i = 0; i < actors.Length; i++)
		{
			actors[i].onActorClick += uiToggle.TurnOnActorUI;
		}
	}

	private void DictionarySetup()
	{
		actorCanvasMap = new Dictionary<Actor, Canvas>();
		for (int i = 0; i < actors.Length; i++)
		{
			actorCanvasMap.Add(actors[i], actorsCanvas[i]);
		}
	}

	private void UnsubscribeToEvents()
	{
		for (int i = 0; i < actors.Length; i++)
		{
			actors[i].onActorClick -= uiToggle.TurnOnActorUI;
		}
	}

	private void SubscribeToButtonEvent()
	{
		for (int i = 0; i < stopButton.Length; i++)
		{
			stopButton[i].onClick.AddListener(uiToggle.TurnOffActorUI);
		}
	}

	private void UnsubscribeToButtonEvent()
	{
		for (int i = 0; i < stopButton.Length; i++)
		{
			stopButton[i].onClick.RemoveListener(uiToggle.TurnOffActorUI);
		}
	}
}
