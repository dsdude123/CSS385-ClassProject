using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class teleport : MonoBehaviour
{
    public float timer;
    private Transform player;
    private GameObject checker;
    Vector3 v3 = Vector3.one;
    Vector2 v2;
    private RectTransform coolDownTimer;
    private Animator animator;
    bool isLevel2;
    private TilemapCollider2D tmap0, tmap1, tmap2, tmap3;
    private const float MAX_TIMER = 10;

    void Awake()
    {
        animator = this.GetComponent<Animator>();
        timer = MAX_TIMER;
        isLevel2 = SceneManager.GetActiveScene().name.Equals("Level 2");
        findTilemaps();
        coolDownTimer = GameObject.Find("Canvas/Timer").GetComponent<Image>().rectTransform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        checker = GameObject.FindGameObjectWithTag("TeleportChecker");
        checker.transform.position = player.position;
    }

    void Update()
    {
        v3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        v2 = v3;
        checker.transform.position = v3;
        if (timer < MAX_TIMER)
        {
            timer += Time.deltaTime;
            coolDownTimer.sizeDelta = new Vector2(15 * timer, coolDownTimer.sizeDelta.y);
        }
        if (timer > MAX_TIMER)
        {
            timer = MAX_TIMER;
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetMouseButtonDown(0) && timer == MAX_TIMER)
        {
            if (checkingFunc())
            {
                Teleport();
            }
        }
    }

    void Teleport()
    {
        player.position = v2;
        timer = 0;
        coolDownTimer.sizeDelta = new Vector2(0, coolDownTimer.sizeDelta.y);

    }

    bool checkingFunc()
    {
        if (isLevel2)
        {
            if (tmap0.IsTouching(checker.GetComponent<BoxCollider2D>()) ||
                        tmap1.IsTouching(checker.GetComponent<BoxCollider2D>()) ||
                        tmap2.IsTouching(checker.GetComponent<BoxCollider2D>()) ||
                        tmap3.IsTouching(checker.GetComponent<BoxCollider2D>()))
                return false;
            else
                return true;
        }
        if (tmap0.IsTouching(checker.GetComponent<BoxCollider2D>()) ||
                    tmap1.IsTouching(checker.GetComponent<BoxCollider2D>()))
            return false;
        else
            return true;

    }
    void findTilemaps()
    {
        if (isLevel2)
        {
            tmap0 = GameObject.Find("Grid/Scenery with a hitbox").GetComponent<TilemapCollider2D>();
            tmap1 = GameObject.Find("Grid/Decoration with hitbox").GetComponent<TilemapCollider2D>();
            tmap2 = GameObject.Find("Grid/Decoration-Island").GetComponent<TilemapCollider2D>();
            tmap3 = GameObject.Find("Grid/Tilemap with hitbox").GetComponent<TilemapCollider2D>();
        }
        else
        {
            tmap0 = GameObject.Find("Grid/Scenery with a hitbox").GetComponent<TilemapCollider2D>();
            tmap1 = GameObject.Find("Grid/Tilemap with hitbox").GetComponent<TilemapCollider2D>();

        }
    }
}