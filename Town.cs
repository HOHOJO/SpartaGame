using System.Globalization;
using System.Reflection;
using SprtaGame;

public class Town
{
    static Shop shop;
    static Dungeon dungeon;
    string Command;
    Item item;
    Player player;
    public Town(Player player)
    {
         this.player=player;
         shop= new Shop();
         dungeon = new Dungeon();
         item = new Item("",0,0,0,0,"");
    }

    public void inTown()
    {
            Console.WriteLine("#############################################################");
            Console.WriteLine("#############################마을############################");
            Console.WriteLine("#############################################################");
            Console.WriteLine("1. 상점");
            Console.WriteLine("2. 던전");
            Console.WriteLine("3. 상태정보");
            Console.WriteLine("4. 인벤토리");
            Console.WriteLine("5. 게임 종료");
            Command = Console.ReadLine();

            switch (Command)
                {
                    case  "1" :
                        GoShop();
                        break;

                    case "2" :
                        GoDungeon();
                        break;

                    case "3" :
                        string s = player.getState();
                        myState(s);
                        break;
                    case "4" :
                        myInven();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                } 
    }

    public void GoShop()
    {
        shop.inShop(this.player);
    }

        public void GoDungeon()
    {
        shop.inShop(this.player);
    }

    public void myState(string state)
    {
            string[] s = state.Split(",");
            Console.WriteLine("#############################################################");
            Console.WriteLine("############################상태정보###########################");
            Console.WriteLine("#############################################################");
            Console.WriteLine("Lv. "+s[0]);
            Console.WriteLine("직업. "+s[1]);
            Console.WriteLine("공격력. "+s[2]);
            Console.WriteLine("방어력. "+s[3]);
            Console.WriteLine("체력. "+s[4]);
            Console.WriteLine("Gold. "+s[5]);
            Console.WriteLine("1. 뒤로가기");
            Command = Console.ReadLine();
            switch (Command)
                {
                    case "1" :
                    inTown();
                    break;
                }
    }

    public void myInven()
    {
        string E ="";
        int [] key = new int[20];
        int num = 0;
        List<int> invenkey = player.getInvenKey();
        int[] invenvalue = player.getInvenValue();
        ItemCode itemCode;

        Console.WriteLine("#############################################################");
        Console.WriteLine("############################인벤토리###########################");
        Console.WriteLine($"{"번호",-5}|{"이름",-30}|{"공격력",10}|{"방어력",10}|{"능력",10}|{"수량",5}|{"설명",-60}");
        foreach(int i in invenkey)
        {
            key[num] = i;
            itemCode = player.inventory.item.itemMap[i];
            if(itemCode.get)
            {
                E+="[E]";
            }
            Console.WriteLine("{0,-5}|{1,-30}|{2,5}|{3,5}|{4,5}|{5,5}||{6,-60}", num, itemCode.name, itemCode.damage, itemCode.defense, itemCode.health, invenvalue[num], itemCode.info);
            num ++;
        }
        Console.WriteLine("a. 장착관리");
        Console.WriteLine("b. 정렬하기");
        Console.WriteLine("c. 뒤로가기");
        Command = Console.ReadLine();
        switch (Command)
                {
                    case "a" :
                    int number;
                    Console.WriteLine("장착 관리하기");
                    Command = Console.ReadLine();
                    number = Int32.Parse(Command);
                    itemCode = item.itemMap[key[number]];

                    Console.WriteLine(""+itemCode.name);

                    if(key[key[number]]<=invenkey.Count&&itemCode.health==0)
                    {
                        player.mountItem(key[number]);
                        Console.WriteLine(""+player.inventory.item.itemMap[key[number]].get);
                        Console.WriteLine("장착 완료");
                        myInven();
                    }
                    else
                    {
                            Console.WriteLine("장착불가");
                             myInven();
                    }
                    myInven();
                    break;

                    case "b" :
;
                    break;

                    case "c" :
                    inTown();
                    break;
                }
    }

}