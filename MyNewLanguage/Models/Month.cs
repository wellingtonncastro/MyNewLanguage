namespace MyNewLanguage.Models
{
    public class Month
    {
        public int Id { get; set; }
        public int TotalYear { get; set; }
        public int TotalJanuary { get; set; }
        public int TotalFebruary { get; set; }
        public int TotalMarch { get; set; }
        public int TotalApril { get; set; }
        public int TotalMay { get; set; }
        public int TotalJune { get; set; }
        public int TotalJuly { get; set; }
        public int TotalAugust { get; set; }
        public int TotalSeptember { get; set; }
        public int TotalOctober { get; set; }
        public int TotalNovember { get; set; }
        public int TotalDecember { get; set; }

        public Month(int TotalYear, int TotalJanuary, int TotalFebruary, int TotalMarch, int TotalApril, 
                        int TotalMay, int TotalJune, int TotalJuly, int TotalAugust, int TotalSeptember, int TotalOctober, 
                        int TotalNovember, int TotalDecember )
        {
            
            this.TotalYear = TotalYear;
            this.TotalJanuary = TotalJanuary;
            this.TotalFebruary = TotalFebruary;
            this.TotalMarch = TotalMarch;
            this.TotalApril = TotalApril;
            this.TotalMay = TotalMay;
            this.TotalJune = TotalJune;
            this.TotalJuly = TotalJuly;
            this.TotalAugust = TotalAugust;
            this.TotalSeptember = TotalSeptember;
            this.TotalOctober = TotalOctober;
            this.TotalNovember = TotalNovember;
            this.TotalDecember = TotalDecember;
        }
    }
}