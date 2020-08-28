﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyRanged : MonoBehaviour
{
    private string isAttacking = "Isattacking";
    public static EnemyRanged Instance;
    private string isDamaged = "IsDamaged";
    private EnemyStatus status;
    private Rigidbody2D rigibody;
    public float attackRange;
    [SerializeField] private int damage;
    public LayerMask enemyLayers;
    [SerializeField] private int spendedStamina;
    [SerializeField] private int CriticalPossiblity;
    private Animator animator;
    [SerializeField]private GameObject arrow;
    private Transform character;
    public float launchForce;
    private int numberArrows=0;
    private GameObject[] Arrows;

    void Awake()
    {
        Instance = GetComponent<EnemyRanged>();
    }
    void Start()
    {
        character = LevelController.Instance.character;
        rigibody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        status = GetComponent<EnemyStatus>();
        Arrows = new GameObject[3];
    }
    public void Attack()
    {
        if (status.stamina > spendedStamina)
        {
            animator.SetTrigger(isAttacking);
            status.stamina = status.stamina - spendedStamina;    
            GameObject newArrow = Instantiate(arrow, transform.position, character.rotation);
            Vector3 temp = new Vector3(0, -0.07619f, 0);
            newArrow.transform.position += temp;
            Arrows[numberArrows] = newArrow;
            numberArrows++;         
            if (character.transform.position.x > transform.localPosition.x)
            {
                newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, 1);
                }
                else
                {
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);
                }
                if (arrow.transform.localScale.x < 0)
                {
                    arrow.transform.localScale = new Vector3(-1 * arrow.transform.localScale.x, arrow.transform.localScale.y, 1);   
                }
                else
                {
                    arrow.transform.localScale = new Vector3( arrow.transform.localScale.x, arrow.transform.localScale.y, 1);          
                }
            }
            else if (character.transform.position.x < transform.localPosition.x)
            {
                newArrow.GetComponent<Rigidbody2D>().velocity = -transform.right * launchForce;
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 1);                  
                }
                else
                {
                    transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, 1);       
                }
                if(arrow.transform.localScale.x <0)
                {
                    arrow.transform.localScale = new Vector3(arrow.transform.localScale.x, arrow.transform.localScale.y, 1);
 
                }
                else
                {
                    arrow.transform.localScale = new Vector3(-1* arrow.transform.localScale.x, arrow.transform.localScale.y, 1);
                   
                }
            }
            if (numberArrows > 2)
            {
                Destroy(Arrows[0]);
                Arrows[0] = Arrows[1];
                Arrows[1] = Arrows[2];
                numberArrows--;
            }
        }
    }
    public void TakeDamage(int damage, int knockback, Transform character)
    {
        status.health -= damage;
        animator.SetTrigger(isDamaged);
        if (transform.position.x > character.position.x)
        {
            rigibody.AddForce(new Vector2(knockback, 0));
        }
        if (transform.position.x < character.position.x)
        {
            rigibody.AddForce(new Vector2(-knockback, 0));
        }
    }
    public void ArrowArrived()
    {
        int random = UnityEngine.Random.Range(0, 100);
        int currentDamage = damage;
        if (random < CriticalPossiblity)
        {
            currentDamage = damage * 2;
        }
        PlayerCombat playerCombat = character.GetComponent<PlayerCombat>();
        playerCombat.TakeDamage(currentDamage);
    }
}
