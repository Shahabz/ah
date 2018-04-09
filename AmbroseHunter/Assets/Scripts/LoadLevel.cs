using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	public Slider thisProgressSlider;
	public Text thisProgressText;
	public void LoadLevelByInt(int thislevel)
	{
		StartCoroutine(LoadLevelAsync(thislevel));
	}

	public void LoadLevelByString(string thislevel)
	{
		SceneManager.LoadScene (thislevel, LoadSceneMode.Additive);
		//StartCoroutine(LoadLevelAsyncString(thislevel));
	}

	public void UnloadLevelByString(string thislevel)
	{
		SceneManager.UnloadSceneAsync (thislevel);
//		StartCoroutine(UnloadLevelAsyncString(thislevel));

	}

	IEnumerator UnloadLevelAsyncString (string thislevel)
	{
		AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync (thislevel);
		while (!asyncLoad.isDone) {
			if (thisProgressSlider != null)
				thisProgressSlider.value = asyncLoad.progress;
			if (thisProgressText != null)
				thisProgressText.text = (asyncLoad.progress*100).ToString("F0") + "%";
			yield return null;
		}
	}

	IEnumerator LoadLevelAsync (int whichlevel)
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync (whichlevel);
		while (!asyncLoad.isDone) {
			if (thisProgressSlider != null)
				thisProgressSlider.value = asyncLoad.progress;
			if (thisProgressText != null)
				thisProgressText.text = (asyncLoad.progress*100).ToString("F0") + "%";
			yield return null;
		}
	}

	IEnumerator LoadLevelAsyncString (string whichlevel)
	{
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync (whichlevel);
		while (!asyncLoad.isDone) {
			if (thisProgressSlider != null)
				thisProgressSlider.value = asyncLoad.progress;
			if (thisProgressText != null)
				thisProgressText.text = (asyncLoad.progress*100).ToString("F0") + "%";
			yield return null;
		}
	}
}
