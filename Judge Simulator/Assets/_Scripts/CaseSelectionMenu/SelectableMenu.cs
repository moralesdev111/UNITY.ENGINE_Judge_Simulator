using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectableMenu : MonoBehaviour
{
    [SerializeField] private SelectableMenuCase[] selectableMenuCases;


	//subscribe to event
    private void OnEnable()
	{
		UtilityClass.SubscribeObjectsToEvent(selectableMenuCases, selectableMenuCase => selectableMenuCase.onCourtroomScene += LoadCourtRoomScene);
	}

	//unsubscribe to event
	private void OnDisable()
	{
		UtilityClass.UnsubscribeObjectFromEvent(selectableMenuCases, selectableMenuCase => selectableMenuCase.onCourtroomScene -= LoadCourtRoomScene);
	}

	//load courtroom scene
	//start a case
	private void LoadCourtRoomScene(Case caseInstance)
    {
        SceneManager.LoadScene(2);
		CaseManager.Instance.StartCase(caseInstance);
	}
}
