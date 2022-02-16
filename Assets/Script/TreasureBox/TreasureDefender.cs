using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TreasureDefender : MonoBehaviour
{
    private GameObject Appearance;
    private GameObject monster;
    private GameObject Effect;
    private GameObject Monster;
    public Transform particleparent;

    public ParticleSystem PS;
    public Transform Pos;
    [Header("判定")]
    private bool isCheck;
    private float timer;
 
    // Start is called before the first frame update
    void Start()
    {
        Appearance = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Material 1/52SpecialEffectPack/Effect/Effect(Shuriken)/MagicCircleExplode.prefab");
        Monster = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/wizard_weapon_legacy DEMO.prefab");
        isCheck = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCheck)
        {
            if (timer == 0) Effect =Instantiate(Appearance, Pos.position, Quaternion.Euler(0, 0, 0));
            Monster.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            PS.startColor = Color.red;
            if(timer==0) monster=Instantiate(Monster, Pos.position, Quaternion.Euler(0, 180, 0));
            monster.tag = "Monster";
            particleparent.SetParent(monster.transform);
            isCheck = false;
            timer++;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isCheck = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isCheck = false;
            if(Effect!=null) Destroy(Effect);
        }
    }
}
