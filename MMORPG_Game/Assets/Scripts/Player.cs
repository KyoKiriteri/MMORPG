using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mmorpg
{
    public class Player : MonoBehaviour
    {
        public static Player instance;

        [SerializeField] private int questID;
        [SerializeField] private string questName;
        [SerializeField] private string questDesc;
        [SerializeField] private string questReward;
        [SerializeField] private int questEXP;
        [SerializeField] private bool questClear;

        public int QuestID { get => questID; set => questID = value; }
        public string QuestName { get => questName; set => questName = value; }
        public string QuestDesc { get => questDesc; set => questDesc = value; }
        public string QuestReward { get => questReward; set => questReward = value; }
        public int QuestEXP { get => questEXP; set => questEXP = value; }
        public bool QuestClear { get => questClear; set => questClear = value; }

        private void Awake()
        {
            instance = this;
        }
    }
}