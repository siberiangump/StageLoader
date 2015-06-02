using UnityEngine;
using System.Collections;

public class LevelModel : EventEmiter {

	public string levelName;
	public Object scene;
	public GameObject character;
	public Color32 backColor;

	public void CloneModel(LevelModel from){
		levelName = from.levelName;
		scene = from.scene;
		character = from.character;
		backColor = from.backColor;
	} 
}
