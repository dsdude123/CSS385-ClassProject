using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour {

	private Item carriedItem;
	private bool opened = false;
	public Sprite openChestSprite;

	public string name;
	public Sprite image;
	public uint count = 0;
	public bool reusable = false;
	// Use this for initialization
	void Start () {
		carriedItem = new Item ();
		carriedItem.name = this.name;
		carriedItem.image = this.image;
		carriedItem.count = this.count;
		carriedItem.reusable = this.reusable;
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag.Equals("Player")) {
			if (Input.GetKeyDown (KeyCode.E) && !opened) {
				PlayerInventory player = other.gameObject.GetComponent<PlayerInventory> ();
				player.AddItem (carriedItem);
				opened = true;
				this.GetComponent<SpriteRenderer> ().sprite = openChestSprite;
			}
		}
	}
}
