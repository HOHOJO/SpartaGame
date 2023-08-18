using System.Collections;
using SprtaGame;

class Inventory
{
    Item item = new Item("",0,0,0,0,"");
    Dictionary<int, int> poket = new Dictionary<int, int>();
    public Inventory(){
        poket.Add(0,10);
        poket.Add(1,3);
    }

    public void getitem(int code, int num)
    {
        poket.Add(code, num);
    }

    public List<int> Getkey()
    {
        List<int> keys = poket.Keys.ToList();
        return keys;
    }

}