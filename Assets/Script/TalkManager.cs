using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> protraitData;

    public Sprite[] protraitArr;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        protraitData = new Dictionary<int, Sprite>();
        GenerateData();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void GenerateData()
    {
        // Talk Data
        // Npc Jang_T : 1000, Npc Kim_T : 2000
        talkData.Add(1000, new string[] { "�� ���� �����ϰ� ������ ������� ���� �����Ե� ���� ����Ʈ�� �ٰž�. \n�� ���ǿ��� ����Ʈ�� �޼� �� ������ ���� �����㰡���� �ٰ�!!:0"});

        talkData.Add(2000, new string[] { "�ȳ��ϼ���. ������ ����ġ�� ������ ������ �Դϴ�.:0"});

        // Quest Talk
        talkData.Add(10 + 1000, new string[] {"�ȳ�! �츮 ���� �°� ȯ���մϴ�. 5���� �湮���༭ ������.:0", "���� �ΰ������������� ���� �强���̶���ؿ�. \n" +
            "�츮���� �ΰ����ɰ� �������� ������ ������ �����ϰ� �ֽ��ϴ�.:0", "�ƹ����� ��ǻ�Ϳ� ������ �Ǿ��ְ���?:0", "4������� �˸��� ������� Ű������ ���� �������� �׷� ������ ����ǰ� �־� \n" +
            "Ư���ϰ� �츮�������� ����, ����, �����α��� ������ �ϰ� �ְ�:0", "�н��� �ǽ��� ����� ������ ����ǰ��־�! \n���߿� ���� 1�г� ���α׷����� ����ġ�� �־� !!:0",
            "�� ���� �����ϰ� ������ ������� ���� �����Ե� ���� ����Ʈ�� �ٰž�. \n�� ���ǿ��� ����Ʈ�� �޼� �� ������ ���� �����㰡���� �ٰ�!!:0"});

        talkData.Add(20 + 2000, new string[] { "�ȳ��ϼ���. ������ ����ġ�� ������ ������ �Դϴ�.:0", "�������� ����ó������ �� ������ ������ ������ ������ ������ ����ġ�� �־��.\n���� ���� ������ Ǯ�����.:0"});



        // Protrait Data
        // 0: Noraml
        protraitData.Add(1000 + 0, protraitArr[0]);
        protraitData.Add(2000 + 0, protraitArr[1]);




    }

    public string GetTalk(int id, int talkIndex)
    {
        if(!talkData.ContainsKey(id)) // �ش� ����Ʈ ���� ���� �� ��簡 ���� ��
        {
            if(!talkData.ContainsKey(id - id % 10))
            {
                if (talkIndex == talkData[id - id % 100].Length)
                {
                    return null;
                }
                else
                {
                    return talkData[id - id % 100][talkIndex];
                }
            }
            else
            {
                // ����Ʈ �� ó�� ��縶�� ���� ��.
                // �⺻ ��縦 ������ �´�.
                if (talkIndex == talkData[id - id % 10].Length)
                {
                    return null;
                }
                else
                {
                    return talkData[id - id % 10][talkIndex];
                }
            }
        }
        if(talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }

    public Sprite GetPortrait(int id, int protraitIndex)
    {
        return protraitData[id + protraitIndex];
    }
}
