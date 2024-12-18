using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectableMenu : MonoBehaviour
{
    [SerializeField] private SelectableMenuCase[] selectableMenuCases;


        private void OnEnable()
        {
        for (int i = 0; i < selectableMenuCases.Length; i++)
            {
            selectableMenuCases[i].onCourtroomScene += LoadCourtRoomScene;
		    }
         }

        private void OnDisable()
        {
		for (int i = 0; i < selectableMenuCases.Length; i++)
		    {
		    	selectableMenuCases[i].onCourtroomScene -= LoadCourtRoomScene;
		    }
	    }

    private void LoadCourtRoomScene(Case caseInstance)
    {
        SceneManager.LoadScene(2);
		CaseManager.Instance.StartCase(caseInstance);
	}
}
