using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {


	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public AudioClip crack;
	public GameObject Smoke;

	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable; 

	// Use this for initialization
	void Start () {
		isBreakable = this.tag =="Breakable";
		// keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;

		}


		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	



	// Update is called once per frame
	void Update () {
	

	}

	void OnCollisionEnter2D(Collision2D Col){
		AudioSource.PlayClipAtPoint (crack,transform.position,0.5f);
		if (isBreakable) {
			HandleHits ();
		}
	}


	void HandleHits (){
		timesHit++;
		//Simulate ();
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed();
			GameObject smokePuff = Instantiate(Smoke,transform.position,Quaternion.identity) as GameObject;
			smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
			Destroy (gameObject);
		} else {
			LoadSprites();
		}
	}

	void LoadSprites (){
		int spritIndex = timesHit - 1;

		if (hitSprites [spritIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spritIndex];
		}
	} 

	//TODO destroy this method

	void Simulate (){
		levelManager.LoadNextLevel ();
	}
}
