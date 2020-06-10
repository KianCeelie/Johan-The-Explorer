using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip jumpSound, swordSound, whipSound, gunSound, coinSound, switchWeaponSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip> ("Jumping");
        swordSound = Resources.Load<AudioClip>("SwordAttack");
        whipSound = Resources.Load<AudioClip>("WhipAttack");
        gunSound = Resources.Load<AudioClip>("GunAttack");
        coinSound = Resources.Load<AudioClip>("CoinPickup");
        switchWeaponSound = Resources.Load<AudioClip>("WeaponSwitching");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        // plays sounds when called via script
        switch (clip)
        {
            // player
            case "Jumping":
                audioSrc.PlayOneShot(jumpSound);
                break;

            // Weapons
            case "WeaponSwitching":
                audioSrc.PlayOneShot(switchWeaponSound);
                break;
            case "SwordAttack":
                audioSrc.PlayOneShot(swordSound);
                break;
            case "WhipAttack":
                audioSrc.PlayOneShot(whipSound);
                break;
            case "GunAttack":
                audioSrc.PlayOneShot(gunSound);
                break;

            // Enviroment
            case "CoinPickup":
                audioSrc.PlayOneShot(coinSound);
                break;
        }
    }
}
