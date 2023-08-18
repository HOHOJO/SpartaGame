namespace SprtaGame
{
    class startGame{
        static Player player = new Player("르탄이");
        Town town = new Town(player);

        public startGame(){
            


            Console.WriteLine("#############################################################");
            Console.WriteLine("#########################르탄이대모험########################");
            Console.WriteLine("#############################################################");
            Console.WriteLine("1. 게임 시작");
            Console.WriteLine("2. 게임 불러오기");
            Console.WriteLine("3. 게임 종료");
            GameStart();
        }

        public void GameStart(){
            bool i = true;
            string Command = Console.ReadLine();
                switch (Command)
                {
                    case  "1" :
                        town.inTown();
                        break;

                    case "2" :

                        break;

                    case "3" :

                        break;
                }    
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            startGame start = new startGame();
            start.GameStart();
        }
    }
}