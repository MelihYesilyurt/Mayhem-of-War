﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MarketScript : MonoBehaviour
{
    [SerializeField] private Button startGame;
    [SerializeField] private Button mainMenu;
    [SerializeField] private Text goldAmountText;
    [SerializeField] private Button yesText;
    [SerializeField] private Button noText;
    [SerializeField] private Canvas areYouSure;
    [SerializeField] private Canvas youHaveNoMoney;
    [SerializeField] private Button closeButton;
    private int characterid;
    private int mapid = 0;
    private GameObject choosenLock;
    private int money;
    private int valueOfLock;
    private string bought ="bought";
   // private int godGift =1000;
    private void Awake()
    {
       // PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("GoldCoin", godGift);
        GameObject[] locks;
        locks = GameObject.FindGameObjectsWithTag("Lock");
        foreach (GameObject lockImage in locks)
        {
            if(PlayerPrefs.GetString(lockImage.name) == bought)
            {
                lockImage.SetActive(false);
            }
            else
            {
                lockImage.SetActive(true);
            }
        }
    }
    void Start()
    {
        characterid = 0;
        money = PlayerPrefs.GetInt("GoldCoin");
        areYouSure.enabled = false;
        youHaveNoMoney.enabled = false;
    }
    public void StartGame()
    {
        if (mapid != 0)
        {
            if (characterid != 0)
            {
                Application.LoadLevel(mapid);
                PlayerPrefs.SetInt("SelectCharacter", characterid);
            }
        }
    }

    public void GoMainMenu()
    {
        Application.LoadLevel(0);
    }
    public void YesPress()
    {
        if(money>=valueOfLock)
        {
            choosenLock.SetActive(false);
            money -= valueOfLock;
          //  PlayerPrefs.DeleteKey("GoldCoin");
            PlayerPrefs.SetInt("GoldCoin", money);
            
            PlayerPrefs.SetString(choosenLock.name,bought);
           // Debug.Log(choosenLock.name);
        }
        else
        {
            youHaveNoMoney.enabled = true;
        }
        areYouSure.enabled = false;    
    }
    public void NoPress()
    {
        areYouSure.enabled = false;
    }
    public void close()
    {
        youHaveNoMoney.enabled = false;
    }
    private void Update()
    {
        goldAmountText.text =""+ money;
        PlayerPrefs.SetInt("GoldCoin", money);
       // Debug.Log(PlayerPrefs.GetInt("GoldCoin"));
    }
    public void Lock(GameObject takenLock)
    {
        choosenLock = takenLock;
        areYouSure.enabled = true;
        valueOfLock = takenLock.GetComponent<Lock>().value;
    }
    public void ChooseMap(GameObject choosenMap)
    {
        GameObject[] maps;
        maps = GameObject.FindGameObjectsWithTag("Maps");
        foreach (GameObject map in maps)
        {
            map.GetComponent<Outline>().enabled = false;
        }
        if (choosenMap.name=="Map1")
        {
            choosenMap.GetComponent<Outline>().enabled = true;
            mapid = 2;
        }
        else if (choosenMap.name == "Map2")
        {
            choosenMap.GetComponent<Outline>().enabled = true;
            mapid = 3;
        }
        else if (choosenMap.name == "Map3")
        {
            choosenMap.GetComponent<Outline>().enabled = true;
            mapid = 4;
        }
        else if (choosenMap.name == "Map4")
        {
            choosenMap.GetComponent<Outline>().enabled = true;
            mapid = 5;
        }
        else if (choosenMap.name == "Map5")
        {
            choosenMap.GetComponent<Outline>().enabled = true;
            mapid = 6;
        }
    }
    public void ChooseCharacter(GameObject choosenCharacter)
    {
        GameObject[] characters;
        characters = GameObject.FindGameObjectsWithTag("Characters");
        foreach (GameObject character in characters)
        {
            character.GetComponent<Outline>().enabled = false;
        }
        if (choosenCharacter.name == "Old Knight")
        {
            choosenCharacter.GetComponent<Outline>().enabled = true;
            characterid = 1;
        }
        else if (choosenCharacter.name == "Young Warrior")
        {
            choosenCharacter.GetComponent<Outline>().enabled = true;
            characterid = 2;
        }
        else if (choosenCharacter.name == "Female Knight")
        {
            choosenCharacter.GetComponent<Outline>().enabled = true;
            characterid = 3;
        }
        else if (choosenCharacter.name == "Alone Samurai")
        {
            choosenCharacter.GetComponent<Outline>().enabled = true;
            characterid = 4;
        }
        else if (choosenCharacter.name == "King")
        {
            choosenCharacter.GetComponent<Outline>().enabled = true;
            characterid = 5;
        }
    }
}
