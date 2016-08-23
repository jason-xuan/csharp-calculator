using System;

namespace calaulator_core.scanner
{
    /// <summary>
    /// 多于1个字符的Tocken
    /// </summary>
    public class Word : Token
    {
        public String lex = "";
        public static readonly Word
            and, or, eq, ne, le, ge, minus, True, False, temp;
        static Word()
        {
            and = new Word("&&", Tag.AND);
            or = new Word("||", Tag.OR);
            eq = new Word("==", Tag.EQ);
            ne = new Word("!=", Tag.NE);
            le = new Word("<=", Tag.LE);
            ge = new Word(">=", Tag.GE);
            minus = new Word("minus", Tag.MINUS);
            True = new Word("True", Tag.TRUE);
            False = new Word("False", Tag.FALSE);
            temp = new Word("t", Tag.TEMP);
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
