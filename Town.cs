class Town
{
    Shop shop;
    Dungeon dungeon;
    string Command;
    Player player;
    public Town(Player player)
    {
         this.player=player;
         shop= new Shop();
         dungeon = new Dungeon();
    }

    public void inTown()
    {
            Console.WriteLine("#############################################################");
            Console.WriteLine("#############################마을############################");
            Console.WriteLine("#############################################################");
            Console.WriteLine("1. 상점");
            Console.WriteLine("2. 던전");
            Console.WriteLine("3. 내정보");
            Console.WriteLine("4. 게임 종료");
    }


}