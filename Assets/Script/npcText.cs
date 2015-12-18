using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class npcText : MonoBehaviour {

	public static bool isPaused ;
	
	public GameObject npcTextCanvas;
	
	public GameObject resumeButton;
	//public Image i1;
	
	// Update is called once per frame
	void Start(){
		isPaused = true;
		Time.timeScale = 0;

	}
	void Update()
	{
		if (isPaused) {
			npcTextCanvas.SetActive (true);
			Time.timeScale = 0;
			EventSystem.current.SetSelectedGameObject(resumeButton);
		}
		else
		{
			npcTextCanvas.SetActive(false);
			Time.timeScale = 1f;
		}

	}
	
	public void Resume()
	{
		isPaused = false;
	}
	

	
	public void QuitCanvas()
	{
		npcTextCanvas.SetActive(false);
		Time.timeScale = 1f;

	}
}


