using System.Collections.Generic;

namespace MAS.ExcelReport
{
    internal class LeafeValue
    {
        public string Sno { get; set; }
        public int ColumnNumber { get; set; }
        public int MasterRegisterID { get; set; }
        public decimal OpeningBalance { get; set; }
    }
    internal class Level3
    {
        public string MainContent { get; set; }
        public int ColSpan { get; set; }
        public LeafeValue leafVallue { get; set; }

    }
    internal class Level2
    {
        public string MainContent { get; set; }
        public int ColSpan { get; set; }
        public LeafeValue leafVallue { get; set; }
        public ICollection<Level3> level3s { get; set; }
    }
    internal class Level1
    {
        public string MainContent { get; set; }
        public int ColSpan { get; set; }
        public LeafeValue leafVallue { get; set; }
        public ICollection<Level2> level2s { get; set; }
    }
    internal class MASMaterialHeader
    {
        public Level1 level1 { get; set; }
        public int level { get; set; }
        public string Unit { get; set; }

    }
}
