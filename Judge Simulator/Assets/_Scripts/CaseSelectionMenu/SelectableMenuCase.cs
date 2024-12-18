using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectableMenuCase : MonoBehaviour
{
    [SerializeField] private Case caseInstance;
	[SerializeField] private Button playButton;
	public event Action<Case> onCourtroomScene;

	private void OnEnable()
	{
		playButton.onClick.AddListener(SelectCase);
	}

	private void OnDisable()
	{
		playButton.onClick.RemoveListener(SelectCase);
	}

	private void SelectCase()
	{
		print("Selected" + caseInstance.caseName);
		onCourtroomScene?.Invoke(caseInstance);
	}
}
