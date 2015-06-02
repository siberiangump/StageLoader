using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (LevelModel))]
public class LevelButtonView : MonoBehaviour {

	public LevelModel levelModel;

	public Text levelNameText;
	public Image characterImage;
	public Image levelColor;

	// Use this for initialization
	void Start () {
		if(!Validation()){
			return;
		}
		SubscribeOnEvents();
	}

	bool Validation(){
		if(levelModel == null){
			levelModel = GetComponent<LevelModel>();
		}
		if(levelColor == null){
			levelColor = GetComponent<Image>();
		}
		if(characterImage == null){
			characterImage = this.transform.GetComponentInChildren<Image>();
		}
		if(levelNameText == null){
			levelNameText = this.transform.GetComponentInChildren<Text>();
		}
		if(levelModel == null || levelNameText == null || characterImage == null || levelColor == null){
			Debug.Log("check button parameters",this.gameObject);
			return false;
		}
		return true;
	}

	void SubscribeOnEvents(){
		levelModel.Subscribe(Grab);
	}

	void Grab(){
		if(!Validation()){
			return;
		}
		levelColor.color = levelModel.backColor;
		levelNameText.text = levelModel.levelName;
		characterImage.sprite = levelModel.character.GetComponent<SpriteRenderer>().sprite;
	}

}
