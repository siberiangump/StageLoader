using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {

	LevelModel levelModel;

	// Use this for initialization
	void Start () {
		levelModel = GameController.Instance.gameModel.CurrentLevelModel;
		if(!Validation()){
			return;
		}
		Instantiate(levelModel.character,
		            GameObject.FindGameObjectWithTag("Respawn").transform.position,
		            Quaternion.identity);
	}
	
	bool Validation(){
		if(levelModel == null){
			return false;
		}
		return true;
	}
}
