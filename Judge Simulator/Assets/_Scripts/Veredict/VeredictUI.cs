using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VeredictUI : MonoBehaviour
{
    [SerializeField] private CaseManager caseManager;
    [SerializeField] private Button guiltyButton;
    [SerializeField] private Button innocentButton;

        private void Start()
    {
        guiltyButton.onClick.AddListener(() => EndCase(true));
		innocentButton.onClick.AddListener(() => EndCase(false));

	}

        private void Update()
    {
		guiltyButton.onClick.RemoveListener(() => EndCase(true));
		innocentButton.onClick.RemoveListener(() => EndCase(false));
	}

    private void EndCase(bool guilty)
    {
        if(guilty)
        {
            print("guilty");
        }
        else
        {
            print("innocent");
        }
        caseManager.EndCase();
        SceneManager.LoadScene(1);
    }
}
