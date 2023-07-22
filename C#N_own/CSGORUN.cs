using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_N_own
{
    public class CSGORUN
    {
        public class Data
        {
            public class WorkingModules
            {
                public bool jackpot { get; set; }
                public bool battlepass { get; set; }
                public bool freebet { get; set; }
                public bool adventCalendar { get; set; }
                public bool skinssale { get; set; }
            }
            public class SystemMessage
            {
                public string ru { get; set; }
                public string en { get; set; }
            }
            public class PaymentMethod
            {
                public int id { get; set; }
                public string name { get; set; }
                public string label { get; set; }
                public string titleRu { get; set; }
                public string titleEn { get; set; }
                public string type { get; set; }
                public bool isActive { get; set; }
                public int order { get; set; }
                public int category { get; set; }
                public string img { get; set; }
                public double minAmount { get; set; }
                public int currency { get; set; }
                public int? resaleWithdrawsCount { get; set; }
                public int? resaleDepositsCount { get; set; }
                public string region { get; set; }
                public bool notInRussia { get; set; }
                public DateTime createdAt { get; set; }
                public DateTime updatedAt { get; set; }
            }
            public class Lottery
            {
                public DateTime raffleAt { get; set; }
                public int lifetime { get; set; }
            }

            public class Game
            {
                public class Statistic
                {
                    public int count { get; set; }
                    public string totalDeposit { get; set; }
                    public int totalItems { get; set; }
                }
                public class History
                {
                    public int id { get; set; }
                    public double crash { get; set; }
                }
                public class Bet
                {
                    public class Deposit
                    {
                        public class Item
                        {
                            public int id { get; set; }
                            public int itemId { get; set; }
                            public string name { get; set; }
                            public int colorId { get; set; }
                            public int gameId { get; set; }
                            public int reservedId { get; set; }
                        }
                        public double amount { get; set; }
                        public List<Item> items { get; set; }
                    }
                    public class Withdraw
                    {
                        public double? amount { get; set; }
                        public List<object> items { get; set; }
                    }
                    public class User
                    {
                        public int id { get; set; }
                        public string steamId { get; set; }
                        public string name { get; set; }
                        public string avatar { get; set; }
                        public bool blm { get; set; }
                        public double totalDeposits { get; set; }
                        public double totalWithdraws { get; set; }
                    }
                    public int id { get; set; }
                    public int gameId { get; set; }
                    public int status { get; set; }
                    public double coefficientAuto { get; set; }
                    public double? coefficient { get; set; }
                    public Deposit deposit { get; set; }
                    public Withdraw withdraw { get; set; }
                    public User user { get; set; }
                    public int likes { get; set; }
                    public bool showLike { get; set; }
                }
                public double delta { get; set; }
                public int status { get; set; }
                public Statistic statistic { get; set; }
                public List<History> history { get; set; }
                public object crash { get; set; }
                public object bet { get; set; }
                public string hash { get; set; }
                public List<Bet> bets { get; set; }
            }
            public object user { get; set; }
            public List<object> notifications { get; set; }
            public Game game { get; set; }
            public double currency { get; set; }
            public double goodaslyCurrency { get; set; }
            public SystemMessage systemMessage { get; set; }
            public string centrifugeToken { get; set; }
            public List<object> youtubers { get; set; }
            public object transaction { get; set; }
            public Lottery lottery { get; set; }
            public bool totalizatorEventsExist { get; set; }
            public bool isGiver { get; set; }
            public List<PaymentMethod> paymentMethods { get; set; }
            public string online { get; set; }
            public WorkingModules workingModules { get; set; }

        }
        public bool success { get; set; }
        public DateTime date { get; set; }
        public Data data { get; set; }
    }
}
