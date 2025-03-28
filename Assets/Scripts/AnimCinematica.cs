using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnimCinematica : MonoBehaviour
{
    public Animator anim;
    private int currentAnim = 0;

    public AnimationClip[] animations;

    public AudioSource pageTurn;
    private bool Play = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentAnim = (currentAnim + 1);
            Play = true;
            anim.Play(animations[currentAnim].name);
        }
        if (currentAnim > 3)
        {
            Play = false;
        }
        if (Play) {
            pageTurn.Play();
            Play = false;
        }
    }
}
