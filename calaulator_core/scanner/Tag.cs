namespace calaulator_core.scanner
{
    /// <summary>
    /// 显示列出的Tag都是多于一个字符的，一个字符的Tocken的Tag就是它自己
    /// </summary>
    public enum Tag : int
    {
        EQ = 256,       // ==
        GE,             // >=
        LE,             // <=
        NE,             // !=
        NUM,            // int
        REAL,           // double
        SIN,            // sin
        COS,            // cos
        TAN,            // tan
        ID,             // variable
        TRUE,           // 1
        FALSE,          // 0
        BASIC,
        START,          // control
        END             // control
    }
}
