using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectableMenu : MonoBehaviour
{
    [SerializeField] private SelectableMenuCase[] selectableMenuCases;


	//subscribe to event
        private void OnEnable()
	{
		SubscribeToCourtroomLoadSceneEvent();
	}

	//unsubscribe to event
	private void OnDisable()
	{
		UnsubscribeToCourtroomLoadSceneEvent();
	}

	//load courtroom scene
	//start a case
	private void LoadCourtRoomScene(Case caseInstance)
    {
        SceneManager.LoadScene(2);
		CaseManager.Instance.StartCase(caseInstance);
	}

	private void SubscribeToCourtroomLoadSceneEvent()
	{
		for (int i = 0; i < selectableMenuCases.Length; i++)
		{
			selectableMenuCases[i].onCourtroomScene += LoadCourtRoomScene;
		}
	}

	private void UnsubscribeToCourtroomLoadSceneEvent()
	{
		for (int i = 0; i < selectableMenuCases.Length; i++)
		{
			selectableMenuCases[i].onCourtroomScene -= LoadCourtRoomScene;
		}
	}
}
