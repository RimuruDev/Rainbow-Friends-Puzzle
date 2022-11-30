using UnityEngine;

namespace RimuruDev
{
    [CreateAssetMenu(fileName = "Monster_", menuName = "Cteate MonsterData Element")]
    public sealed class MonsterData : ScriptableObject
    {
        [SerializeField] private GameObject monsterPrefab;
        [SerializeField] private Sprite monsterSprite;

        public GameObject MonsterPrefab { get => monsterPrefab; set => monsterPrefab = value; }
        public Sprite MonsterSprite { get => monsterSprite; set => monsterSprite = value; }
    }
}