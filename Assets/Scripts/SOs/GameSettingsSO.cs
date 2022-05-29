using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SOs/GameSettingsSO")]
public class GameSettingsSO : ScriptableObject
{
    public int MaxLives = 3;
    public int TimerForAsteroids = 5;
    public int TimerForEnemyShip = 2;
    public int WaitForRespawn = 2;
    public List<ResourceTypes> AsteroidTypes;
}