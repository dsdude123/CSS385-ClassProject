using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {

	public List<Item> items;
	public GameObject potionButtonText;

	// Use this for initialization
	void Start () {
		items = new List<Item> ();
			uint toAdd = (uint)PlayerPrefs.GetInt("Potions");
			if(toAdd > 0) {
				Item potion = new Item();
				potion.count = toAdd;
				potion.name = "Potion";
				AddItem(potion);
			}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Item FindItem(string name){
		foreach (Item i in items) {
			if (i.name.Equals (name)) {
				return i;
			}
		}
		return null;
	}

	public void ReplaceItem(Item newItem){
		UpdateItemButtonUI (newItem);
		for(int i = 0; i < items.Count; i++) {
			if (items[i].name.Equals (newItem.name)) {
				items [i] = newItem;
				return;
			}
		}
		items.Add (newItem);
	}

	public void AddItem(Item newItem){
		ReplaceItem (newItem);
	}

	public void UsePotion(){
		Item potion = FindItem ("Potion");
		if(potion != null){
			if(potion.count > 0){
				Health myHealth = this.gameObject.GetComponent<Health> ();
				myHealth.currentHealth++;
				potion.count--;
				ReplaceItem (potion);
			}
		}
	}

	void UpdateItemButtonUI(Item item){
		if(item.name.Equals("Potion")){
			potionButtonText.GetComponent<UnityEngine.UI.Text> ().text = "Use Potion x" + item.count;
		}
	}

}
