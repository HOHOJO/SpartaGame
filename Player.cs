
public class Player : Character // 플레이어, 캐릭터를 상속받는다.
{
    public string Name { get; set; }
    public int Health { get; set;}

    public int Damage{ get; set; }

    public int Defense{ get; set; }

    public int gold{get; set;}

    public string job{get; set;}

    public int level{get; set;}
    public int EX{get; set;}
    public Inventory inventory;

    public Player(string name) // 플레이어 생성자, 기본 스탯
    {
        inventory = new Inventory();
        Name = name;
        Health = 200;
        Damage = 10;
        Defense = 5;
        gold = 1500;
        job = "전사";
        level = 1;
        EX=0;
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
        if(inventory.item.itemMap[code].damage>0)// 반환 받은 값에 따라 스탯 변경
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

    public int Levelup() // 던전 클리어 횟수에 따라 레벨업
    {
        switch(EX)
        {
            case 1:
            level =2;
            Damage+=1;
            Defense+=1;
            return 1;
            case 3:
            level =3;
            Damage+=1;
            Defense+=1;
            return 1;
            case 6:
            level =4;
            Damage+=1;
            Defense+=1;
            return 1;
            case 10:
            level =5;
            Damage+=1;
            Defense+=1;
            return 1;
            default:
            return 0;
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