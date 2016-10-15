using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;  // Unity 5.3 or higher, see http://docs.unity3d.com/Manual/UpgradeGuide53.html and http://docs.unity3d.com/530/Documentation/ScriptReference/SceneManagement.SceneManager.html

public class LevelReset : MonoBehaviour , IPointerClickHandler
{

	public void OnPointerClick (PointerEventData data) {

		// reload the scene
		SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
	}

	private void Update()
	{
	}
}
