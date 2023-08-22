
public class Player : Character
{
    public string Name { get; set; }
    public int Health { get; set;}

    public int Damage{ get; set; }

    public int Defense{ get; set; }

    public int gold{get; set;}

    public string job{get; set;}

    public int level{get; set;}
    public Inventory inventory;

    public Player(string name)
    {
        inventory = new Inventory();
        Name = name;
        Health = 200;
        Damage = 10;
        Defense = 5;
        gold = 1500;
        job = "전사";
        level = 1;
    }

    public List<int> getInvenKey() // 인벤토리 키전체
    {
        return inventory.Getkey();
    }

    public int[] getInvenValue() // 인벤토리 밸류
    {
        return inventory.getValue();
    }

    public void getItem(int code, int num) // 인벤토리에 아이템 추가
    {
        inventory.getitem(code, num);
    }

    public void useItem(int code) // 아이템 사용
    {
        inventory.useItem(code);
    }

    public void mountItem(int code)// 장비 장착
    {
       int st = inventory.mountitem(code);
        if(inventory.item.itemMap[code].damage>0)
        {
            Damage-=st;
            Damage+=inventory.item.itemMap[code].damage;
        }
        else
        {
            Defense-=st;
            Defense+=inventory.item.itemMap[code].defense;
        }
    }

    public string getState() // 상태 정보 전달
    {
        string N="";
        N+=level.ToString();
        N+=",";
        N+=job;
        N+=",";
        N+=Damage.ToString();
        N+=",";
        N+=Defense.ToString();
        N+=",";
        N+=Health.ToString();
        N+=",";
        N+=gold.ToString();
        return N;
    }
}