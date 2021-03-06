﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip jumpSound, swordSound, whipSound, gunSound, coinSound, switchWeaponSound, HitSound, noMoneySound;
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
        HitSound = Resources.Load<AudioClip>("PlayerHitSound");
        noMoneySound = Resources.Load<AudioClip>("NoMoney");

        audioSrc = GetComponent<AudioSource>();
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
            case "PlayerHitSound":
                audioSrc.PlayOneShot(HitSound);
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

            //shop
            case "NoMoney":
                audioSrc.PlayOneShot(noMoneySound);
                break;
        }
    }
}
