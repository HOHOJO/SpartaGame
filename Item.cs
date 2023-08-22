namespace SprtaGame
{
    public class Item : ItemCode{

        public Dictionary<int, ItemCode> itemMap = new Dictionary<int, ItemCode>();
        
       public string name="";
       public int damage=0;
       public int defense=0;
       public int health=0;
       public int gold=0;
       public string info="";
       public bool get = false;

        public Item(string name, int damage, int defense, int health, int gold, string info) : base(name, damage, defense, health, gold, info)
        {
            Itemset();
        }

        public void Itemset()
        {

            name = "회복물약";
            info = "평범한 회복물약, 체력을 50 회복시킨다.";
            itemMap.Add(0, new ItemCode(name, 0, 0, 50, 50,info ));

            name = "힘물약";
            info = "힘을 10올린다.(던전에서 나오면 초기화)";
            itemMap.Add(1, new ItemCode(name, 0, 0, 10, 100,info ));

            name = "낡은 검";
            info = "낡은 검 금방 부러질것 같다.";
            itemMap.Add(2, new ItemCode(name, 10, 0, 0, 200,info ));

            name = "낡은 방패";
            info = "막기 성능이 의심되는 방패";
            itemMap.Add(3, new ItemCode(name, 0, 10, 0, 100,info ));

            name = "좋은 검";
            info = "검 좋다!";
            itemMap.Add(4, new ItemCode(name, 30, 0, 0, 1000,info ));
            
            name = "좋은 방패";
            info = "좋다! 방패!";
            itemMap.Add(5, new ItemCode(name, 0, 30, 0, 1000,info ));

            name = "스파르탄이 사용했을지도 모른 검";
            info = "과거 스파르탄이 사용했을지도, 아닐니지도";
            itemMap.Add(6, new ItemCode(name, 100, 0, 10, 2000,info ));
        }


    }
}