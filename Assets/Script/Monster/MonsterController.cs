using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private GameObject target;
    private float movespeed;
    private float radius;
    private float attackRange;

    private Animator anim;
    private bool iswalk=false;
    private bool isidle=false;
    private bool isHaveAttacked=false;
    private float attackTime;
    //private float startTime;
    //private float journeyLength;
    private void Start()
    {
        movespeed = 0.8f;
        radius = 5f;
        anim = GetComponent<Animator>();
        attackRange = 3f;
        attackTime = 2.0f;
        //startTime = Time.time;
    }
    private void Update()
    {
        anim.SetBool("isWalk", iswalk);
        anim.SetBool("isIdle", isidle);
        attackTime -= Time.deltaTime;
        //float distCovered = (Time.time - startTime)*movespeed;
        if (FoundPlayer())
        {
            //print("发现玩家");
            //journeyLength = Vector3.Distance(transform.position, target.transform.position);
            //float fracJourney = distCovered / journeyLength;
            transform.LookAt(target.transform);
            transform.position = Vector3.Lerp(transform.position, target.transform.position, movespeed*Time.deltaTime);
            iswalk = true;
            if (PlayerInAttackRange() && attackTime <= 0)
            {
                anim.SetTrigger("Attack");
                if (Vector3.Distance(target.transform.position, transform.position) <= 2.9f)
                {
                    Camera.main.GetComponent<ShakeCamera>().enabled = true;
                }
                isHaveAttacked = true;
                attackTime = 2;
            }
        }
        if (isHaveAttacked && !FoundPlayer())
        {
            isidle = true;
        }
    }
    bool FoundPlayer()
    {
        var colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(var collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                target = collider.gameObject;
                return true;
            } 
        }
        target = null;
        return false;
    }
    bool PlayerInAttackRange()
    {
        //可以用距离的平方来代替Distance方法，Distance效率不高
        if (Vector3.Distance(target.transform.position, transform.position) <= attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
