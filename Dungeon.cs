using SprtaGame;
public class Dungeon // 던전 클래스
{
    Item item = new Item("",0,0,0,0,"");
    Player player;
    Town town;
    string Command;
    Random rand;
    public Dungeon() // 생성자, 랜덤 요소만 생성한다
    {
        rand= new Random();
    }

    public void inDungeon(Player player) // 던전입장
    {
            this.player=player;
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
                        showDungeon(); // 던전스테이지 보기
                        
                        break;
                    case "2" :
                        myInven(); // 인벤토리 확인
                        break;

                    case "3" : // 돌아기기
                        town = new Town(player);
                        town.inTown();
                        break;
                } 
    }

    public void showDungeon() // 스테이지
    {
            Console.WriteLine("#############################################################");
            Console.WriteLine("##########################스테이지선택#########################");
            Console.WriteLine("#############################################################");
            Console.WriteLine("1. 1 스테이지");
            Console.WriteLine("2. 2 스테이지");
            Console.WriteLine("3. 3 스테이지");
            Console.WriteLine("4. 휴식하기");
            Console.WriteLine("4. 뒤로가기");
            Command = Console.ReadLine();
            // 스테이지별 권장 방어도가 있다.
            switch (Command)
                {
                    case "1" :
                        dungeonStage(5);
                        break;
                    case "2" :
                        dungeonStage(10);
                        break;
                    case "3" :
                        dungeonStage(15);
                        break;
                    case "4" :
                        restDungeon(); // 휴식하기
                        break;
                    case "5" :
                        inDungeon(player);
                        break;
                } 
    }

    public void restDungeon() // 휴식처
    {
            Console.WriteLine("#############################################################");
            Console.WriteLine("###############200G 지불시 휴식이 가능합니다#################");
            Console.WriteLine("#############################################################");
            Console.WriteLine("1. 휴식하기");
            Console.WriteLine("2. 뒤로가기");
            Command = Console.ReadLine();

            switch (Command)
                {
                    case "1" :
                        if(player.gold>=200) // 돈이 있어야 휴식이 가능하다.
                        {
                            Console.WriteLine("휴식중.....");
                            Thread.Sleep(3000);
                            player.gold-=200;
                            player.Health=200;
                            Console.WriteLine("휴식완료!");
                            restDungeon();
                        }
                        else
                        {
                            Console.WriteLine("돈이없다");
                            restDungeon();
                        }
                        break;
                    case "2" :
                        inDungeon(player);
                        break;
                } 
    }

    public void dungeonStage(int stagePoint) // 던전 입장
    {
        int attack_point = 0;
        if(stagePoint>player.Defense) // 권장 방어구보다 낮으면 다시 플레이어에게 물어본다.
        {
            Console.WriteLine("위험 권장 방어력이 낮습니다. 권장방어력{0}  플레이어방어력{1}", stagePoint, player.Defense);
            Console.WriteLine("1. 던전입구로");
            Console.WriteLine("2. 계속");
            Command = Console.ReadLine();

            if(Int32.Parse(Command)==1) 
            {
                inDungeon(player);
            }
            attack_point = rand.Next(1,10);
            if(attack_point<7) // 40퍼 확률로 실패한다.
            {
                Console.WriteLine("#############################################################");
                Console.WriteLine("던전 실패!");
                Console.WriteLine("체력이 감소합니다.");
                Console.WriteLine("{0} -> {1}", player.Health, player.Health/2);
                Console.WriteLine("#############################################################");
                player.Health/=2;
            }
        }
        else if(player.Health<35) // 체력이 낮으면 경고를 한다.
        {
            Console.WriteLine("위험 체력이 낮습니다. 플레이어체력{0}", player.Health);
            Console.WriteLine("1. 던전입구로");
            Console.WriteLine("2. 아이템사용");
            Command = Console.ReadLine();
            switch(Command)
            {
                case "1":
                inDungeon(player);
                break;
                case "2":
                myInven();
                break;
            }
        }
        else
        { // 방어력에 따라 체력감소 캡이 달라진다.
            int cap = player.Defense - stagePoint;
            int min = 20-cap;
            int max = 35-cap;
            attack_point = rand.Next(min,max);
            player.Health-=attack_point;
        }
        Thread.Sleep(1000);
        Console.WriteLine("던전 클리어!");
        Thread.Sleep(1000);
        player.EX+=1; // 던전 클리어시 경험치 획득
        switch (stagePoint) // 던전 난이도에 따른 보상 추가
        {
            case 5:
            Console.WriteLine("보상획득");
            Console.WriteLine("1000G !");
            player.gold+=1000;
            Thread.Sleep(1000);
            if(player.Levelup()==1) // 레벨확인
            {
                Console.WriteLine("레벨업 했습니다! {0} => {1}", player.level-1,player.level);
                Thread.Sleep(1000);
            }
            inDungeon(player);
            break;

            case 10:
            Console.WriteLine("보상획득");
            Console.WriteLine("1700G !");
            player.gold+=1700;
            Thread.Sleep(1000);
            if(player.Levelup()==1)
            {
                Console.WriteLine("레벨업 했습니다! {0} => {1}", player.level-1,player.level);
                Thread.Sleep(1000);
            }
            inDungeon(player);
            break;

            case 15:
            Console.WriteLine("보상획득");
            Console.WriteLine("2000G !");
            player.gold+=2000;
            Thread.Sleep(1000);
            if(player.Levelup()==1)
            {
                Console.WriteLine("레벨업 했습니다! {0} => {1}", player.level-1,player.level);
                Thread.Sleep(1000);
            }
            inDungeon(player);
            break;
        }
    }
    public void myInven() // 인벤토리 메서드
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
            if(itemCode.get)// 장착한 아이템이면 E 표시가 붙는다.
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
        //인벤토리 기능
        Console.WriteLine("a. 장착관리");
        Console.WriteLine("b. 아이템사용");
        Console.WriteLine("c. 정렬하기");
        Console.WriteLine("d. 뒤로가기");
        Command = Console.ReadLine();
        switch (Command)
                {
                    case "a" : // 무기와 방패를 장착한다.
                    int number;
                    Console.WriteLine("장착 관리하기(장착할 아이템 선택)");
                    Command = Console.ReadLine();
                    number = Int32.Parse(Command);
                    itemCode = item.itemMap[key[number]];

                    Console.WriteLine(""+itemCode.name);

                    if(key[key[number]]<=invenkey.Count&&itemCode.health==0) // 존재하는 아이템이고 장착가능한 아이템이어야 한다.
                    {
                        player.mountItem(key[number]); // 플레이어 장착 메서드 소환
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

                    case "b" : // 아이템 사용
                    Console.WriteLine("사용할 아이템 선택");
                    Command = Console.ReadLine();
                    number = Int32.Parse(Command);
                    itemCode = item.itemMap[key[number]];

                    if(itemCode.health!=0&&player.inventory.poket[key[number]]>0)// 사용가능한 아이템이고, 수량이 있어야한다.
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

                    case "c" : // 다시 정렬
                    items = from pair in N_sort orderby pair.Value.Length descending select pair;
                    myInven();
                    break;

                    case "d" :// 돌아가기
                    inDungeon(player);
                    break;
                }
    }
}