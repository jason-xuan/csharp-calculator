namespace calaulator_core.scanner
{
    /// <summary>
    /// 显示列出的Tag都是多于一个字符的，一个字符的Tocken的Tag就是它自己
    /// </summary>
    public enum Tag : int
    {
        AND = 256,
        BASIC,
        BREAK,
        DO,
        ELSE,
        EQ,
        FALSE,
        GE,
        ID,
        IF,
        INDEX,
        LE,
        MINUS,
        NE,
        NUM,
        OR,
        REAL,
        TEMP,
        TRUE,
        WHILE,
    }
}
