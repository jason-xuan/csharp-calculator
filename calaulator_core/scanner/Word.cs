using System;

namespace calaulator_core.scanner
{
    /// <summary>
    /// 多于1个字符的Tocken
    /// </summary>
    public class Word : Token
    {
        public string lex = "";
        public static readonly Word
            and, or, eq, ne, le, ge, minus, True, False, sin, cos, tan;
        static Word()
        {
            eq = new Word("==", Tag.EQ);
            ne = new Word("!=", Tag.NE);
            le = new Word("<=", Tag.LE);
            ge = new Word(">=", Tag.GE);
            True = new Word("True", Tag.TRUE);
            False = new Word("False", Tag.FALSE);
            sin  = new Word("sin", Tag.FALSE);
        }
        public Word(string lex, Tag tag) : base(tag)
        {
            this.lex = lex;
        }
        public override string ToString()
        {
            return lex;
        }
    }
}
