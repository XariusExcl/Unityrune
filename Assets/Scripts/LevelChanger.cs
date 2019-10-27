using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
	Animator animator;

	private string levelToLoad;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void FadeToLevel (string level)
	{
		levelToLoad = level;
		animator.SetTrigger("FadeOut");
	}

	public void OnFadeComplete ()
	{
		SceneManager.LoadScene(levelToLoad);
	}
}

