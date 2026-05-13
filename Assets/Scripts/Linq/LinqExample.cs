using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using Sirenix.OdinInspector;
public class LinqExample : MonoBehaviour
{
    public List<int>  numbers = new List<int>() {2 , 13 , 5 , 1 , 8 , 10 , 4 };

    void Start()
    {
        var numberHigherThan5 = numbers.Where(x => x > 5).ToList();

        var has4 = numbers.FirstOrDefault(ctx => ctx == 100);

        numbers.ForEach(ctx => Debug.Log(ctx));
        /*
        foreach(var number in numberHigherThan5)
        {
            Debug.Log(number);
        }
        */
    }

    
    void Update()
    {
        
    }
    [Button]
    public void TestFoD()
    {
        int has4 = numbers.FirstOrDefault(ctx => ctx == 100);
        print(has4);
    }

    [Button]
    public void TestAny()
    {
        bool isTrue = numbers.Any(ctx => ctx >= 10);
        print(isTrue);
    }
    [Button]
    public void TestOrderBy()
    {
        numbers = numbers.OrderBy(ctx => ctx).ToList(); //ordenar de manera ascendente
    }
    [Button]
    public void TestOrderByDescending()
    {
        numbers = numbers.OrderByDescending(ctx => ctx).ToList(); //ordenar de manera Descendente
    }

    public struct Enemy
    {
        public string EnemyName;
        public int EnemyCost;
        public Enemy(string enemyName, int enemyCost)
        {
            EnemyName = enemyName;
            EnemyCost = enemyCost;
        }
    }
    [Button]
    public void TestSelect()
    {
        List<Enemy> list = new List<Enemy>();
        list.Add(new Enemy("Manolo" , 4));
        list.Add(new Enemy("Arturo", 3));
        list.Add(new Enemy("Rigoberto", 2));
        list.Add(new Enemy("Sonoro", 1));

        var resultName = list.Select(ctx => ctx.EnemyName).ToList();
        //var resultCost = list.Select(ctx =>ctx.EnemyCost).ToList();
        resultName.ForEach(ctx =>Debug.Log(ctx));
        //resultCost.ForEach(ctx =>Debug.Log(ctx));
    }
    [Button]
    public void TestTake()
    {
        var takeTest = numbers.Take(2).ToList(); // toma los 3 primeros elementos de mi lista
        takeTest.ForEach(ctx => Debug.Log(ctx));
    }
    [Button]
    public void TestSkip()
    {
        var takeTest = numbers.Skip(1).ToList(); // toma los 3 primeros elementos de mi lista
        takeTest.ForEach(ctx => Debug.Log(ctx));
    }

    public enum Type
    {
        None,
        Fire,
        Water,
        Earth
    }

    public struct Ability
    {
        public string AbilityName;
        public Type AbilityType;

        public Ability(string abilityName , Type abilityType)
        {
            AbilityName = abilityName;
            AbilityType = abilityType;
        }
    }
    [Button]
    public void TestGroupBy()
    {
        List<Ability> abilitys = new();
        abilitys.Add(new Ability("Shuriken",Type.Earth));
        abilitys.Add(new Ability("Bamboo", Type.Earth));

        abilitys.Add(new Ability("Waterball", Type.Water));
        abilitys.Add(new Ability("BubblePistol", Type.Water));

        abilitys.Add(new Ability("FireWhip", Type.Fire));
        abilitys.Add(new Ability("FireMoth", Type.Fire));

        var groupAbilitys = abilitys.GroupBy(key => key.AbilityType);

        Dictionary<Type, List<string>> dic = groupAbilitys.ToDictionary(group => group.Key, group => group.Select(ability => ability.AbilityName).ToList());

        Dictionary<Type, List<Ability>> dic2 = groupAbilitys.ToDictionary(group => group.Key, group => group.Select(ability => ability).ToList());
    }
    [Button]
    //public List<int> numbers = new List<int>() { 2, 13, 5, 8, 10, 4 };245"2""4""5"
    public void ChainLinq()
    {
       var result = numbers.Where(x => x != 1).OrderByDescending(x => x).Take(3).Select(x => x).ToString().ToList();
    }
}
