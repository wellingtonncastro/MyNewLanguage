namespace MyNewLanguage.Models
{
    public class Week
    {
        public int Id { get; set; }
        public int TotalDoneInWeek { get; set; }
        public int TotalWrong { get; set; }
        public int TotalHard { get; set; }
        public int TotalGood { get; set; }
        public int TotalEasy { get; set; }

        public Week(int TotalDoneInWeek, int TotalWrong, int TotalHard, int TotalGood, int totalEasy)
        {
            
            this.TotalDoneInWeek = TotalDoneInWeek;
            this.TotalWrong = TotalWrong;
            this.TotalHard = TotalHard;
            this.TotalGood = TotalGood;
            this.TotalEasy = totalEasy;
        }
    }
}