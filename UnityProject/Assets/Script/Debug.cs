using UnityEngine;
using System.Collections;

public class Debug : MonoBehaviour
{
    [SerializeField]
    private TextAsset m_text;


    private void Awake()
    {
        var std      = new KemonoFriendsLang.DebugStd();
        var compiler = new KemonoFriendsLang.Compiler();
        var program = new Brainfuck.Program(m_text.text, compiler);
        program.Run(std);
    }
}
