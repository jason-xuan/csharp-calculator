namespace calaulator_core.scanner
{
    /// <summary>
    /// 整数
    /// </summary>
    public class Num : Token
    {
        private readonly int value;
        public Num(int value) : base(Tag.NUM)
        {
            this.value = value;
        }
        public double Value
        {
            get
            {
                return value;
            }
        }
        public override string ToString()
        {
            return value.ToString();
        }
    }

}
