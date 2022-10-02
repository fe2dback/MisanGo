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
        talkData.Add(1000, new string[] { "자 이제 간략하게 설명을 들었으니 이제 선생님들 께서 퀘스트를 줄거야. \n각 교실에서 퀘스트를 달성 후 나에게 오면 입학허가장을 줄게!!:0"});

        talkData.Add(2000, new string[] { "안녕하세요. 수학을 가르치는 김정태 선생님 입니다.:0"});

        // Quest Talk
        talkData.Add(10 + 1000, new string[] {"안녕! 우리 과에 온걸 환영합니다. 5층에 방문해줘서 고마워요.:0", "나는 인공지능콘텐츠과 부장 장성국이라고해요. \n" +
            "우리과는 인공지능과 콘텐츠를 결합한 수업을 진행하고 있습니다.:0", "아무래도 컴퓨터와 연관이 되어있겠지?:0", "4차산업에 알맞은 인재들을 키워내고 각각 수업들은 그런 내용이 진행되고 있어 \n" +
            "특별하게 우리과에서는 수학, 영어, 디자인까지 수업을 하고 있고:0", "학습과 실습이 병행된 수업이 진행되고있어! \n그중에 나는 1학년 프로그래밍을 가르치고 있어 !!:0",
            "자 이제 간략하게 설명을 들었으니 이제 선생님들 께서 퀘스트를 줄거야. \n각 교실에서 퀘스트를 달성 후 나에게 오면 입학허가장을 줄게!!:0"});

        talkData.Add(20 + 2000, new string[] { "안녕하세요. 수학을 가르치는 김정태 선생님 입니다.:0", "선생님은 정보처리수학 등 정보와 수학을 결합한 형태의 과목을 가르치고 있어요.\n내가 내는 문제를 풀어보세요.:0"});



        // Protrait Data
        // 0: Noraml
        protraitData.Add(1000 + 0, protraitArr[0]);
        protraitData.Add(2000 + 0, protraitArr[1]);




    }

    public string GetTalk(int id, int talkIndex)
    {
        if(!talkData.ContainsKey(id)) // 해당 퀘스트 진행 순서 중 대사가 없을 때
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
                // 퀘스트 맨 처음 대사마저 없을 때.
                // 기본 대사를 가지고 온다.
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
