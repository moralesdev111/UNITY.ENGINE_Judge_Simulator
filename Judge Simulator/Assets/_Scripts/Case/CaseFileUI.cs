using TMPro;
using UnityEngine;
using System;

public class CaseFileUI : MonoBehaviour
{
	[SerializeField] private CaseManager caseManager;
	[SerializeField] private TextMeshProUGUI caseDescription;
	[SerializeField] private TextMeshProUGUI chargesList;
	[SerializeField] private TextMeshProUGUI plaintiff;
	[SerializeField] private TextMeshProUGUI defendant;
	[SerializeField] private TextMeshProUGUI witness;
	[SerializeField] private GameObject[] evidenceTextPrefab;


	//subscribe to case start and case end
	private void OnEnable()
	{
		caseManager.onStartCase += DrawCaseFileUI;
		caseManager.onStartCase += TogglePlaintiff;
		caseManager.onEndCase += ClearCaseFileUI;
	}

	//unsubscribe to case start and case end
	private void OnDisable()
	{
		caseManager.onStartCase -= DrawCaseFileUI;
		caseManager.onStartCase -= TogglePlaintiff;
		caseManager.onEndCase -= ClearCaseFileUI;
	}

	//draw the case file ui
	private void DrawCaseFileUI(Case caseInstance)
	{
		if (caseInstance.caseID == 0)
		{
			caseDescription.text = caseInstance.caseDetails;
			chargesList.text = caseInstance.chargesDescription[0];
			defendant.text = Array.Find(caseInstance.persons, person => person.role == Person.Role.defendant).personName;
			witness.text = Array.Find(caseInstance.persons, person => person.role == Person.Role.witness).personName;

			if(caseInstance is CivilCase)
			{
				plaintiff.text = Array.Find(caseInstance.persons, person => person.role == Person.Role.plaintiff).personName;
			}

			int smallestArray = Mathf.Min(evidenceTextPrefab.Length, caseInstance.evidence.Length);
			for (int i = 0; i < smallestArray; i++)
			{
				evidenceTextPrefab[i].SetActive(true);
				evidenceTextPrefab[i].GetComponent<TextMeshProUGUI>().text = caseInstance.evidence[i].evidenceTitle;
			}
		}
	}

	//clear the case file ui
	private void ClearCaseFileUI()
	{
		caseDescription.text = "";
		chargesList.text = "";
		plaintiff.text = "";
		defendant.text = "";
		witness.text = "";

		for (int i = 0; i < evidenceTextPrefab.Length; i++)
		{
			evidenceTextPrefab[i].GetComponent<TextMeshProUGUI>().text = "";
		}
	}

	//toggle the plaintiff text in case its not necessary
	private void TogglePlaintiff(Case caseInstance)
	{
		if(caseInstance is CriminalCase) plaintiff.transform.parent.gameObject.SetActive(!plaintiff.gameObject.activeSelf);
	}
}
