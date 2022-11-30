using UnityEngine;

namespace RimuruDev
{
    [CreateAssetMenu(fileName = "MonsterDataset", menuName = "Cteate MonsterDataset")]
    public sealed class MonsterDataset : ScriptableObject
    {
        [SerializeField] private MonsterData[] monsterData;
        public MonsterData[] GetMonsterData => monsterData;
    }
}