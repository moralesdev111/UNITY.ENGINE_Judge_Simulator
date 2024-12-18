using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectableMenuCase : MonoBehaviour
{
    [SerializeField] private Case caseInstance;
	[SerializeField] private Button playButton;
	public event Action<Case> onCourtroomScene;


	//add button listener
	private void OnEnable()
	{
		playButton.onClick.AddListener(SelectCase);
	}

	//remove button listener
	private void OnDisable()
	{
		playButton.onClick.RemoveListener(SelectCase);
	}

	//request load courtroom scene and broadcast the case instance
	private void SelectCase()
	{
		print("Selected" + caseInstance.caseName);
		onCourtroomScene?.Invoke(caseInstance);
	}
}
