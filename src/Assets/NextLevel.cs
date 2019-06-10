using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NextLevel : MonoBehaviour
{
    public int nextLevel = 2;
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        print("Player finished");
        if (col.tag.Equals("Player"))
        {
			Item i = col.gameObject.GetComponent<PlayerInventory> ().FindItem ("Potion");
			if (i == null) {
				PlayerPrefs.SetInt ("Potions", 0);
			} else {
				PlayerPrefs.SetInt ("Potions", (int)i.count);
			}
            print("Player finished");
            LoadNextScene(nextLevel);
        }
    }


    public void LoadNextScene(int build)
    {
		
        SceneManager.LoadScene("Level " + nextLevel);
    }
}
