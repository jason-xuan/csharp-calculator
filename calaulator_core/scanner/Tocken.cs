namespace calaulator_core.scanner
{
    /// <summary>
    /// 仅有一个字符的Tocken
    /// </summary>
    public class Token
    {
        public readonly Tag tag;

        public Token(char v)
        {
            tag = (Tag)v;
        }

        public Token(Tag t)
        {
            tag = t;
        }
        public override string ToString()
        {
            if ((int)tag < 256)
            {
                char t = (char)tag;
                return t.ToString();
            }
            return tag.ToString();
        }
    }

}
