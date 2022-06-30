using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomization : CharacterCustomization
{
    private Color _colorPlayer;





    private void Start()
    {
        SwitchColor(_colorPlayer);
    }


    public void SetColor(Color colorPlayer)
    {
        _colorPlayer = colorPlayer;
    }
  
}
