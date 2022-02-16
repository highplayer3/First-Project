using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI组件")]
    public Text textLabel;
    
    [Header("文本文件")]
    public TextAsset textFile;

    public int index;
    List<string> textList = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        GetTextFromFile(textFile);
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if (index == textList.Count && Input.GetKeyDown(KeyCode.R))
        //{
        //    textLabel.text = "-_-已经翻到末尾了，不能再翻了@_@";
        //    this.gameObject.GetComponent<Image>().enabled = false;
        //    this.gameObject.GetComponent<Image>().GetComponentInChildren<Text>().enabled = false;
        //    index--;
        //}
        if (index!=textList.Count&&Input.GetKeyDown(KeyCode.R))
        {
            textLabel.text = textList[index];
            index++;
        }
    }
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var LineData=file.text.Split('\n');
        foreach(var line in LineData)
        {
            textList.Add(line);
        }
    }
}
