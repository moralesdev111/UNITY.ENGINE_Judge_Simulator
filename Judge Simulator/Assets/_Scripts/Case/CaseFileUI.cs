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
			UtilityClass.SetText(caseDescription, caseInstance.caseDetails);
			UtilityClass.SetText(chargesList, caseInstance.chargesDescription[0]);
			UtilityClass.SetText(defendant, Array.Find(caseInstance.persons, person => person.role == Person.Role.defendant).personName);
			UtilityClass.SetText(witness, Array.Find(caseInstance.persons, person => person.role == Person.Role.witness).personName);

			CheckIfNeedPlaintiffData(caseInstance);
			ToggleAndSetEvidenceText(caseInstance);
		}
	}

	//set evidence texts according to evidence number
	//set their respective names
	private void ToggleAndSetEvidenceText(Case caseInstance)
	{
		int smallestArray = Mathf.Min(evidenceTextPrefab.Length, caseInstance.evidence.Length);
		for (int i = 0; i < smallestArray; i++)
		{
			evidenceTextPrefab[i].SetActive(true);
			evidenceTextPrefab[i].GetComponent<TextMeshProUGUI>().text = caseInstance.evidence[i].evidenceTitle;
		}
	}

	//if its a civil case we will need to draw the plaintiff
	private void CheckIfNeedPlaintiffData(Case caseInstance)
	{
		if (caseInstance is CivilCase)
		{
			plaintiff.text = Array.Find(caseInstance.persons, person => person.role == Person.Role.plaintiff).personName;
		}
	}

	//clear the case file ui
	private void ClearCaseFileUI()
	{
		UtilityClass.ClearText(caseDescription, chargesList, plaintiff, defendant, witness);
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
