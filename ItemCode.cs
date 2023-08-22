namespace SprtaGame
{
    public class ItemCode // 아이템 코드, 아이템 목록을 만들기 위한 하나의 객체
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