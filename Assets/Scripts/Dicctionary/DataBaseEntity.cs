using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
[CreateAssetMenu(fileName = "DataBaseEntity", menuName = "Scriptable Objects/DataBaseEntity")]
public class DataBaseEntity : SerializedScriptableObject
{
    [FoldoutGroup("References") , PreviewField(150)]
    public GameObject entityPrefab;

    public Dictionary<Rarity, List<BaseEntityData>> dataBaseEntitys = new();
    public BaseEntityData GetRandomEntity(Rarity rarity)
    {
        if(dataBaseEntitys.TryGetValue(rarity, out List<BaseEntityData> entities))
        {
            return entities[Random.Range(0, entities.Count)]; // --> largo de los valores de una clase
        }
        else
        {
            throw new System.Exception("la rareza definida no existe!!!");
        }
    }
    public GameObject InstantiateEntity(Rarity rarity , Vector3 position)
    {
        GameObject obj = Instantiate(entityPrefab);
        
        return null;
    }
}
