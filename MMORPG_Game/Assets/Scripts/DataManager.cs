using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

namespace mmorpg
{
    public class DataManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField outputArea;

        public Player player;


        public void GetData()
        {
            outputArea.text = null;
            string uri = "https://localhost:7214/mmorpg";
            Quest quest = new Quest();
            StartCoroutine(quest.LoadQuestDataFromDatabase(uri, outputArea));
        }

        public void PutData()
        {
            outputArea.text = "Loading...";
            string uri = "https://localhost:7214/mmorpg/{id}?QuestID=1";

            Quest quest = new Quest(player.QuestID, player.QuestName, 
                player.QuestDesc, player.QuestReward, 
                player.QuestEXP, player.QuestClear);
            StartCoroutine(quest.SaveQuestDataToDatabase(uri, quest, outputArea));
        }
    }
}