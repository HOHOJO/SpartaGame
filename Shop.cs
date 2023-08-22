using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
using System.Text;
using SprtaGame;
public class Shop
{
    Item item = new Item("",0,0,0,0,"");
    public Dictionary<int, int> poket = new Dictionary<int, int>();
    Player player;
    Town town;
     
    string Command;
    public Shop()
    {
        poket.Add(0,20);
        poket.Add(1,5);
        poket.Add(2,1);
        poket.Add(3,1);
        poket.Add(4,1);
        poket.Add(5,1);
        poket.Add(6,1);
    }
    
    public void inShop(Player player)
    {
            this.player=player;
            Console.WriteLine("#############################################################");
            Console.WriteLine("#############################상점############################");
            Console.WriteLine("#############################################################");
            Console.WriteLine("1. 물품보기");
            Console.WriteLine("2. 판매하기");
            Console.WriteLine("3. 인벤토리");
            Console.WriteLine("4. 뒤로가기");
            Command = Console.ReadLine();

            switch (Command)
                {
                    case  "1" :
                        Console.WriteLine("물품을 봅니다.");
                        ShowShop();
                        break;
                    case "2" :
                        shopSell();  
                        break;

                    case "3" :
                        this.myInven();     
                        break;

                    case "4" :
                        town = new Town(player);
                        town.inTown();
                        break;
                } 

    }

    public void shopSell()
    {
        
    }

    public void ShowShop()
    {
        int num =1;
        char spad = ' ';
        ItemCode itemCode;
        Console.WriteLine($"{"번호",-5}|{"이름",-30}|{"공격력",5}|{"방어력",5}|{"능력",5}|{"가격",5}|{"수량",5}|{"설명",-60}");
        foreach( var pair in poket)
        {
           itemCode = item.itemMap[pair.Key];
           int padlen = 50 - Encoding.Default.GetBytes(itemCode.name).Length;
           //Console.WriteLine(num+". "+itemCode.name +"##   "+itemCode.damage+"   ##  "+itemCode.defense+"   ##   "+itemCode.health+"  ##  가격  "+itemCode.gold+"  ##   "+poket[num-1]+"  ##   "+itemCode.info);
           Console.WriteLine("{0,-5}|{1,-30}|{2,5}|{3,5}|{4,5}|{5,5}|{6,5}|{7,-60}", num, itemCode.name, itemCode.damage, itemCode.defense, itemCode.health, itemCode.gold, poket[num-1], itemCode.info);
           //Console.WriteLine($"{num,-5}|{itemCode.name,-25}|{itemCode.damage,10}|{itemCode.defense,10}|{itemCode.health,10}|{itemCode.gold,10}|{poket[num-1],10}|{itemCode.info,5}");
           //Console.WriteLine(num.ToString().PadRight(5,spad)+"|"+itemCode.name.PadRight(30,spad)+""+itemCode.damage.ToString().PadRight(10,spad)+""+itemCode.defense.ToString().PadRight(10,spad));
            //Console.WriteLine("{0} | {1}", num,"".PadRight(padlen)+ itemCode.name);
           num++;
        }
            Console.WriteLine("0 뒤로가기");

            Command = Console.ReadLine();
            int number = Int32.Parse(Command)-1;
            if(number+1 !=0)
            {
                itemCode = item.itemMap[number];
                Console.WriteLine(itemCode.name +"" );
                if(player.gold>=itemCode.gold && poket[number]!=0)
                {
                    poket[number] -= 1;
                    player.getItem(number, 1);
                    Console.WriteLine("구매완료");
                    player.gold-=itemCode.gold;
                    inShop(player);
                }
                else
                {
                    Console.WriteLine("구매불가");
                    inShop(player);
                }
            }
            else
            {
                inShop(player);
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
                    inShop(player);
                    break;
                }
    }
}