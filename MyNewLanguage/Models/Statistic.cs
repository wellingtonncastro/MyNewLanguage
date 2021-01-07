namespace MyNewLanguage.Models
{
    public class Statistic
    {
        public int Id { get; set; }

        public int TotalDoneInWeek { get; set; }
        public int TotalWrongWeek { get; set; }
        public int TotalHardWeek { get; set; }
        public int TotalGoodWeek { get; set; }
        public int TotalEasyWeek { get; set; }
        
        
        public int TotalWrongJanuary { get; set; }
        public int TotalHardJanuary { get; set; }
        public int TotalGoodJanuary { get; set; }
        public int TotalEasyJanuary { get; set; }
        
        public int TotalWrongFebruary { get; set; }
        public int TotalHardFebruary { get; set; }
        public int TotalGoodFebruary { get; set; }
        public int TotalEasyFebruary { get; set; }

        public int TotalWrongMarch { get; set; }
        public int TotalHardMarch { get; set; }
        public int TotalGoodMarch { get; set; }
        public int TotalEasyMarch { get; set; }

        public int TotalWrongApril { get; set; }
        public int TotalHardApril { get; set; }
        public int TotalGoodApril { get; set; }
        public int TotalEasyApril { get; set; }

        public int TotalWrongMay { get; set; }
        public int TotalHardMay { get; set; }
        public int TotalGoodMay { get; set; }
        public int TotalEasyMay { get; set; }

        public int TotalWrongJune { get; set; }
        public int TotalHardJune { get; set; }
        public int TotalGoodJune { get; set; }
        public int TotalEasyJune { get; set; }

        public int TotalWrongJuly { get; set; }
        public int TotalHardJuly { get; set; }
        public int TotalGoodJuly { get; set; }
        public int TotalEasyJuly { get; set; }

        public int TotalWrongAugust { get; set; }
        public int TotalHardAugust { get; set; }
        public int TotalGoodAugust { get; set; }
        public int TotalEasyAugust { get; set; }

        public int TotalWrongSeptember { get; set; }
        public int TotalHardSeptember { get; set; }
        public int TotalGoodSeptember { get; set; }
        public int TotalEasySeptember { get; set; }

        public int TotalWrongOctober { get; set; }
        public int TotalHardOctober { get; set; }
        public int TotalGoodOctober { get; set; }
        public int TotalEasyOctober { get; set; }

        public int TotalWrongNovember { get; set; }
        public int TotalHardNovember { get; set; }
        public int TotalGoodNovember { get; set; }
        public int TotalEasyNovember { get; set; }

        public int TotalWrongDecember { get; set; }
        public int TotalHardDecember { get; set; }
        public int TotalGoodDecember { get; set; }
        public int TotalEasyDecember { get; set; }

        
        public Deck Deck { get; set; }
        public int DeckId { get; set; }
        
        public Statistic(int TotalDoneInWeek,int TotalWrongWeek, int TotalHardWeek, int TotalGoodWeek,int TotalEasyWeek,
                            int TotalWrongJanuary, int TotalHardJanuary,int TotalGoodJanuary, int TotalEasyJanuary, int TotalWrongFebruary,
                            int TotalHardFebruary, int TotalGoodFebruary, int TotalEasyFebruary,int TotalWrongMarch, int TotalHardMarch,
                            int TotalGoodMarch, int TotalEasyMarch, int TotalWrongApril, int TotalHardApril, int TotalGoodApril, int TotalEasyApril,
                            int TotalWrongMay, int TotalHardMay, int TotalGoodMay, int TotalEasyMay, int TotalWrongJune, int TotalHardJune,
                            int TotalGoodJune, int TotalEasyJune, int TotalWrongJuly, int TotalHardJuly, int TotalGoodJuly, int TotalEasyJuly,
                            int TotalWrongAugust, int TotalHardAugust, int TotalGoodAugust, int TotalEasyAugust, int TotalWrongSeptember,
                            int TotalHardSeptember, int TotalGoodSeptember, int TotalEasySeptember, int TotalWrongOctober, int TotalHardOctober,
                            int TotalGoodOctober, int TotalEasyOctober, int TotalWrongNovember, int TotalHardNovember, int TotalGoodNovember,
                            int TotalEasyNovember, int TotalWrongDecember, int TotalHardDecember, int TotalGoodDecember, int TotalEasyDecember )
        {
            this.TotalDoneInWeek = TotalDoneInWeek;
            this.TotalWrongWeek = TotalWrongWeek;
            this.TotalHardWeek = TotalHardWeek;
            this.TotalGoodWeek = TotalGoodWeek;
            this.TotalEasyWeek = TotalEasyWeek;

            this.TotalWrongJanuary = TotalWrongJanuary;
            this.TotalHardJanuary = TotalHardJanuary;
            this.TotalGoodJanuary = TotalGoodJanuary;
            this.TotalEasyJanuary = TotalEasyJanuary;

            
            this.TotalWrongFebruary = TotalWrongFebruary;
            this.TotalHardFebruary = TotalHardFebruary;
            this.TotalGoodFebruary = TotalGoodFebruary;
            this.TotalEasyFebruary = TotalEasyFebruary;
            
            this.TotalWrongMarch = TotalWrongMarch;
            this.TotalHardMarch = TotalHardMarch;
            this.TotalGoodMarch = TotalGoodMarch;
            this.TotalEasyMarch = TotalEasyMarch;
            
            this.TotalWrongApril = TotalWrongApril;
            this.TotalHardApril = TotalHardApril;
            this.TotalGoodApril = TotalGoodApril;
            this.TotalEasyApril = TotalEasyApril;
            
            this.TotalWrongMay = TotalWrongMay;
            this.TotalHardMay = TotalHardMay;
            this.TotalGoodMay = TotalGoodMay;
            this.TotalEasyMay = TotalEasyMay;
            
            this.TotalWrongJune = TotalWrongJune;
            this.TotalHardJune = TotalHardJune;
            this.TotalGoodJune = TotalGoodJune;
            this.TotalEasyJune = TotalEasyJune;
            
            this.TotalWrongJuly = TotalWrongJuly;
            this.TotalHardJuly = TotalHardJuly;
            this.TotalGoodJuly = TotalGoodJuly;
            this.TotalEasyJuly = TotalEasyJuly;
            
            this.TotalWrongAugust = TotalWrongAugust;
            this.TotalHardAugust = TotalHardAugust;
            this.TotalGoodAugust = TotalGoodAugust;
            this.TotalEasyAugust = TotalEasyAugust;
            
            this.TotalWrongSeptember = TotalWrongSeptember;
            this.TotalHardSeptember = TotalHardSeptember;
            this.TotalGoodSeptember = TotalGoodSeptember;
            this.TotalEasySeptember = TotalEasySeptember;
            
            this.TotalWrongOctober = TotalWrongOctober;
            this.TotalHardOctober = TotalHardOctober;
            this.TotalGoodOctober = TotalGoodOctober;
            this.TotalEasyOctober = TotalEasyOctober;
            
            this.TotalWrongNovember = TotalWrongNovember;
            this.TotalHardNovember = TotalHardNovember;
            this.TotalGoodNovember = TotalGoodNovember;
            this.TotalEasyNovember = TotalEasyNovember;
            
            this.TotalWrongDecember = TotalWrongDecember;
            this.TotalHardDecember = TotalHardDecember;
            this.TotalGoodDecember = TotalGoodDecember;
            this.TotalEasyDecember = TotalEasyDecember;
           

        }
    }
}