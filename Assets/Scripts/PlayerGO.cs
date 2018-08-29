using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// This is our Player's MAIN object (easier than using tags)
/// </summary>
public class PlayerGO : MonoBehaviour
{
    public Player player;
    public World world;

    public int gunIndex = 0;
    private int gunCount = 0;

    public TMP_Text playerName;
    public TMP_Text worldText;
    public TMP_Text playerExtra;

    public TMP_Text text0;
    public TMP_Text text1;
    public TMP_Text text2;

    public AudioClip[] clips;
    public int clipIndex = 0;
    public float SpeakTimer = 1f;

    public void Hurt(int damage)
    {
        player.TakeDamage(damage);
    }

    public void Heal(int damage)
    {
        player.HealDamage(damage);
    }

    // Use this for initialization
    void Start()
    {
        player = ScriptableObject.CreateInstance<Player>();
        playerName.text = player.Name;
        //AudioManager.instance.Play(StatusType.WakeUp.ToString(), true);
        SpeakTimer = 1f;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            gunIndex--;
            if (gunIndex < gunCount)
            {
                gunIndex = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            gunIndex++;
            if (gunIndex > gunCount)
            {
                gunIndex = 0;
            }
        }

        worldText.text = player.Health.ToString() + "/100 Health";
        playerExtra.text = player.Energy.ToString() + "/100 Energy";
        // Removed bullets, and added in Dialogue to shorted dev time.
        text0.text = "Light Gun";// + " 25/50";
        text1.text = Strings.Light(world.isLight);
        text2.text = Strings.Morph(world.isMorph);


        if (SpeakTimer <= 0)
        {
            SpeakTimer = GameSettings.PlayerYakDelay;
            if (clips.Length > clipIndex)
            {
                if (AudioManager.instance.Play(clips[clipIndex]))
                {
                    clipIndex++;
                }
            }
            else
            {
                UnityEngine.Debug.Log("Ran out of One Liners");
            }
        }
        SpeakTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        ResearchPickUp note = other.GetComponent<ResearchPickUp>();
        if (note != null)
        {
            AudioManager.instance.Play(note.clip);
            SpeakTimer += 3f;
            Destroy(note.gameObject);
        }
    }
}
