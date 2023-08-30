namespace SprtaGame
{
    public class Item{ 

        public Dictionary<int, ItemCode> itemMap = new Dictionary<int, ItemCode>(); // 아이템 목록 키는 int 내용은 itemCode로 딕셔너리 하나로 관리가 가능하다.
        
       public string name="";
       public string info="";

        public Item()// 생성자, 아이템 목록 생성
        {
            Itemset();
        }

        public void Itemset()
        {

            name = "회복물약";
            info = "평범한 회복물약, 체력을 50 회복시킨다.";
            itemMap.Add(0, new ItemCode(name, 0, 0, 50, 50,info )); // 키는 간단하게 코드로, 값은 아이템코드 객체로하여 호출할때 키값으로 편하게 가져온다.

            name = "힘물약";
            info = "힘을 10올린다.(던전에서 나오면 초기화)";
            itemMap.Add(1, new ItemCode(name, 0, 0, 10, 100,info ));

            name = "낡은검";
            info = "낡은 검 금방 부러질것 같다.";
            itemMap.Add(2, new ItemCode(name, 10, 0, 0, 200,info ));

            name = "낡은방패";
            info = "막기 성능이 의심되는 방패";
            itemMap.Add(3, new ItemCode(name, 0, 10, 0, 100,info ));

            name = "아주좋은검";
            info = "검 좋다!";
            itemMap.Add(4, new ItemCode(name, 30, 0, 0, 1000,info ));
            
            name = "아마도좋은방패";
            info = "좋다! 방패!";
            itemMap.Add(5, new ItemCode(name, 0, 30, 0, 1000,info ));

            name = "스파르탄이 사용했을지도 모른 검";
            info = "과거 스파르탄이 사용했을지도, 아닐니지도";
            itemMap.Add(6, new ItemCode(name, 100, 0, 10, 2000,info ));
        }


    }
}