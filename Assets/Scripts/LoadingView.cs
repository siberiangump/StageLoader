using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingView : MonoBehaviour {

	GameModel gameModel;
	private bool needUpdate = false;

	void Awake(){
		LoadingView[] gmo = GameObject.FindObjectsOfType<LoadingView>();
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
	}

	void SubscribeOnEvents(){
		gameModel.Subscribe(Grab);
	}

	bool Validation(){
		if(gameModel == null){
			Debug.Log("check parametrs",this.gameObject);
			return false;
		}
		return true;
	}

	// Update is called once per frame
	void Update(){
		if(!needUpdate){
			return;
		}
		Grab();
	}

	void Grab () {
		if(!Validation()){
			return;
		}
		if(gameModel.Status != GameModel.SceneStatus.LoadingScene){
			this.GetComponent<Animator>().SetBool("Loading",false);
			needUpdate = false;
		}else{
			this.GetComponent<Animator>().SetBool("Loading",true);
			needUpdate = true;
		}
	}
}
