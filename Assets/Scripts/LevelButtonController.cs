using UnityEngine;
using System.Collections;

public class LevelButtonController : MonoBehaviour {

	public LevelModel levelModel;

	public void LoadLevel(){
		if(!Validation()){
			return;
		}
		GameController.Instance.LoadGameScene(levelModel);
	} 

	bool Validation(){
		if(levelModel==null){
			levelModel = this.GetComponent<LevelModel>();
		}
		if(levelModel==null){
			return false;
		}
		return true;
	}

}
