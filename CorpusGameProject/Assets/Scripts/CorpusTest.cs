using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CorpusTest : MonoBehaviour
{
    [SerializeField] private string _targetPhrase;
    [SerializeField] private List<string> _testPhrases = new List<string>();
    [SerializeField] private GameObject _textParent;
    private TextMeshProUGUI[] _textBoxes;
    private string _keyWord = "happy";
    private List<string> _keyWordPhrases = new List<string>();
    private Dictionary<int, List<string>> _testDictionary = new Dictionary<int, List<string>>();

    private void Start()
    {
        

        _textBoxes = _textParent.GetComponentsInChildren<TextMeshProUGUI>();

        Debug.Log(_textBoxes.Length);

        GetCorpusPhrases();

        Debug.Log(_keyWordPhrases.Count);

        InitializeDisplayedPhrases();
    }

    private void GetCorpusPhrases()
    {
        foreach (string phrase in _testPhrases)
        {
            if (_keyWordPhrases.Count >= _textBoxes.Length - 1)
            {
                break;
            }

            if (!phrase.Contains(_keyWord))
                {
                    continue;
                }

            _keyWordPhrases.Add(phrase);
        }
    }

    private void InitializeDisplayedPhrases()
    {
        _textBoxes[0].text = _targetPhrase;

        for (int i = 1; i < _textBoxes.Length; i++)
        {
            _textBoxes[i].text = _keyWordPhrases[i - 1];
        }
    }
}
