using UnityEngine;
using System.Collections;


public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name){
		Debug.Log ("Level load requested"+name);
		Brick.breakableCount = 0; // reset the bricks when new level is loaded
		Application.LoadLevel (name);

	}
	public void QuitRequest(string quit){
		
		Debug.Log ("Level Quit requested"+quit);
		Application.Quit ();
	}
	public void LoadNextLevel() {
		Brick.breakableCount = 0;
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	public void BrickDestroyed(){
		if(Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}
}
