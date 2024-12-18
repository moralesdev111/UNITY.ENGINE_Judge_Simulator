using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
	[SerializeField] private Button playButton;
	public Button PlayButton => playButton;
	[SerializeField] private Button quitButton;
	public Button QuitButton => quitButton;


	private void OnEnable()
	{
		playButton.onClick.AddListener(StartGame);
		quitButton.onClick.AddListener(QuitGame);
	}

	
	private void OnDisable()
	{
		playButton.onClick.RemoveListener(StartGame);
		quitButton.onClick.RemoveListener(QuitGame);
	}

	private void StartGame()
	{
		SceneManager.LoadScene(1);		
	}

	private void QuitGame()
	{
		Application.Quit();
	}
}
