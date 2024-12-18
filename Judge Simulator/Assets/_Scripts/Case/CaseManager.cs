using System;
using UnityEngine;

public class CaseManager : MonoBehaviour
{
	public static CaseManager Instance { get; private set; }
	[SerializeField] private Case[] caseCollection;
	public Case activeCase;
	public event Action<Case> onStartCase;
	public event Action onEndCase;


	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		StartCase(caseCollection[0]);
	}

	//set active case
	//broadcast case start event
	public void StartCase(Case activeCase)
	{
		print("case start");
		this.activeCase = activeCase;
		onStartCase?.Invoke(this.activeCase);
	}

	//null active case
	//broadcast case end event
	public void EndCase()
	{
		print("case end");
		activeCase = null;
		onEndCase?.Invoke();
	}

	public void Cleanup()
	{
		Debug.Log("CaseManager cleaned up.");
		Instance = null;
		Destroy(gameObject); // Destroy the CaseManager instance
	}
}
