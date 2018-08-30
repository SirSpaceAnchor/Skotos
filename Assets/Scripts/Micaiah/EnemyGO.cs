using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerBaseGO : MonoBehaviour
{
    public Player player;
    public int ID = 0;
    public static int _ID = -1;

    public void TakeDamage(float damage)
    {
        player.TakeDamage(damage);
    }
}

public class EnemyGO : PlayerBaseGO
{
    public HealthSystem healthSystem;
    public TMP_Text titleText;
    public BoxCollider boxCollider;
    public Rigidbody rb;

    public GunGO gun1;
    public GameObject target;

    private void Awake()
    {
        _ID++;
        ID = _ID;
        player = ScriptableObject.CreateInstance<Player>();
        healthSystem.player = player;
        player.Health = 200;
        player.HealthMax = 200;
        player.damage = RankType.Strong;
        player.Name = "MikHaven" + "-" + ID.ToString();
        titleText.text = player.Name;
    }

    // Use this for initialization
    void Start()
    {

    }

    private float weaponCooldown = 1f;
    private float weaponFireDelay = 3;

    // Update is called once per frame
    void Update()
    {
        if (player.Health <= 0)
        {
            player.isDead = true;
            Destroy(boxCollider);
            rb.constraints = RigidbodyConstraints.None;
            return;
        }

        if (target != null)
        {
            transform.LookAt(target.transform.position);
            gun1.target = target.transform;
            if (weaponCooldown <= 0)
            {
                if (gun1 != null)
                {
                    gun1.Fire();
                }
                weaponCooldown = weaponFireDelay;
            }
            else
            {
                weaponCooldown -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerGO player = other.GetComponent<PlayerGO>();
        if (player != null)
        {
            target = player.gameObject;
        }
    }
}