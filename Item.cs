namespace SprtaGame
{
    class Item : ItemCode{
        string name = "";
        string info ="";
        
        Dictionary<int, ItemCode> itemMap = new Dictionary<int, ItemCode>();

        public Item(string name, int damage, int defense, int health, int gold, string info) : base(name, damage, defense, health, gold, info)
        {
            Itemset();
        }

        public void Itemset(){

            name = "회복물약";
            info = "평범한 회복물약, 체력을 50 회복시킨다.";
            itemMap.Add(0, new ItemCode(name, 0, 0, 50, 50,info ));

            name = "힘 물약";
            info = "힘을 10올린다.(던전에서 나오면 초기화)";
            itemMap.Add(1, new ItemCode(name, 0, 0, 10, 100,info ));
        }                
    }
}