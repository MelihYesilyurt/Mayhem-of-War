﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    public GameObject oldKnight;
    public GameObject youngWarrior;
    public GameObject femaleKnight;
    public GameObject aloneSamurai;
    public GameObject king;
    private GameObject choosenCharacter;
    private GameObject spawnedCharacter;
    private int characterid;
    private void Awake()
    {
        characterid = PlayerPrefs.GetInt("SelectCharacter");
        SelectCharacter();
        Spawn();
    }
    public void Start()
    {
        LevelController.Instance.character = spawnedCharacter.transform;
    }
    public  void Spawn()
    {
        spawnedCharacter= Instantiate(choosenCharacter, spawnPoint.transform.position, spawnPoint.transform.rotation);
        GetComponent<CharacterFollower>().character = spawnedCharacter;
    }
    private void SelectCharacter()
   {
       if(characterid==1)
       {
           choosenCharacter = oldKnight;
       }
       else if(characterid==2)
       {
           choosenCharacter = youngWarrior;
       }
       else if (characterid == 3)
       {
           choosenCharacter = femaleKnight;
       }
       else if (characterid == 4)
       {
           choosenCharacter = aloneSamurai;
       }
       else if (characterid == 5)
       {
           choosenCharacter = king;
       }
   }
}
