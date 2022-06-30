using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyCustomization: CharacterCustomization
{
    private Color _colorPatrol;
    private Color _colorFollowPlayer;


  

    public void SetColors(Color colorPatrol, Color colorFollowPlayer)
    {
        _colorPatrol = colorPatrol;
        _colorFollowPlayer = colorFollowPlayer;

    }


    public void SwitchColorPatrol()
    {

        SwitchColor(_colorPatrol);
    }
    public void SwitchColorFollowingPlayer()
    {
        SwitchColor(_colorFollowPlayer);
        
    }





    
}
