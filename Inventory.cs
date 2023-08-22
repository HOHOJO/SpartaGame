using SprtaGame;

public class Inventory
{
    public Item item = new Item("",0,0,0,0,""); // 아이템 목록
    public Dictionary<int, int> poket = new Dictionary<int, int>(); // 인벤토리 목록

    bool weapon=false; // 무기장착 상태
    int weaponCode; // 무기코드
    bool armor=false;// 방어구장착 상태
    int armorCode;// 방어구코드

    public Inventory(){ // 인벤토리 생성자, 기본 아이템 지급
        poket.Add(0,10);
        poket.Add(1,3);
    }

    public void getitem(int code, int num) // 아이템 획득
    {
        if(poket.ContainsKey(code)) // 인벤토리에 있는거면 수량만 추가
        {
            poket[code]+=num;
        }
        else // 없는거면 목록도 추가
        {
            poket.Add(code, num);
        }
    }

    public List<int> Getkey() // 인벤토리 목록 키
    {
        List<int> keys = poket.Keys.ToList();
        return keys;
    }

    public int[]  getValue()// 인벤토리 목록 값
    {
        List<int> key = Getkey();
        int[] value = new int [20];
        int j = 0;
        foreach(int i in key)
        {
            value[j] = poket[i];
            j++;
        }

        return value;
    }

    public void useItem(int code) // 아이템 사용
    {
            poket[code]-=1;
    }

    public int mountitem(int code) //장비 장착
    {   
        int st =0;
        if(weapon||armor) // 아이템이 장착이 되있나.
        {
            if(item.itemMap[code].damage>0)// 무기인가 방어구인가
            {
                st = item.itemMap[weaponCode].damage;
                item.itemMap[weaponCode].get = false; //기본 장비 해제
                item.itemMap[code].get = true; // 새로운 장비 장착
                weaponCode = code; // 코드 저장
                weapon = true; // 무기상태 장착으로
                return st; // 데미지 변경
            }
            else
            {
                st=item.itemMap[code].defense;
                item.itemMap[armorCode].get = false;
                item.itemMap[code].get = true;
                armorCode = code;
                armor = true;
                return st;
            } 
        }
        else // 아무것도 장착 안되어 있을시
        {
            if(item.itemMap[code].damage>0)
            {
                item.itemMap[code].get = true;
                weaponCode = code;
                weapon = true;
            }
            else
            {
                item.itemMap[code].get = true;
                armorCode = code;
                armor = true;
            }
             return st;
        }

    }

}