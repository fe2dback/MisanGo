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
        questList.Add(10, new QuestData("�强�� ���������� ����Ʈ �ޱ�", new int[] {1000}));

        questList.Add(20, new QuestData("������ �����Բ� ����Ʈ �ޱ�", new int[] {2000}));

        questList.Add(30, new QuestData("���Ͽ��� �����Բ� ����Ʈ �ޱ�", new int[] {3000}));

        questList.Add(40, new QuestData("���Ͽ��� ������ ����Ʈ Ŭ�����ϱ�", new int[] {3000}));

        questList.Add(50, new QuestData("����� �����Բ� ����Ʈ �ޱ�", new int[] { 4000 }));

        questList.Add(60, new QuestData("��ȿ�� �����Բ� ����Ʈ �ޱ�", new int[] { 5000 }));

        questList.Add(70, new QuestData("��ȿ�� ������ ����Ʈ Ŭ�����ϱ�", new int[] { 5000 }));

        questList.Add(80, new QuestData("����Ʈ Ŭ����", new int[] { 0 }));
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
