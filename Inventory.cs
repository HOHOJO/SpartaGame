using SprtaGame;

public class Inventory
{
    public Item item = new Item("",0,0,0,0,"");
    Dictionary<int, int> poket = new Dictionary<int, int>();
    public Inventory(){
        poket.Add(0,10);
        poket.Add(1,3);
    }

    public void getitem(int code, int num)
    {
        if(poket.ContainsKey(code))
        {
            poket[code]+=num;
        }
        else
        {
            poket.Add(code, num);
        }
    }

    public List<int> Getkey()
    {
        List<int> keys = poket.Keys.ToList();
        return keys;
    }

    public int[]  getValue()
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

    public int useItem(int code)
    {
        if(poket[code]>=1)
        {
            poket[code]-=1;
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public int mountitem(int code)
    {   
        
        if(item.itemMap[code].get)
        {
            item.itemMap[code].get = false;
            return 0;    
        }
        else
        {
            item.itemMap[code].get = true;
            return 1;
        }

    }

}