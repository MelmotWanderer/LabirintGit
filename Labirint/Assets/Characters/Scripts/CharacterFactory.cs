using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterFactory : MonoBehaviour
{
   public abstract CharacterMover Create(Vector3 position, Level level);
}
