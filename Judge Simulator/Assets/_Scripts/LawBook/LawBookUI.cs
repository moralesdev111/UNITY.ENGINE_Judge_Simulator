using TMPro;
using UnityEngine;

public class LawBookUI : MonoBehaviour
{
	[SerializeField] private LawBook lawBook;
	[SerializeField] private CaseManager caseManager;
    [SerializeField] private TextMeshProUGUI articleNumber;
	[SerializeField] private TextMeshProUGUI section1Text;
	[SerializeField] private TextMeshProUGUI section2Text;
	[SerializeField] private TextMeshProUGUI section3Text;


	//subscribe to case start and case end
	private void OnEnable()
	{
		caseManager.onStartCase += DrawLawBookUI;
		caseManager.onEndCase += ClearLawBookUI;
	}

	//unsubscribe to case start and case end
	private void OnDisable()
	{
		caseManager.onStartCase -= DrawLawBookUI;
		caseManager.onEndCase -= ClearLawBookUI;
	}

	//draw law book articles depending on case
	private void DrawLawBookUI(Case caseInstance)
	{
		if (caseInstance.caseID == 0) 
		{
			articleNumber.text = "Article " + lawBook.case0Law.articleNumber.ToString();
			section1Text.text = lawBook.case0Law.articleDescriptions[0];
			section2Text.text = lawBook.case0Law.articleDescriptions[1];
			section3Text.text = lawBook.case0Law.articleDescriptions[2];
		}
	}

	//clear law book article text
	private void ClearLawBookUI()
	{
		articleNumber.text = "";
		section1Text.text = "";
		section2Text.text = "";
		section3Text.text = "";
	}
}
