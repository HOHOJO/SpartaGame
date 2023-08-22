using SprtaGame;
public class Dungeon
{
    Item item = new Item("",0,0,0,0,"");
    Player player;
    Town town;
    string Command;
    Random rand;
    public Dungeon()
    {
        rand= new Random();
    }

    public void inDungeon(Player player) // 던전입장
    {
            Console.WriteLine("#############################################################");
            Console.WriteLine("#############################던전############################");
            Console.WriteLine("#############################################################");
            Console.WriteLine("1. 입장하기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 뒤로가기");

            Command = Console.ReadLine();

            switch (Command)
                {
                    case  "1" :
                        showDungeon();
                        
                        break;
                    case "2" :
                        myInven();
                        break;

                    case "3" :
                        town = new Town(player);
                        town.inTown();
                        break;
                } 
    }

    public void showDungeon()
    {
            Console.WriteLine("#############################################################");
            Console.WriteLine("##########################스테이지선택#########################");
            Console.WriteLine("#############################################################");
            Console.WriteLine("1. 1 스테이지");
            Console.WriteLine("2. 2 스테이지");
            Console.WriteLine("3. 3 스테이지");
            Console.WriteLine("4. 뒤로가기");
            Command = Console.ReadLine();

            switch (Command)
                {
                    case  "1" :
                        dungeonStage(5);
                        break;
                    case "2" :
                        dungeonStage(10);
                        break;
                    case "3" :
                        dungeonStage(15);
                        break;
                    case "4" :
                        inDungeon(player);
                        break;
                } 
    }

    public void dungeonStage(int stagePoint)
    {
        int attack_point = 0;
        if(stagePoint>=player.Defense)
        {
            Console.WriteLine("위험 권장 방어력이 낮습니다. 권장방어력{0}  플레이어방어력{1}", stagePoint, player.Defense);
            attack_point = rand.Next(1,10);
            if(attack_point<7)
            {
                Console.WriteLine("#############################################################");
                Console.WriteLine("던전 실패!");
                Console.WriteLine("체력이 감소합니다.");
                Console.WriteLine("{0} -> {1}", player.Health, player.Health/2);
                Console.WriteLine("#############################################################");
                player.Health/=2;
            }
        }
        else if(player.Health<35)
        {
            Console.WriteLine("위험 체력이 낮습니다. 플레이어체력{0}", player.Health);
            Console.WriteLine("1. 던전입구로");
            Console.WriteLine("2. 아이템사용");
            Command = Console.ReadLine();
        }
        else
        {
            int cap = player.Defense - stagePoint;
            int min = 20-cap;
            int max = 35-cap;
            attack_point = rand.Next(min,max);
        }

        switch (stagePoint)
        {

        }
    }

    public void myInven()
    {
         string E ="";
        int [] key = new int[20];
        Dictionary<int, string> N_sort = new Dictionary<int, string>();
        int num = 0;
        List<int> invenkey = player.getInvenKey();
        int[] invenvalue = player.getInvenValue();
        ItemCode itemCode;

        Console.WriteLine("#############################################################");
        Console.WriteLine("############################인벤토리###########################");
        Console.WriteLine($"{"번호",-5}|{"이름",-30}|{"공격력",10}|{"방어력",10}|{"능력",10}|{"수량",5}|{"설명",-60}");
        foreach(int i in invenkey) // 인벤토리 정렬
        {
            key[num] = i;
            itemCode = player.inventory.item.itemMap[i];
            N_sort.Add(i,itemCode.name);
            num ++;
        }

        var items = from pair in N_sort orderby pair.Value ascending select pair;
        foreach(KeyValuePair<int, string> pair in items)

        num =0;
        foreach(KeyValuePair<int, string> pair in items)
        {

            itemCode = player.inventory.item.itemMap[pair.Key];
            if(itemCode.get)
            {
                E+="[E]";
            }
            Console.WriteLine("{0,-5}|{1,-30}|{2,5}|{3,5}|{4,5}|{5,5}||{6,-60}", num, itemCode.name, itemCode.damage, itemCode.defense, itemCode.health, invenvalue[num], itemCode.info);
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
                    inDungeon(player);
                    break;
                }
    }
}