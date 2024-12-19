using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EvidenceUI : MonoBehaviour
{
	[SerializeField] private CaseManager caseManager;
	[SerializeField] private Button evidenceButtonPrefab;
	[SerializeField] private Transform evidenceButtonParent;
	[SerializeField] private Image evidenceImage;
	[SerializeField] private Button exitEvidenceButton;
	private Dictionary<Button, int> evidenceButtonMap;
	private bool canToggleEvidence = true;

	//subscribe to events
	private void OnEnable()
	{
		caseManager.onStartCase += PopulateEvidenceButtons;
		caseManager.onEndCase += DestroyEvidenceButtons;
		exitEvidenceButton.onClick.AddListener(() => ToggleEvidence(false));
	}

	//unsubscribe to events
	private void OnDisable()
	{
		caseManager.onStartCase -= PopulateEvidenceButtons;
		caseManager.onEndCase -= DestroyEvidenceButtons;
		foreach (Button button in evidenceButtonMap.Keys)
		{
			button.onClick.RemoveAllListeners();
		}
		exitEvidenceButton.onClick.RemoveListener(() => ToggleEvidence(false));
	}

	//create the buttons based on evidence array length
	private void PopulateEvidenceButtons(Case caseInstance)
	{
		evidenceButtonMap = new Dictionary<Button, int>();

		for (int i = 0; i < caseInstance.evidence.Length; i++)
		{
			Button buttonInstance = Instantiate(evidenceButtonPrefab, evidenceButtonParent);
			evidenceButtonMap.Add(buttonInstance, i);

			SetButtonText(buttonInstance, caseInstance.evidence[i].evidenceTitle);
			buttonInstance.onClick.AddListener(() => OnEvidenceButtonClicked(buttonInstance));
		}
	}

	//set bool accordingly and check which button to show the correct evidence
	private void OnEvidenceButtonClicked(Button clickedButton)
	{
		if (!canToggleEvidence) return;

		if (evidenceButtonMap.TryGetValue(clickedButton, out int evidenceIndex))
		{
			LoadEvidenceImage(evidenceIndex);
			ToggleEvidence(true);
		}
		canToggleEvidence = false;
	}

	//destroy the buttons and unsubscribe the buttons
	private void DestroyEvidenceButtons()
	{
		foreach (Button button in evidenceButtonMap.Keys)
		{
			button.onClick.RemoveAllListeners();
			Destroy(button.gameObject);
		}
		evidenceButtonMap.Clear();
	}
	
	//set the button text
	private void SetButtonText(Button button, string text)
	{
		TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
		buttonText.text = text;
	}

	//toggle evidence ui
	private void ToggleEvidence(bool toggle)
	{
		evidenceImage.gameObject.SetActive(toggle);
		if (!toggle)
		{
			evidenceImage.sprite = null;
			canToggleEvidence = true;
		}
	}

	//load the actual evidence image
	private void LoadEvidenceImage(int evidenceNumber)
	{
		evidenceImage.sprite = caseManager.activeCase.evidence[evidenceNumber].evidence;
	}
}
