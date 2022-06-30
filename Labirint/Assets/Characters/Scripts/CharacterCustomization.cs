using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterMover))]
[RequireComponent(typeof(MeshRenderer))]
public abstract class CharacterCustomization : MonoBehaviour
{
    protected MeshRenderer _materialCharacter;


    private void Awake()
    {
        _materialCharacter = GetComponent<MeshRenderer>();

    }

    protected void SwitchColor(Color color)
    {
        _materialCharacter.material.color = color;
    }
}
