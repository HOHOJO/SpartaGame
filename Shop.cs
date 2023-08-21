using System.ComponentModel.Design;
using System.Diagnostics.Contracts;
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
        ItemCode itemCode;
        Console.WriteLine("이름                                        공격력  방어력  능력치  가격          설명");
        Console.WriteLine("#############################################################");
        foreach( var pair in poket)
        {
            
            if(pair.Value !=0)
            {
                
                itemCode = item.itemMap[pair.Key];
                if(itemCode.name.Length<20)
                {
                    int input = 20-itemCode.name.Length;
                    string s1 = " ";
                    for(int i=1; i < input ; i++){s1+="- ";}
                Console.WriteLine(num+". "+itemCode.name +s1+"##   "+itemCode.damage+"   ##  "+itemCode.defense+"   ##   "+itemCode.health+"  ##  가격  "+itemCode.gold+"  ##   "+itemCode.info);
                num++;
                }
                else
                {
                Console.WriteLine(num+". "+itemCode.name +"##  "+itemCode.damage+"  ##  "+itemCode.defense+"  ##  "+itemCode.health+"  ##  가격  "+itemCode.gold+"  ##  "+itemCode.info);
                num++;
                }
            }
            else
            {
                itemCode = item.itemMap[pair.Key];
                Console.WriteLine(itemCode.name +"############################################################" );
            }
        }
            Console.WriteLine("0 뒤로가기");

            Command = Console.ReadLine();
            int number = Int32.Parse(Command)-1;
            if(number+1 !=0)
            {
                itemCode = item.itemMap[number];
                Console.WriteLine(itemCode.name +"" );
                if(player.gold>=itemCode.gold&&poket[number]!=0)
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
        Console.WriteLine("\n");
        foreach(int i in invenkey)
        {
            key[num] = i;
            itemCode = player.inventory.item.itemMap[i];
            if(itemCode.get)
            {
                E+="[E]";
            }
            Console.WriteLine(num+". "+itemCode.name +E+"  ||공격력  "+itemCode.damage+"  ||방어력  "+itemCode.defense+"  ||능력  "+itemCode.health+"  ||수량  "+invenvalue[num]+"  ||설명  "+itemCode.info+"  ||  ");
            num ++;
        }
        Console.WriteLine("a. 장착관리");
        Console.WriteLine("b. 뒤로가기");
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
                        if(player.mountItem(key[number])==0)
                        {
                            Console.WriteLine(""+player.inventory.item.itemMap[key[number]].get);
                             Console.WriteLine("장착 해제");
                             myInven();
                        }
                        else
                        {
                            Console.WriteLine(""+player.inventory.item.itemMap[key[number]].get);
                             Console.WriteLine("장착 완료");
                             myInven();
                        }

                    }
                    else
                    {
                            Console.WriteLine("장착불가");
                             myInven();
                    }
                    myInven();
                    break;

                    case "b" :
                    inShop(player);
                    break;
                }
    }

    
}