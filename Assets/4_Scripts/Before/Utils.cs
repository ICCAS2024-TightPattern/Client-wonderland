using UnityEngine.SceneManagement;

public enum SceneNames { Logo=0, Login, Loby, Game, }

public static class Utils
{
	public static string GetActiveScene()
	{
		return SceneManager.GetActiveScene().name;
	}

	public static void LoadScene(string sceneName="")
	{
		if ( sceneName == "" )
		{
			SceneManager.LoadScene(GetActiveScene());
		}
		else
		{
			SceneManager.LoadScene(sceneName);
		}
	}

	public static void LoadScene(SceneNames sceneName)
	{
		// SceneNames 열거형으로 매개변수를 받아온 경우 ToString()으로 처리
		SceneManager.LoadScene(sceneName.ToString());
	}
}


public static class SceneTheme
{
	public static string theme;
}
