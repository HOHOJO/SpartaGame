namespace SprtaGame
{
    public class ItemCode
    {
       public string name="";
       public int damage=0;
       public int defense=0;
       public int health=0;
       public int gold=0;
       public string info="";
       public bool get = false;

        public ItemCode(string name, int damage, int defense, int health, int gold, string info){
            this.name = name;
            this.damage = damage;
            this.defense = defense;
            this.health = health;
            this.gold = gold;
            this.info = info;
            this.get = false;
        }
    }
}