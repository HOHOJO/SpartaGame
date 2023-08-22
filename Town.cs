using System.Globalization;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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
        dungeon.inDungeon(this.player);
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
        string E ="";// 장착확인 
        int [] key = new int[20]; // 정렬을 위한 배열
        Dictionary<int, string> N_sort = new Dictionary<int, string>(); // 정령을 위한 딕셔너리
        int num = 0;
        List<int> invenkey = player.getInvenKey(); // 인벤토리키
        int[] invenvalue = player.getInvenValue(); // 인벤토리 밸류
        ItemCode itemCode;

        Console.WriteLine("#############################################################");
        Console.WriteLine("############################인벤토리###########################");
        Console.WriteLine($"{"번호",-5}|{"이름",-30}|{"공격력",10}|{"방어력",10}|{"능력",10}|{"수량",5}|{"설명",-60}");

        foreach(int i in invenkey) // 인벤토리 정렬을 위한 사전준비
        {
            itemCode = player.inventory.item.itemMap[i];
            N_sort.Add(i,itemCode.name);
        }

        //Linq를 이용한 딕셔너리 정렬
        var items = from pair in N_sort orderby pair.Value.Length descending select pair; // 내림차순 정렬
        //var items = N_sort.OrderByDescending(x => x.Value);

        //딕셔너리를 활용해서 인벤토리 표시
        foreach(KeyValuePair<int, string> pair in items)
        {
            key[num] = pair.Key;
            itemCode = player.inventory.item.itemMap[pair.Key];
            if(itemCode.get)
            {
                E+="[E]";
            }
            else
            {
                E="";
            }
            Console.WriteLine("{0,-5}|{1}{2,-30}|{3,5}|{4,5}|{5,5}|{6,5}||{7,-60}", num, itemCode.name, E, itemCode.damage, itemCode.defense, itemCode.health, invenvalue[num], itemCode.info);
            num ++;
        }

        Console.WriteLine("a. 장착관리");
        Console.WriteLine("b. 아이템사용");
        Console.WriteLine("c. 정렬하기");
        Console.WriteLine("d. 뒤로가기");
        Command = Console.ReadLine();
        switch (Command)
                {
                    case "a" :
                    int number;
                    Console.WriteLine("장착 관리하기(장착할 아이템 선택)");
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
                    Console.WriteLine("사용할 아이템 선택");
                    Command = Console.ReadLine();
                    number = Int32.Parse(Command);
                    itemCode = item.itemMap[key[number]];

                    if(itemCode.health!=0&&player.inventory.poket[key[number]]>0)
                    {
                        switch(itemCode.name)
                        {
                            case "회복물약":
                            player.Health+=itemCode.health;
                            if(player.Health>200)
                            {
                                player.Health = 200;
                            }
                            Console.WriteLine("회복 아이템 사용 완료");
                            player.useItem(key[number]);
                            break;

                            case "힘물약":
                            player.Damage+=itemCode.health;
                            Console.WriteLine("힘 아이템 사용 완료");
                            player.useItem(key[number]);
                            break;
                        }
                    }
                    else
                    {
                             Console.WriteLine("사용불가");
                             myInven();
                    }
                    break;

                    case "c" :

                    break;

                    case "d" :
                    inTown();
                    break;
                }
    }

}