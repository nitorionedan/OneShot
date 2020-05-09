using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EggdogFactory : MonoBehaviour
{
    [SerializeField] private GameObject eggdogObj;
    [SerializeField] private GameObject videoPlayerObj;
    private Dictionary<int, Vector2> createTimeList;
    private VideoPlayer videoPlayer;
    private int startFrameCount;
    readonly Vector2 boundMax = new Vector2(2.27f, 6.3f);
    readonly Vector2 boundMin = new Vector2(-2.27f, -4.43f);

    private void Start()
    {
    }

    private void Awake()
    {
        startFrameCount = Time.frameCount;
        createTimeList = new Dictionary<int, Vector2>();
        videoPlayer = videoPlayerObj.GetComponent<VideoPlayer>();
        videoPlayer.Play();

        // DEBUG: skip
        //videoPlayer.frame = 1730;

        CreateEggList();
    }

    void Update()
    {
        //Debug.Log("current FCount: " + (Time.frameCount - startFrameCount + 1));
        Debug.Log(videoPlayer.GetComponent<VideoPlayer>().frame);

        int removeKey = -1;

        foreach (KeyValuePair<int, Vector2> i in createTimeList)
        {
            if (i.Key == videoPlayer.frame)
            {
                GameObject eggdogChild = Instantiate(eggdogObj, new Vector3(i.Value.x, i.Value.y, 0f), Quaternion.identity);

                // 回転させたい・・・
                //eggdogChild.transform.rotation.x = 0f;

                removeKey = i.Key;
                break;
            }
        }

        createTimeList.Remove(removeKey);

        if (videoPlayer.isPlaying == false)
        {
            videoPlayer.Play();
            CreateEggList();
        }
    }

    void CreateEggList() {
        createTimeList.Clear();

        // 入れたい情報（タイミング、位置、動き、大きさ）
        // part A1
        createTimeList.Add(60, new Vector2(0, 0));
        createTimeList.Add(225, new Vector2(-2.19f, 0.24f));
        createTimeList.Add(235, new Vector2(2.19f, 0.24f));

        createTimeList.Add(245, new Vector2(-1.37f, -2.84f));
        createTimeList.Add(250, new Vector2(0, -1.85f));
        createTimeList.Add(255, new Vector2(1.43f, -1f));

        createTimeList.Add(320, new Vector2(-1.46f, 3.17f));
        createTimeList.Add(325, new Vector2(0, 4.66f));
        createTimeList.Add(330, new Vector2(1.77f, 5.6f));

        createTimeList.Add(390, new Vector2(0, -2.9f));
        createTimeList.Add(395, new Vector2(0, 1.5f));
        createTimeList.Add(400, new Vector2(0, 5.46f));

        createTimeList.Add(470, new Vector2(0, -2.9f));
        createTimeList.Add(490, new Vector2(0, 1.5f));
        createTimeList.Add(510, new Vector2(0, 5.46f));

        // part A2
        createTimeList.Add(553, new Vector2(-1.52f, -0.44f));
        createTimeList.Add(569, new Vector2(0.45f, -0.44f));
        createTimeList.Add(584, new Vector2(-2.42f, -0.44f));
        createTimeList.Add(605, new Vector2(0.12f, -0.9f));
        createTimeList.Add(621, new Vector2(-1f, -0.9f));
        createTimeList.Add(622, new Vector2(-1.55f, 0.9f));
        createTimeList.Add(623, new Vector2(-1.99f, 2.46f));
        createTimeList.Add(624, new Vector2(-2.6f, 3.75f));

        createTimeList.Add(662, new Vector2(2.12f, -0.19f));
        createTimeList.Add(663, new Vector2(1.19f, 0.07f));
        createTimeList.Add(664, new Vector2(-0.13f, 0.53f));
        createTimeList.Add(665, new Vector2(-1.16f, 0.91f));
        createTimeList.Add(666, new Vector2(-2.02f, 1.21f));

        createTimeList.Add(830, new Vector2(0f, 0.82f));

        // part B1
        createTimeList.Add(850, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(870, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(890, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(910, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(930, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(950, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(970, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(990, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));

        createTimeList.Add(1000, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(1010, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(1020, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(1030, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(1040, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(1050, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(1060, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(1070, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(1080, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(1090, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(1100, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(1110, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        createTimeList.Add(1120, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));

        // part B2
        createTimeList.Add(1160, new Vector2(-2.09f, 0.86f));
        createTimeList.Add(1161, new Vector2(-1.49f, 0.86f));
        createTimeList.Add(1162, new Vector2(-0.7f, 0.86f));
        createTimeList.Add(1163, new Vector2(0, 0.86f));
        createTimeList.Add(1164, new Vector2(0.86f, 0.86f));
        createTimeList.Add(1165, new Vector2(1.86f, 0.86f));
        createTimeList.Add(1166, new Vector2(1.92f, 0.86f));
        createTimeList.Add(1167, new Vector2(0, 5.67f));
        createTimeList.Add(1168, new Vector2(0, 4.04f));
        createTimeList.Add(1169, new Vector2(0, 2.86f));
        createTimeList.Add(1170, new Vector2(0, -0.72f));
        createTimeList.Add(1171, new Vector2(0, -2.02f));
        createTimeList.Add(1172, new Vector2(0, -3.53f));

        createTimeList.Add(1232, new Vector2(-1.14f, 4.11f));
        createTimeList.Add(1272, new Vector2(-0.19f, 0.17f));

        createTimeList.Add(1289, new Vector2(1.12f, -0.62f));
        createTimeList.Add(1291, new Vector2(-0.29f, 1.28f));
        createTimeList.Add(1293, new Vector2(0.58f, 0.63f));
        createTimeList.Add(1295, new Vector2(-0.62f, -0.93f));

        // before part C1
        createTimeList.Add(1390, new Vector2(2.27f, 3.3f));
        createTimeList.Add(1408, new Vector2(0.21f, 4.49f));
        createTimeList.Add(1424, new Vector2(-1.63f, 1.44f));
        createTimeList.Add(1425, new Vector2(0.93f, -1.58f));
        createTimeList.Add(1426, new Vector2(0.93f, 0.34f));
        createTimeList.Add(1427, new Vector2(1.2f, 1.77f));
        createTimeList.Add(1428, new Vector2(1.2f, 3.78f));
        createTimeList.Add(1429, new Vector2(1.45f, 5.39f));

        // part C1
        createTimeList.Add(1478, new Vector2(1.8f, 0.48f));
        createTimeList.Add(1490, new Vector2(-1.98f, 1.33f));
        createTimeList.Add(1484, new Vector2(1.2f, 5.77f));
        createTimeList.Add(1508, new Vector2(-2.02f, -0.87f));
        createTimeList.Add(1514, new Vector2(-1.88f, 5.17f));

        createTimeList.Add(1572, new Vector2(1.76f, -1.65f));
        createTimeList.Add(1577, new Vector2(0.31f, -1.22f));
        createTimeList.Add(1582, new Vector2(-1.67f, -0.94f));

        createTimeList.Add(1653, new Vector2(-1.67f, 3.02f));
        createTimeList.Add(1658, new Vector2(-1.67f, 4.05f));
        createTimeList.Add(1663, new Vector2(-1.67f, 4.89f));

        // ズームするとき顔面にたくさん入れる
        createTimeList.Add(1697, new Vector2(0.44f, 2.94f));
        createTimeList.Add(1699, new Vector2(0.44f, 1.73f));
        createTimeList.Add(1701, new Vector2(0.83f, 2.16f));
        createTimeList.Add(1703, new Vector2(1.19f, 2.42f));
        createTimeList.Add(1705, new Vector2(1.19f, 3.35f));
        createTimeList.Add(1707, new Vector2(0.84f, 4.88f));
        createTimeList.Add(1709, new Vector2(0.01f, 4.53f));
        createTimeList.Add(1711, new Vector2(-0.5f, 4.26f));
        createTimeList.Add(1713, new Vector2(-1.03f, 3.81f));
        createTimeList.Add(1715, new Vector2(-1.3f, 3.44f));
        createTimeList.Add(1717, new Vector2(-0.73f, 1.96f));
        createTimeList.Add(1719, new Vector2(0.35f, 0.9f));
        createTimeList.Add(1721, new Vector2(1.86f, 1.14f));
        createTimeList.Add(1723, new Vector2(2.12f, 1.14f));
        createTimeList.Add(1725, new Vector2(2.12f, 2.35f));
        createTimeList.Add(1727, new Vector2(1.68f, 3.49f));
        createTimeList.Add(1729, new Vector2(1.23f, 3.83f));

        // ダンスカメラを向けた先
        createTimeList.Add(1799, new Vector2(1.23f, 3.83f));
        createTimeList.Add(1804, new Vector2(-1.51f, -1.66f));
        createTimeList.Add(1809, new Vector2(-1.83f, 4.87f));

        createTimeList.Add(1878, new Vector2(1.23f, -2.25f));
        createTimeList.Add(1883, new Vector2(1.23f, 1.38f));
        createTimeList.Add(1888, new Vector2(1.23f, 4.89f));

        // くねくね先（３連）
        createTimeList.Add(1950, new Vector2(-1.67f, -2.25f));
        createTimeList.Add(1955, new Vector2(-1.67f, 1.38f));
        createTimeList.Add(1960, new Vector2(-1.67f, 4.89f));

        // ビームで大量生成（ランダム大量生成）
        for (int i = 0; i < 10; i++) {
            createTimeList.Add(2030 + i * 2, new Vector2(Random.Range(boundMin.x, boundMax.x), Random.Range(boundMin.y, boundMax.y)));
        }
    }
}
