using System.Collections;
using TMPro;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


namespace mmorpg
{
    [System.Serializable]
    public class Quest
    {
        public int questID;
        public string questName;
        public string questDesc;
        public string questReward;
        public int questEXP;
        public bool questClear;

        public Quest() { }

        public Quest(int questID, string questName, string questDesc, string questReward, int questEXP, bool questClear)
        {
            this.questID = questID;
            this.questName = questName;
            this.questDesc = questDesc;
            this.questReward = questReward;
            this.questEXP = questEXP;
            this.questClear = questClear;
        }

        public IEnumerator LoadQuestDataFromDatabase(string uri, TMP_InputField outputArea)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(uri))
            {
                yield return request.SendWebRequest();

                if (request.error != null)
                {
                    outputArea.text = $"Connecion error: {request.error}";
                }
                else
                {
                    outputArea.text = request.downloadHandler.text;
                }

                string newOutputArea = outputArea.text.Remove(0, 1);
                string newOutputArea2 = newOutputArea.Remove(newOutputArea.Length - 1, 1);

                Quest quest = JsonUtility.FromJson<Quest>(newOutputArea2);

                Player.instance.QuestID = quest.questID;
                Player.instance.QuestName = quest.questName;
                Player.instance.QuestDesc = quest.questDesc;
                Player.instance.QuestReward = quest.questReward;
                Player.instance.QuestEXP = quest.questEXP;
                Player.instance.QuestClear = quest.questClear;
            }
        }

        public IEnumerator SaveQuestDataToDatabase(string uri, TMP_InputField outputArea)
        {
            string questID = $"\"questID\":{this.questID},";
            string questName = $"\"questName\":{this.questName},";
            string questDesc = $"\"questDesc\":{this.questDesc},";
            string questReward = $"\"questReward\":{this.questReward},";
            string questEXP = $"\"questEXP\":{this.questEXP},";
            string questClear = $"\"questClear\":{this.questClear},";

            string questData = "{" + questID + questName +
                questDesc + questReward +
                questEXP + questClear + "}";

            using (UnityWebRequest request = UnityWebRequest.Put(uri, questData))
            {
                request.SetRequestHeader("Content-Type", "application/json");
                yield return request.SendWebRequest();

                if (request.error != null)
                {
                    outputArea.text = $"Connecion error: {request.error}";
                }
                else
                {
                    outputArea.text = request.downloadHandler.text;
                }
            }
        }
    }
