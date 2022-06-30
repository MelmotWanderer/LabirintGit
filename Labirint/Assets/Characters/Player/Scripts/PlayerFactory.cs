using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : CharacterFactory
{
    [SerializeField] private GameObject _player;
    [SerializeField] private IndicatorNoiseUI _indicatorNoiseUI;
    [SerializeField] private Color _colorPlayer;
   public override CharacterMover Create(Vector3 position, Level level)
    {
        var player =  Instantiate(_player, position, Quaternion.identity).GetComponent<PlayerMover>();
        player.InitLevel(level);
        player.GetComponent<PlayerCustomization>()?.SetColor(_colorPlayer);
     
        
        return player;
    }
}
