using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;

    Dictionary<int, QuestData> questList;
    // Start is called before the first frame update
    void Awake()
    {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void GenerateData()
    {
        questList.Add(10, new QuestData("장성국 선생님한테 퀘스트 받기", new int[] {1000}));

        questList.Add(20, new QuestData("김정태 선생님께 퀘스트 받기", new int[] {2000}));

        questList.Add(30, new QuestData("박하예린 선생님께 퀘스트 받기", new int[] {3000}));

        questList.Add(40, new QuestData("박하예린 선생님 퀘스트 클리어하기", new int[] {3000}));

        questList.Add(50, new QuestData("신재경 선생님께 퀘스트 받기", new int[] { 4000 }));

        questList.Add(60, new QuestData("김효영 선생님께 퀘스트 받기", new int[] { 5000 }));

        questList.Add(70, new QuestData("김효영 선생님 퀘스트 클리어하기", new int[] { 5000 }));

        questList.Add(80, new QuestData("퀘스트 클리어", new int[] { 0 }));
    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        if(id == questList[questId].npcId[questActionIndex])
        {
            questActionIndex++;
        }

        if(questActionIndex == questList[questId].npcId.Length)
        {
            NextQuest();
        }

        return questList[questId].questName;
    }

    public string CheckQuest()
    {
        // Quest Name
        return questList[questId].questName;
    }

    public void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;

        // Park_T Quest
        if(questId == 40)
        {
            SceneManager.LoadScene("FindDFIMG");
        }
    }
}
