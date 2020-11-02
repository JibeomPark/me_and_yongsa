using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    public GameObject playerTalkPanel, NPCTalkPanel;
    public Text playerTalkText, NPCTalkText, after1000Year;
    public Image firstBackground, secondBackground, thirdBackGround;
    public AudioSource BGM;
    bool isPlayerTalk = false;
    int nextScript = 1000, stringIndex = 0;
    Color afterTextColor, firstBackgroundColor;
    bool isAfterDone = false;
    bool isTalking = true, isWait = false, heroNeverdie = false;
    float timer;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void Start()
    {
        NPCTalkPanel.SetActive(true);
        afterTextColor = after1000Year.color;
        firstBackgroundColor = firstBackground.color;
    }
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "먼 옛날부터 세상을 지켜온 한 존재가 있었다...", "그는 때로는 용사의 성검이, 때로는 대마법사의 지팡이가 되어\n무수히 많은 적을 물리치며 세계의 평화를 위해 싸웠다...", "수 천년의 전쟁 끝에 세상의 모든 악이 잠들고...", "비로소 그는 자유를 얻게 되었다.." });
        talkData.Add(1001, new string[] { "어이, 신", "성검 어서오고.", "왜 아침부터 죽상이야?", "마왕이 쳐들어와서 화나게 하잖아 ㅋㅋ", "마왕퇴치작전 하나 꽃아줄까?", "좋지 ㅋㅋ", "그래서 작전명이 뭐야?", "신세계 프로젝트.\n그래서 말인데 니가 마왕좀 처리해줘야겠다.","?", "야, 천사. 진행시켜", "??" });
        talkData.Add(1002, new string[] { "....님", "....", ".....님!", ".........", "성검님!!!", "이병 김성검!", "네?", "아닙닏.. 아, 뭐야... 아더놈 핏줄이잖아.", "네. 성검님이 곧 깨어나신다는 신탁을 받아\n 기다리고 있었습니다.", "게임 끝나면 신 고의트롤으로 꼭 리폿해라", "네?", "아냐... 그래 아더놈 핏줄이면 나쁘진 않겠지.\n 너, 내 용사 후보가 되라", "성검님! 저는 용사가 아니...", "네, 다음 용사후보"});
        talkData.Add(1003, new string[] { " 아더 왕의 후예, '메딱이'를 얻었다!", "이후 성검은 메딱이를 짝사랑해 쫓아다니는 베테랑 용병 '김그브'\n마왕을 무찌르기 위해 엘프숲에서 파견된 궁수 '최레골'", "이상하지만 능력만은 확실한 마법사 '스트레인지'를 용사 후보로 선택한다.\n(추후 업데이트 예정)"});
        StartCoroutine("ShowNextTalk");
    }

    public string GetTalk(int id, int index)
    {
        return talkData[id][index];
    }

    // Update is called once per frame
    void Update()
    {
        if (nextScript == 1004)
            LOADING.changeGameScene("MainScene");
        if (nextScript == 1003)
        {
            isPlayerTalk = false;
            NPCTalkPanel.transform.GetChild(2).gameObject.SetActive(false);
            StartCoroutine("ShowNextTalk");
        }
        NPCTalkPanel.transform.GetChild(2).gameObject.SetActive(false);
        if (nextScript == 1002 && !isTalking)
            if (isWait)
                StartCoroutine("ShowNextTalk");

        if (nextScript == 1002)
        {
            if (!BGM.isPlaying && !heroNeverdie)
            {
                BGM.clip = Resources.Load("talkScript/mercy") as AudioClip;
                BGM.Play();
                heroNeverdie = true;
            }

            if (stringIndex == 5)
            {
                thirdBackGround.gameObject.SetActive(true);
                firstBackground.gameObject.SetActive(false);
            }
            if (stringIndex % 2 == 1)
            {
                isPlayerTalk = true;
                NPCTalkPanel.transform.GetChild(2).gameObject.SetActive(false);
            }
            else
            {
                isPlayerTalk = false;
                NPCTalkPanel.transform.GetChild(2).gameObject.SetActive(true);
            }
        }
        if(nextScript != 1001)
            NPCTalkPanel.transform.GetChild(1).gameObject.SetActive(false);
        if (nextScript == 1001 && stringIndex % 2 == 0)
            isPlayerTalk = true;
        else if (nextScript == 1001 && stringIndex % 2 == 1)
        {
            NPCTalkPanel.transform.GetChild(1).gameObject.SetActive(true);
            isPlayerTalk = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (!isAfterDone && isTalking)
                stringIndex++;
            else
            {
                if (!isTalking)
                {
                    after1000Year.gameObject.SetActive(false);
                    isTalking = true;
                    gameObject.GetComponent<talkManager>().firstBackground.gameObject.SetActive(false);
                    gameObject.GetComponent<talkManager>().secondBackground.gameObject.SetActive(true);
                }
                else
                    stringIndex++;
            }

        }
        if (stringIndex >= talkData[nextScript].Length)
        {
            NPCTalkPanel.SetActive(false);
            playerTalkPanel.SetActive(false);
            nextScript++;
            if (nextScript == 1002)
            {
                BGM.clip = Resources.Load("talkScript/Punch") as AudioClip;
                BGM.Play();

                firstBackground.gameObject.SetActive(true);
                secondBackground.gameObject.SetActive(false);
                StartCoroutine(timeWait(1.0f));
            }
            StopCoroutine("ShowNextTalk");
            isTalking = false;
            stringIndex = 0;
            if (nextScript == 1001 && !isAfterDone)
            {
                isTalking = false;
                after1000Year.gameObject.SetActive(true);
                StopCoroutine("ShowNextTalk");
                StartCoroutine(FadeInText(0.1f));
            }
        }
    }
    IEnumerator FadeInText(float a)
    {
        afterTextColor.a = 0;
        while (true)
        {
            afterTextColor.a += a;
            after1000Year.color = afterTextColor;
            if (afterTextColor.a >= 10)
            {
                StartCoroutine("ShowNextTalk");
                isTalking = true;
                isAfterDone = true;
                after1000Year.gameObject.SetActive(false);
                secondBackground.gameObject.SetActive(true);
                break;
            }
            yield return null;
        }
    }
    IEnumerator FadeInOutBlack(Image nextBackground)
    {
        Color secondBackgroundColor = secondBackground.color;
        float a = 0.1f;
        firstBackgroundColor.a = 0;
        secondBackgroundColor.a = 0;
        while (true)
        {
            firstBackgroundColor.a += a;
            secondBackgroundColor.a -= a;
            firstBackground.color = firstBackgroundColor;
            secondBackground.color = secondBackgroundColor;
            if (firstBackgroundColor.a >= 10)
            {
                StartCoroutine("ShowNextTalk");
                isTalking = true;
                break;

                //                a = -0.1f;
            }
            if (firstBackgroundColor.a <= 0.2)
            {
                StartCoroutine("ShowNextTalk");
                isTalking = true;
                break;

            }
            yield return null;
        }
        firstBackground.gameObject.SetActive(false);
        nextBackground.gameObject.SetActive(true);

    }
    IEnumerator ShowNextTalk()
    {
        isTalking = true;
        while (true)
        {
            if (isPlayerTalk)
            {
                NPCTalkPanel.SetActive(false);
                playerTalkPanel.SetActive(true);
                playerTalkText.text = GetTalk(nextScript, stringIndex);
            }
            else
            {
                NPCTalkPanel.SetActive(true);
                playerTalkPanel.SetActive(false);
                NPCTalkText.text = GetTalk(nextScript, stringIndex);
            }
            yield return null;
        }
    }
    IEnumerator timeWait(float time)
    {
        yield return new WaitForSeconds(time);
        isWait = true;
    }
}

