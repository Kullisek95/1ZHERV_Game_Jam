using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using Platformer.Mechanics;

public class TokenCounter : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI tokenCounterText;
    public TokenInstance[] tokens;
    public int tokenCount;
    // Update is called once per frame
    void Update()
    {
        void FindAllTokensInScene()
        {
            tokens = UnityEngine.Object.FindObjectsOfType<TokenInstance>();

        }

        if (tokens.Length == 0)
            FindAllTokensInScene();

        tokenCount = 0;

        for (var i = 0; i < tokens.Length; i++)
        {
            if (tokens[i].collected)
            {
                tokenCount++;
            }
        }
        
        if (tokenCount == 6)
        {
            tokenCounterText.text = "Tokens:\nAll tokens collected!";
        }
        else
        {
            tokenCounterText.text = "Tokens:\n" + tokenCount.ToString() + "/6";
        }

    }
}
