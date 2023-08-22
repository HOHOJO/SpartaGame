namespace SprtaGame
{
    // 시작 클래스
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
// 입력을 받아 시작한다.
        public void GameStart(){
            string Command = Console.ReadLine();
                switch (Command)
                {
                    case  "1" : // 게임시작
                        town.inTown();
                        break;

                    case "2" :
//미구현
                        break;

                    case "3" : // 프로그램 종료
                    Environment.Exit(0);
                        break;
                }    
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {//게임을 시작하는 객체를 만들고 시작
            startGame start = new startGame();
            start.GameStart();
        }
    }
}