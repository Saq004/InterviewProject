using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PopapBall : MonoBehaviour
{
    [SerializeField] private GameObject _quotImage;
    [SerializeField] private Text _textBall;
    [SerializeField] private Animator _animator;

    private WaitForSeconds _wait;
    private Image _imageBall;

    string[] Quot = new string[]
    {
        "You Got me",
        "I'm a red ball",
        "I'm a shiny red ball who can move around and talk",
        "Ha"
    };

    private void Start()
    {
        _imageBall = _quotImage.GetComponent<Image>();
        _quotImage.SetActive(false);

        _wait = new WaitForSeconds(2);
        StartCoroutine(ShowPastTime());
    }

    public string RandomQuot()
    {
        System.Random random = new System.Random();

        int useQuot = random.Next(Quot.Length);

        string pickQuote = Quot[useQuot];

        return pickQuote;
    }


    IEnumerator ShowPastTime()
    {
        while (true)
        {
            yield return _wait;
            _quotImage.SetActive(true);

            _textBall.text = RandomQuot();

            yield return _wait;

            Animation("Bool", false);

            yield return _wait;
           
            //animationOn
            Animation("Bool", true);

            yield return _wait;
           

        }
    }


    private void Animation(string animName , bool animationBool)
    {
        _animator.SetBool(animName, animationBool);
    }
}
