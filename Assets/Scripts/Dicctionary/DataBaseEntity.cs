using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
[CreateAssetMenu(fileName = "DataBaseEntity", menuName = "Scriptable Objects/DataBaseEntity")]
public class DataBaseEntity : SerializedScriptableObject
{
    public Dictionary<Rarity, List<BaseEntity>> dataBaseEntitys = new();
    public BaseEntity GetRandomEntity(Rarity rarity)
    {
        if(dataBaseEntitys.TryGetValue(rarity, out List<BaseEntity> entities))
        {
            return entities[Random.Range(0, entities.Count)]; // --> largo de los valores de una clase
        }
        else
        {
            throw new System.Exception("la rareza definida no existe!!!");
        }
    }
}
