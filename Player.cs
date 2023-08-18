
public class Player : Character
{
    public string Name { get; set; }
    public int Health { get; set;}

    public int Damage{ get; set; }

    public int Defense{ get; set; }

    public int gold{get; set;}

    public string job{get; set;}

    public int level{get; set;}

    public Player(string name){
        Inventory inventory = new Inventory();
        Name = name;
        Health = 200;
        Damage = 10;
        Defense = 10;
        gold = 1000;
        job = "전사";
        level = 1;
    }
}