using UnityEngine;
using System.Collections;

public class GameModel : EventEmiter {

	public enum SceneStatus {MainMenu, LoadingScene, GameScene};
	private SceneStatus status = SceneStatus.MainMenu;
	public SceneStatus Status{
		set{
			status = value;
			Changed();
		}
		get{
			return status;
		}
	} 
	private AsyncOperation loadingOperation;
	public AsyncOperation LoadingOperation{
		set{
			loadingOperation = value;
			Changed();
		}
		get{
			return loadingOperation;
		}
	}
	private LevelModel currentLevelModel;
	public LevelModel CurrentLevelModel{
		set{
			currentLevelModel = value;
			Changed();
		}
		get{
			return currentLevelModel;
		}
	}
}
