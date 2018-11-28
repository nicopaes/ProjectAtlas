using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeChangeScene : MonoBehaviour 
{
	public Text NextSceneText;
	
	[Space]
	[Header("ALL SCENES")]
	public List<SceneStruct> AllScenes;
	private String _nextScene;

	public void ChangeScene()
	{
		Debug.Log(_nextScene);
		foreach (SceneStruct scene in AllScenes)
		{
			Debug.Log(scene + "--" + _nextScene);
			if(Equals(_nextScene,scene.Name))
			{
				if(RenderSettings.skybox != scene.Skybox)
				{        
					RenderSettings.skybox = scene.Skybox;
					foreach(GameObject portal in scene.Portals)
					{
						portal.SetActive(true);   
					}
				}
			}
			else
			{
				foreach(GameObject portal in scene.Portals)
				{
					portal.SetActive(false);   
				}
			}
		}		
	}

	public void ChangeNextScene(string nextScene)
	{
		_nextScene = nextScene;
		NextSceneText.text = _nextScene;
		GetComponent<Animator>().SetTrigger("Fade");
	}

    [System.Serializable]
    public struct SceneStruct 
    {
        public String Name;
        public Material Skybox;
        public List<GameObject> Portals;
    }
}
