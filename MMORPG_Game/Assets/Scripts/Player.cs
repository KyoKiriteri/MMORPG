using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mmorpg
{
    public class Player : MonoBehaviour
    {
        public static Player instance;

        [SerializeField] private int questID;
        [SerializeField] private int questName;
        [SerializeField] private int questDesc;
        [SerializeField] private int questReward;
        [SerializeField] private int questEXP;
        [SerializeField] private int questClear;

        public int QuestID { get => questID; set => questID = value; }
        public int QuestName { get => questName; set => questName = value; }
        public int QuestDesc { get => questDesc; set => questDesc = value; }
        public int QuestReward { get => questReward; set => questReward = value; }
        public int QuestEXP { get => questEXP; set => questEXP = value; }
        public int QuestClear { get => questClear; set => questClear = value; }

        private void Awake()
        {
            instance = this;
        }
    }
}