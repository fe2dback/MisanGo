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

        questList.Add(30, new QuestData("������ ������ ����Ʈ Ŭ�����ϱ�", new int[] { 2000 }));

        questList.Add(40, new QuestData("������ �����԰� ��ȭ�ϱ�", new int[] { 2000 }));

        questList.Add(50, new QuestData("����� �����Բ� ����Ʈ �ޱ�", new int[] { 6000 }));

        questList.Add(60, new QuestData("����� ������ ����Ʈ Ŭ�����ϱ�", new int[] { 6000 }));

        questList.Add(70, new QuestData("����� �����԰� ��ȭ�ϱ�", new int[] { 6000 }));

        questList.Add(80, new QuestData("������ �����Բ� ����Ʈ �ޱ�", new int[] { 7000 }));

        questList.Add(90, new QuestData("������ ������ ����Ʈ Ŭ�����ϱ�", new int[] { 7000 }));

        questList.Add(100, new QuestData("������ �����԰� ��ȭ�ϱ�", new int[] { 7000 }));

        questList.Add(110, new QuestData("��̸� �����Բ� ����Ʈ �ޱ�", new int[] { 8000 }));

        questList.Add(120, new QuestData("��̸� ������ ����Ʈ Ŭ�����ϱ�", new int[] { 8000 }));

        questList.Add(130, new QuestData("��̸� �����԰� ��ȭ�ϱ�", new int[] { 8000 }));

        questList.Add(140, new QuestData("������ �����Բ� ����Ʈ �ޱ�", new int[] { 9000 }));

        questList.Add(150, new QuestData("������ ������ ����Ʈ Ŭ�����ϱ�", new int[] { 9000 }));

        questList.Add(160, new QuestData("������ �����԰� ��ȭ�ϱ�", new int[] { 9000 }));

        questList.Add(170, new QuestData("���Ͽ��� �����Բ� ����Ʈ �ޱ�", new int[] {3000}));

        questList.Add(180, new QuestData("���Ͽ��� ������ ����Ʈ Ŭ�����ϱ�", new int[] {3000}));

        questList.Add(190, new QuestData("���Ͽ��� �����԰� ��ȭ�ϱ�", new int[] { 3000 }));

        questList.Add(200, new QuestData("��ȿ�� �����Բ� ����Ʈ �ޱ�", new int[] { 5000 }));

        questList.Add(210, new QuestData("��ȿ�� ������ ����Ʈ Ŭ�����ϱ�", new int[] { 5000 }));

        questList.Add(220, new QuestData("��ȿ�� �����԰� ��ȭ�ϱ�", new int[] { 5000 }));

        questList.Add(230, new QuestData("����� �����԰� ��ȭ�ϱ�", new int[] { 4000 }));

        questList.Add(240, new QuestData("�强�� �����԰� ��ȭ�ϱ�", new int[] { 1000 }));
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

        // Kim_T Quest
        if(questId == 30)
        {
            SceneManager.LoadScene("MathGameScene");
        }
        else if (questId == 60)
        {
            SceneManager.LoadScene("shooting");
        }
        // Park_T Quest
        else if (questId == 180)
        {
            SceneManager.LoadScene("FindDFIMG");
        }
        else if(questId == 210)
        {
            SceneManager.LoadScene("cardgameScene");
        }
    }
}
