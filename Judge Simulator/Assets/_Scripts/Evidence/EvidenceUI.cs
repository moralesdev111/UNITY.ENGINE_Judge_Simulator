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
	private Button[] evidenceButtons;


	//subscribe to events
	private void OnEnable()
	{
		caseManager.onStartCase += PopulateEvidenceButtons;
		caseManager.onEndCase += DestroyEvidenceButtons;
		exitEvidenceButton.onClick.AddListener(CloseEvidence);
	}

	//unsubscribe to events
	private void OnDisable()
	{
		caseManager.onStartCase -= PopulateEvidenceButtons;
		caseManager.onEndCase -= DestroyEvidenceButtons;
		for (int i = 0; i < evidenceButtons.Length; i++)
		{
			evidenceButtons[i].onClick.RemoveAllListeners();
		}
		exitEvidenceButton.onClick.RemoveListener(CloseEvidence);
	}

	//create the buttons based on evidence array length
	private void PopulateEvidenceButtons(Case caseInstance)
	{
		evidenceButtons = new Button[caseInstance.evidence.Length];

		for (int i = 0; i < caseInstance.evidence.Length; i++)
		{
			Button buttonInstance = Instantiate(evidenceButtonPrefab, evidenceButtonParent);
			evidenceButtons[i] = buttonInstance;

			SetButtonText(buttonInstance, caseInstance.evidence[i].evidenceTitle);
			buttonInstance.onClick.AddListener(() => ToggleEvidence(true));
		}
	}

	//destroy the buttons and unsubscribe the buttons
	private void DestroyEvidenceButtons()
	{
		for (int i = 0; i < evidenceButtons.Length; i++)
		{
			evidenceButtons[i].onClick.RemoveAllListeners();
			Destroy(evidenceButtons[i].gameObject);
		}
		evidenceButtons = null;
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
	}

	//toggle evidence off
	private void CloseEvidence()
	{
		ToggleEvidence(false);
	}
}
