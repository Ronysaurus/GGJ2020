using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip boom, EregirTorreta, HammerMagic, Shot, SwordAttack;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        boom = Resources.Load<AudioClip>("boom");
        EregirTorreta = Resources.Load<AudioClip>("EregirTorreta");
        HammerMagic = Resources.Load<AudioClip>("HammerMagic");
        Shot = Resources.Load<AudioClip>("Shot");
        SwordAttack = Resources.Load<AudioClip>("SwordAttack");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound ( string clip)
    {
        switch (clip)
        {
            case "boom":
                audioSrc.PlayOneShot(boom);
                break;
            case "EregirTorreta":
                audioSrc.PlayOneShot(EregirTorreta);
                break;
            case "HammerMagic":
                audioSrc.PlayOneShot(HammerMagic);
                break;
            case "Shot":
                audioSrc.PlayOneShot(Shot);
                break;
            case "SwordAttack":
                audioSrc.PlayOneShot(SwordAttack);
                break;
        }
    }
}