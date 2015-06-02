using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private static GameController instance;
	public static GameController Instance{
		get{
			if(instance==null){
				instance = GameObject.FindObjectOfType<GameController>();
				if(instance==null){
					GameObject gmo = new GameObject();
					instance = gmo.AddComponent<GameController>();
					instance.gameModel = gmo.AddComponent<GameModel>();
					gmo.name = "GameController";
				}
			}
			return instance;
		}
	}

	public GameModel gameModel;

	void Start(){
		DontDestroyOnLoad(this.gameObject);
		if(gameModel == null){
			this.GetComponent<GameModel>();
			if(gameModel == null){
				this.gameObject.AddComponent<GameModel>();
			}
		}
	}

	public void LoadGameScene(LevelModel levelModel){
		if(gameModel.Status == GameModel.SceneStatus.GameScene){
			Debug.Log ("already in game scene",this.gameObject);
			return;
		}else{
			gameModel.Status = GameModel.SceneStatus.LoadingScene;
		}
		if(levelModel == null){
			Debug.Log ("level model are null",this.gameObject);
			return;
		}
		if(gameModel.CurrentLevelModel != null){
			Destroy(gameModel.CurrentLevelModel);
		}	
		LevelModel tempLevelModel = this.gameObject.AddComponent<LevelModel>();
		tempLevelModel.CloneModel(levelModel);
		gameModel.CurrentLevelModel = tempLevelModel;
		StartCoroutine(LoadSceneAfterSecond(gameModel.CurrentLevelModel.scene.name,GameModel.SceneStatus.GameScene));

	}

	public void LoadMainMenu(){
		if(gameModel.Status == GameModel.SceneStatus.MainMenu){
			Debug.Log ("already in main menu scene",this.gameObject);
			return;
		}else{
			gameModel.Status = GameModel.SceneStatus.LoadingScene;
		}
		if(gameModel.CurrentLevelModel != null){
			Destroy(gameModel.CurrentLevelModel);
		}
		StartCoroutine(LoadSceneAfterSecond("Menu",GameModel.SceneStatus.MainMenu));
	}

	IEnumerator LoadSceneAfterSecond(string sceneName,GameModel.SceneStatus status){
		yield return new WaitForSeconds(1);
		StartCoroutine(LoadScene(sceneName,status));
	}

	IEnumerator LoadScene(string sceneName,GameModel.SceneStatus status){
		gameModel.LoadingOperation = Application.LoadLevelAsync(sceneName);
		yield return gameModel.LoadingOperation;
		gameModel.Status = status;
		Debug.Log("Loading complete");
	}
}
