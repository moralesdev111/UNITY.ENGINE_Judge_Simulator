using TMPro;
using UnityEngine;
using System;
using System.Runtime.InteropServices;

public class CaseFileUI : MonoBehaviour
{
	[SerializeField] private CaseManager caseManager;
	[SerializeField] private TextMeshProUGUI caseDescription;
	[SerializeField] private TextMeshProUGUI plaintiffProsecutorTitle;
	[SerializeField] private TextMeshProUGUI plaintiffProsecutor;
	[SerializeField] private TextMeshProUGUI plaintiffProsecutorSurname;
	[SerializeField] private TextMeshProUGUI defendant;
	[SerializeField] private TextMeshProUGUI defendantSurname;
	[SerializeField] private TextMeshProUGUI witness;
	[SerializeField] private TextMeshProUGUI witnessSurname;
	[SerializeField] private TextMeshProUGUI[] charges;
	[SerializeField] private TextMeshProUGUI[] evidences;


	//subscribe to case start and case end
	private void OnEnable()
	{
		caseManager.onStartCase += DrawCaseFileUI;
		caseManager.onEndCase += ClearCaseFileUI;
	}

	//unsubscribe to case start and case end
	private void OnDisable()
	{
		caseManager.onStartCase -= DrawCaseFileUI;
		caseManager.onEndCase -= ClearCaseFileUI;
	}

	//draw the case file ui
	private void DrawCaseFileUI(Case caseInstance)
	{
		if (caseInstance.caseID == 0)
		{
			UtilityClass.SetText(caseDescription, caseInstance.caseDetails);

			UtilityClass.SetUIArrayElementsActiveAndText(charges, caseInstance.chargesDescription);

			UtilityClass.SetText(defendant, Array.Find(caseInstance.persons, person => person.role == Person.Role.defendant).personName);
			UtilityClass.SetText(defendantSurname, Array.Find(caseInstance.persons, person => person.role == Person.Role.defendant).personSurname);
			UtilityClass.SetText(witness, Array.Find(caseInstance.persons, person => person.role == Person.Role.witness).personName);
			UtilityClass.SetText(witnessSurname, Array.Find(caseInstance.persons, person => person.role == Person.Role.witness).personSurname);

			if (caseInstance is CriminalCase)
			{
				UtilityClass.SetText(plaintiffProsecutorTitle, "Prosecutor");
				UtilityClass.SetText(plaintiffProsecutor, Array.Find(caseInstance.persons, person => person.role == Person.Role.prosecutor).personName);
				UtilityClass.SetText(plaintiffProsecutorSurname, Array.Find(caseInstance.persons, person => person.role == Person.Role.prosecutor).personSurname);
			}
			else
			{
				UtilityClass.SetText(plaintiffProsecutorTitle, "Plaintiff");
				UtilityClass.SetText(plaintiffProsecutor, Array.Find(caseInstance.persons, person => person.role == Person.Role.plaintiff).personName);
				UtilityClass.SetText(plaintiffProsecutorSurname, Array.Find(caseInstance.persons, person => person.role == Person.Role.plaintiff).personSurname);
			}
			UtilityClass.SetUIArrayElementsActiveAndText(evidences, Array.ConvertAll(caseInstance.evidence, e => e.evidenceTitle));
		}
	}

	
	//clear the case file ui
	private void ClearCaseFileUI()
	{
		UtilityClass.ClearText(caseDescription, charges[0], charges[1], charges[2], charges[3], plaintiffProsecutor, plaintiffProsecutorSurname, defendant, defendantSurname, witness, witnessSurname, evidences[0], evidences[1], evidences[2], evidences[3]);
	}
}