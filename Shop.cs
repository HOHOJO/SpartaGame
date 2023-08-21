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
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 뒤로가기");
            Command = Console.ReadLine();

            switch (Command)
                {
                    case  "1" :
                        Console.WriteLine("물품을 봅니다.");
                        ShowShop();
                        break;

                    case "2" :
                        this.myInven();     
                        break;

                    case "3" :
                        town = new Town(player);
                        town.inTown();
                        break;
                } 

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
                town = new Town(player);
                town.inTown();
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

                    break;

                    case "c" :
                    inShop(player);
                    break;
                }
    }

    
}