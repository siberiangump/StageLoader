using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackButtonView : MonoBehaviour {

	public GameModel gameModel;
	public Button backButton;

	void Awake(){
		BackButtonView[] gmo = GameObject.FindObjectsOfType<BackButtonView>();
		if(gmo.Length>1){
			DestroyImmediate(this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
		gameModel = GameController.Instance.gameModel;
		if(!Validation()){
			return;
		}
		SubscribeOnEvents();
		backButton.onClick.AddListener(GameController.Instance.LoadMainMenu);
	}	

	void SubscribeOnEvents(){
		gameModel.Subscribe(Grab);
	}

	bool Validation(){
		if(backButton == null){
			backButton=this.transform.GetComponentInChildren<Button>();
		}
		if(backButton == null || gameModel == null){
			Debug.Log("check parametrs",this.gameObject);
			return false;
		}
		return true;
	}

	
	void Grab () {
		if(!Validation()){
			return;
		}
		if(gameModel.Status == GameModel.SceneStatus.GameScene){
			backButton.gameObject.SetActive(true);
		}else{
			backButton.gameObject.SetActive(false);
		}
	}
}
