using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class TurnChange : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public void TurnChanger()
    {
        _animator.SetTrigger("Image");
    }
}
