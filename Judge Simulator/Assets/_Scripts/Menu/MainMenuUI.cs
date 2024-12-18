using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
	[SerializeField] private Button playButton;
	public Button PlayButton => playButton;
	[SerializeField] private Button quitButton;
	public Button QuitButton => quitButton;


	//play and quit game add listeners
	private void OnEnable()
	{
		playButton.onClick.AddListener(StartGame);
		quitButton.onClick.AddListener(QuitGame);
	}

	//play and quit game remove listeners
	private void OnDisable()
	{
		playButton.onClick.RemoveListener(StartGame);
		quitButton.onClick.RemoveListener(QuitGame);
	}

	//load case selection scene
	private void StartGame()
	{
		SceneManager.LoadScene(1);		
	}

	//quit game
	private void QuitGame()
	{
		Application.Quit();
	}
}
