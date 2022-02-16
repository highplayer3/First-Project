using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ChangeSkyBox : MonoBehaviour
{
    
    private int time = System.DateTime.Now.Hour;
    public Material[] mats;
    [Header("Monster相关")]
    private ParticleSystem ff;//水井的萤火虫特效
    private ParticleSystem Sprite;
    private GameObject DeadEffect;//死神特效和光之精灵相遇后的中和特效
    private GameObject deadeffect;
    private float CoolingTime; //两个粒子相互中和的时间
    public ParticleSystem wizardEffect;
    private int num;

    public Transform wellPos;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        CoolingTime = 3f;
        ff = AssetDatabase.LoadAssetAtPath<ParticleSystem>("Assets/Prefabs/FireFly.prefab");
        DeadEffect = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Material 1/52SpecialEffectPack/Effect/Effect(Shuriken)/Explode7.prefab");
        if (time >= 20&&time<=23)
        {
            Sprite=Instantiate(ff, wellPos.transform.position, Quaternion.Euler(0, 0, 0));
        }
        if (time >= 0 && time <= 5)
        {
            RenderSettings.skybox = mats[0];
        }
        if (time >= 6 && time <= 11)
        {
            RenderSettings.skybox = mats[1];
        }
        if (time >= 12 && time <= 17)
        {
            RenderSettings.skybox = mats[2];
        }
        if (time >= 18 && time <= 23)
        {
            RenderSettings.skybox = mats[3];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Sprite != null)
        {
            AttackWizard(Sprite);
        }
    }
    void AttackWizard(ParticleSystem sprite)
    {
        //print(sprite.gameObject.name);
        var Col = Physics.OverlapSphere(sprite.transform.position, 2f);
        foreach(var T in Col)
        {
            if (T.CompareTag("Monster"))
            {
                //print("找到怪物");
                CoolingTime -= Time.deltaTime;
                sprite.transform.position = Vector3.Lerp(sprite.transform.position, T.transform.position, Time.deltaTime);
                wizardEffect.startColor = Color.white;
                T.GetComponent<MonsterController>().enabled = false;
                Animator anim = T.GetComponent<Animator>();
                if (CoolingTime <= 0 && num == 0)
                {
                    deadeffect = Instantiate(DeadEffect, T.transform.position, Quaternion.Euler(0, 0, 0));
                    anim.SetTrigger("Dead");
                    num++;
                }
            }
        }
    }
}
