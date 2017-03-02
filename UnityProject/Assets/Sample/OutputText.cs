using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public sealed class OutputText : MonoBehaviour, Brainfuck.IStdStream
{
    [SerializeField] private Text m_InputText;

    private Text m_OutputText;
    private KemonoFriendsLang.Compiler m_Compiler;
    private Brainfuck.Program m_Program;

    private void Awake()
    {
        m_OutputText = GetComponent<Text>();
        m_OutputText.text = string.Empty;
        m_Compiler = new KemonoFriendsLang.Compiler();
    }

    private void Start()
    {
        m_Program = new Brainfuck.Program(m_InputText.text,m_Compiler);
        m_Program.Run(this);
    }

    public byte In()
    {
        return 0;   // つかわないだろうと踏んで…
    }
    public void Out(byte value)
    {
        m_OutputText.text += m_Compiler.なにこれなにこれ(value);
    }
}