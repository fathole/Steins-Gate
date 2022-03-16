using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour
{
    public GameObject StoryContent;
    public GameObject CharacterContent;
    public Text txtCharacterContent;
    public Scrollbar TextScrollbar;

    private void Start()
    {
        InactiveAllContent();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(GameObject.FindObjectOfType<LoadingSystem>().LoadScene(0));
        }
    }
    public void btnSetting()
    {
        GameObject.FindObjectOfType<Setting>().OpenSetting();
    }
    public void btnStory()
    {
        InactiveAllContent();
        StoryContent.SetActive(true);
    }
    public void btnCharacter()
    {
        InactiveAllContent();
        CharacterContent.SetActive(true);
    }
    private void InactiveAllContent()
    {
        StoryContent.SetActive(false);
        CharacterContent.SetActive(false);
    }

    //character script
    public void btnlabmem001()
    {
        TextScrollbar.value = 1;
        txtCharacterContent.text = " 本作《命運石之門》發生在同為5pb.前作《混沌之腦》的“澀谷崩壞”事件之後，世界一片和平。男主角岡部倫太郎作為東京電機大學一年級學生，在秋葉原的一個不起眼的電器商店上面創建了一個發明研究所（同好會）。本人身高修長，相貌也較為英俊。但是可能是因為長期營養不良而導致身形像電線桿一樣。與桶子形成了鮮明的對比";
        txtCharacterContent.text += "\n 本人是個重度中二患者。整天擔心他的假想敵“機關”會派殺手來取他性命（後來卻出現的真正的機關SERN）。隨時會掏出他的電話，假裝自己在和其他人通話。口頭禪是EL PSY CONGROO(沒有實際意義)。對一切無法解釋的事情都用一句“這是命運石之門的選擇！”來搪塞過去。中二時可以散發出嚇人的氣勢，儘管實際戰鬥力只有0.5。經常嚇到天王寺綯，甚至曾把牧瀨紅莉棲嚇哭。椎名真由理與桶子都對他的中二表現都已經習以為常，而漆原琉華則是他中二方面的弟子。伴隨著劇情的發展，牧瀨紅莉棲也被他傳染了中二病。後來還把中二病傳染了回去。唯一能壓制住他的中二病的只有秋葉留未穗，因為她的中二程度更甚。";
        txtCharacterContent.text += "\n 自稱“狂氣のMadScientist，平日裡身穿白大褂，不修邊幅。在OVA＜聰明睿智的感知計算＞中曾試圖改變形象。推算出來的形象帥氣犀利，看得助手幾乎把持不住。外表看上去粗枝大葉，實際心裡十分看重同伴。在遭遇困難時願意獨自默默承擔全部的苦難，即便犧牲自己也在所不惜。";
        txtCharacterContent.text += "\n 同紅莉棲一樣喜歡喝碳酸飲料Dr.Pepper（樂倍）。";
        txtCharacterContent.text += "\n 本文引自萌娘百科";
    }
    public void btnlabmem002()
    {
        TextScrollbar.value = 1;

        txtCharacterContent.text = " 真由理，私立花淺蔥大學附屬學園二年級，常以「嘟嘟嚕」為口頭禪及打招呼用語，而她的第一人稱為「真由氏」。她保持著不緊不慢的行動和語調，是個一直掛著笑容的天然系角色。身材稍矮，黑色短髮，淡青色眼睛，劉海參差不齊，濃眉大眼。身穿淺藍色連衣裙，淺藍色帽子，裙下穿深藍色超短緊身褲，光腳穿棕色長筒皮靴。";
        txtCharacterContent.text += "\n 岡部從小到大的朋友，自說自話的天然少女，其實是一個很有名偵探資質的傢伙。雖然對於岡部等人討論的複雜理論完全不能理解，但總是抱著只要好玩就行的心態加入，性格十分的樂天派，總是帶著一副慢慢悠悠的口氣與一臉的微笑。";
        txtCharacterContent.text += "\n 另一方面，真由理很不擅長與人爭執，當周圍人關係緊張，馬上會消沉起來。在這種時候雖然想要靠自己來讓氣氛緩和下來，但因為不擅長觀察他人的心情，基本上難以收到好的效果。不過真由理擅長觀察事物，很有當名偵探的天賦（直覺也很準）。相當能吃，即使吃很多還是很瘦。雖然住在池袋，不過每天都去與學校和打工地點很近的未來道具研究所。對岡倫的中二病發言不裝傻也不吐槽，而是直接點頭接受(直接忽視的次數也很多)。";
        txtCharacterContent.text += "\n 雖然真由理也是未來道具研究所的成員，不過對於發明沒有興趣，她的編號為LabMem No.002；另她受到景仰的奶奶的影響，喜歡抬頭仰望星空，經常可以看到她面向夜空伸出手。";
        txtCharacterContent.text += "\n 對岡部來說，真由理是重要的需要保護的人，岡部事實上也用行動證明了這一點。";
        txtCharacterContent.text += "\n 雖然真由理呆呆的，但貌似很有當名偵探的天賦。後因時間跳躍被SERN得知，而陷入死亡命運。經過無數次時間跳躍之後，岡部發現只要處於α世界線，真由理就必然會死。(死法包含：被萌鬱槍殺、被車撞死、被電車碾死、被SERN拐走變成Jellyman、被刀刺殺、被警察槍殺、心臟突然停頓等)";
        txtCharacterContent.text += "\n 最後，在岡部不懈的努力下從α世界線跳到β世界線，脫離死亡命運。";
        txtCharacterContent.text += "\n 本文引自萌娘百科";
    }
    public void btnlabmem003()
    {
        TextScrollbar.value = 1;

        txtCharacterContent.text = " 東京電機大學一年級。兇真高中時代的友人，兩人也在同一所大學上學。因為出色的編程和黑客技術，被岡倫稱為「吾之右臂」（My favourite right arm）的未來道具研究所的主要戰力之一。";
        txtCharacterContent.text += "\n 典型肥宅，常常使用2ch用語，自稱'變態紳士'，以不同的契機讓天真的真由理說些不良語言。是個從2次元到3次元甚至到無機物都能萌上的傢伙。最近萌的對像是在女僕咖啡廳『女僕皇后+喵 2』打工的菲利斯。";
        txtCharacterContent.text += "\n 偶爾出現在句尾的'常考'是'請用常識去考慮'的意思。";
        txtCharacterContent.text += "\n 平時雖然是給人感覺十分輕浮的hentai紳士，但黑客技術是過硬的，關鍵時刻是岡部最穩的隊友，在主線支線故事提及的黑客戰中從未翻過車。主線裡只用一天不到的時間就黑進了SERN，之後閱覽了大量機密文件而不讓SERN察覺（雖然後來SERN注意到了Lab，但漏洞並不出在桶子這裡）。閒來無事時，就算是再危險的組織的伺服器也敢黑著玩，兇真問他能不能黑有“民間CIA”之稱的情報組織StrateFo的伺服器，桶子的回答是“以前黑過了，因此再黑進去應該會很快”，靠著自己的才能甚至在外面打一些十分危險的黑工，有多個隱藏的秘密據點。";
        txtCharacterContent.text += "\n 0線中，不論是岡部陷入頹廢的時候，還是2025年岡部被觀測死亡之後，一直維繫著集體，堅持著時間機器的開發，而且還減肥變帥了，可以說是到達命運石之門世界線最大的幕後功臣。";
        txtCharacterContent.text += "\n 註定會在主線故事（2010年）不遠的未來認識巨乳萌娘阿萬音由季，就是桶子喜歡的類型，並在2017年和她生下鈴羽，在所有已知的世界線中均無例外，號稱最強世界線收束（在《命運石之門0》的部分世界線中，即使是為了接近Lab而整容成由季的椎名篝，也會無可救藥地愛上桶子，可見收束效果之強），永恆的人生贏家。現充爆炸吧！";
        txtCharacterContent.text += "\n 本文引自萌娘百科";
    }
    public void btnlabmem004()
    {
        TextScrollbar.value = 1;

        txtCharacterContent.text = " 11歲時因為各種原因到海外留學，跳級進入美國的維克多・康德利亞大學的天才少女傳說中的天才紳士少女。 18歲即從大學畢業（因為美國的跳級制度，所以實際年齡跟高三學生相當），成為大學的腦科學研究所的研究員。在美國著名的學術雜誌上（Science）刊登論文而聞名。但也因此與父親關係極其不好。廣播劇《哀心迷圖的巴別塔》中，在12歲生日和父親因為時間機器是否能被完成而衝突，甚至到最後刀刃相向；有嚴重的父控情結。想要探索真理的科學家精神與之相乘的後果可以說是β世界線的悲劇根源";
        txtCharacterContent.text += "\n 被父親臨時叫回國，在關於時間旅行的講座上否認時間機器的存在而被岡部倫太郎反駁並反過來以十一種解釋將後者說得無可反駁從而認識，在α世界線中由於發現了岡部等人研製的時間機器並產生了濃厚興趣，其實是被岡部用神級藉口性騷擾之後，產生了不被騷擾就不舒服的理念？成為了岡部的未來機械研究所的成員（LabMem）。平時穿的衣服是臨時回國後上過兩週課的菖蒲院女子學園的製服，自己改造過。但在實驗室裡會以“容易放鬆”為由，穿與岡部一樣的改造版（違規）白大褂。";
        txtCharacterContent.text += "\n 表面上是冷靜而且過分地堅持理論的性格，實際上是個好奇心旺盛喜歡做實驗的女孩，成為研究所成員後顯現出對研究、改造電話烤箱的熱情。而且與年齡相應的受不了煽動，岡部和橋田能簡單的煽動她，岡部因為覺得好玩給她起了各種諢名。";
        txtCharacterContent.text += "\n 沉迷@ch的網蟲，和岡部還不熟的時候就用“栗悟飯和龜波氣功”的網名和岡部（鳳凰院兇真）交談過。因為被看穿了愛泡 @ch經常被岡部和桶子扯各種梗。";
        txtCharacterContent.text += "\n 外表是個美人，纖細的雙腿充滿魅力。平時穿著按照自己的風格所改造的高中製服，雖然說已經不是高中生了。";
        txtCharacterContent.text += "\n 另外，接受了岡部對她與父親的爭執的看法，還耍得岡部團團轉……總而言之就是個典型的傲嬌，而且是一旦關係變好後就用情很深的類型。和岡部類似，雖然表面好強，其實是性格非常好的人。幫助岡部度過了種種難關，兩人間結下了深厚的感情。";
        txtCharacterContent.text += "\n 本文引自萌娘百科";
        txtCharacterContent.text += "\n 愛吃布丁，但並不善於製作料理。著名菜式包含「香菇蘋果派」和「納豆沙拉」。製作過程中，岡部倫太郎：是我，好像邪神的封印已經解開了，如果一小時內沒有聯絡，就告訴我父母「我愛你們」。橋田至：我…吃完這頓飯後便準備要回老家結婚（死亡flag）。";
        txtCharacterContent.text += "\n 自稱還具有“家庭娘”的屬性。幫岡部縫補了破口的衣服。";
        txtCharacterContent.text += "\n 實際上是一個熱衷於妄想的痴女。廣播劇《隱晦曲折的交響曲》中為了給岡部倫太郎準備禮物而苦惱時，其實是因為極度蹭的累，打死都不願意直接問岡部喜歡什麼。突然有了送指環的想法，於是開始妄想自己和岡部在夜晚約會，互相表白並開房……妄想結束後狂吐不止，瘋狂吐槽自己。";
        txtCharacterContent.text += "\n 番外《命運石之門聰明睿智的認知計算》第三話中，看到了烏帕菲利斯給岡部推薦的最後一套衣服，趴在桌子上用手摀著臉嬌喘，疑似腦內高潮。";
    }
    public void btnlabmem005()
    {
        TextScrollbar.value = 1;

        txtCharacterContent.text = " 在α世界線中為了都市傳說的取材而尋找幻之PC「IBN5100」的時候，在秋葉原邂逅了岡倫。她沉默寡言到了與別人的交流全部都要通過手機短信的地步(就算對方在眼前)。精神障礙。而且這個不擅長當面交談的問題即使通過電話也改不了，所以與其說是手機依賴症，不如說是手機短信依賴症更為恰當。";
        txtCharacterContent.text += "\n 在β世界線中為ArkRewrite雜誌供稿，是個很認真工作的記者，和α世界線的混日子形象截然不同。因為和地下世界有聯繫，被曾經的採訪對象桶子請求幫忙尋找椎名篝，因此融入了Lab。在β線的一條分支，與比屋定真帆由記者與採訪對象的關係發展成好友。";
        txtCharacterContent.text += "\n 讓人大跌眼鏡的是，她透過短信傳達過來的感情意外的高昂開朗，與本人的形像有著鮮明的反差。";
        txtCharacterContent.text += "\n 另外，她打字的速度是快到連眼睛都跟不上的程度，親眼目睹過的岡倫將其稱之為「閃光的指壓師」[Shinning Finger（From 高達G武鬥傳）]。";
        txtCharacterContent.text += "\n 真實身份是SERN的底層組織輪迴者的成員，聽從FB（Mr.顯像管）的命令 ，在大部分的α世界線中直接殺害真由理，但可以看出對殺人有猶豫。在岡部了解詳情后，最後原諒了她。";
        txtCharacterContent.text += "\n 本文引自萌娘百科";
    }
    public void btnlabmem006()
    {
        TextScrollbar.value = 1;

        txtCharacterContent.text = " 私立花淺蔥大學附屬學園二年級。秋葉原的柳林神社當家的兒子/女兒。在家裡的神社時穿著巫女服。";
        txtCharacterContent.text += "\n 不喜歡引人注目，也沒有什麼自己的主張，一遇到問題就會臉紅。缺乏自信。經常被岡部要求說暗號'EL PSY CONGROO'，不幸的是每次都會說錯幾個字母。但是在比翼連理的戀人世界線中琉華子結局結尾說對了一次，岡部反而說錯了。一直被真由理拜託穿Cosplay服，雖然每次都以「害羞」為藉口拒絕";
        txtCharacterContent.text += "\n 在岡倫的鼓勵下，不停練習妖刀五月雨。作為柳林神社代代相傳的退魔寶刀，其實是岡倫送給他的仿製刀[980 日元（含稅）]。";
        txtCharacterContent.text += "\n 漆原在不同的世界線中，“擁有”不同的性別。但是都喜歡岡部倫太郎。";
        txtCharacterContent.text += "\n 被D-MAIL改變了過去的世界中，漆原是女孩。 （岡部手測。）在動畫第十八集的時候，岡部再次發送D-mail改變了過去，因而漆原再次變回男孩。";
        txtCharacterContent.text += "\n 本文引自萌娘百科";
    }
    public void btnlabmem007()
    {
        TextScrollbar.value = 1;

        txtCharacterContent.text = " 在秋葉原的大人氣貓耳女僕咖啡廳打工的少女事實上則是咖啡廳的店主，秋葉原萌化的執行者。因為平時就戴著貓耳，使用著動畫中常出現的“喵喵～”的口癖。有著只要注視對方眼睛就知道內心想法的特殊能力（自稱）其實是對他人的心情十分敏感。由於貓耳的萌要素和能力使她在打工的地方贏得了 No.1 的人氣，是那種玩弄男人內心的小惡魔。對岡部倫太郎抱有好感";
        txtCharacterContent.text += "\n 在世界規模的人氣對戰卡片遊戲｢雷net access battles｣上有著一流的技術，大部分的世界線上因為實在太忙而沒去參加正式比賽（在她父親'活過來'的世界線上就一直都有參加）。但在8月21日之後還是參加了，並且第一次參加就取得優勝（因為是戰略性很高的遊戲，所以她擅長的心理洞察的特殊能力能得到充分的發揮）。";
        txtCharacterContent.text += "\n 比岡部還中二的中二病患者，唯一一個十分認真地只用'兇真'稱呼岡部的人，經常把自己的突然想到的setting代入岡部的setting上，岡部也經常跟不上其電波程度，所以有些不擅長應付她。";
        txtCharacterContent.text += "\n 秋葉留未穗的本名極少有人知道，在比翼戀理的戀人裡自稱那是只要說出就會讓對方徹底愛上的咒語。";
        txtCharacterContent.text += "\n 事實上是幾乎擁有整個秋葉原地區地產的秋葉家的大小姐。廣播劇哀心迷圖的巴別塔中，紅莉棲與留未穗實際上有著很深的羈絆。兩人的父親同為橋田玲的學生，是開發時間機器的好友兼戰友。在留未穗的父親去世時，紅莉棲拯救了哀傷中的留未穗。在α線的紅莉棲即將消失之時，兩人最終通過父親留下的錄音帶相認場面一度極其百合，並在留未穗的鼓勵下向岡部表白。";
        txtCharacterContent.text += "\n 本文引自萌娘百科";
    }
    public void btnlabmem008()
    {
        TextScrollbar.value = 1;

        txtCharacterContent.text = " 本作的女主角之一，在未來發明研究所樓下的“映像管工房”打零工的元氣少女，熱愛山地車與映像管。　　";
        txtCharacterContent.text += "\n 未來發明研究所的研究員No.008，自稱“獨當一面的戰士”，聲稱對於格鬥術和荒野生存等技術也十分專長，因此被岡部稱作“打工戰士”。　";
        txtCharacterContent.text += "\n 雖然有時元氣過剩，時時讓人感覺粗枝大葉，但實際相處起來還是個很樂於幫助人的人，喜歡詢問他人的近況和幫他人解決煩惱，但卻從來不說自己的事。在與人交往時往往不會相交太深，也不喜歡藉助他人的力量，因此即使自己已經陷入困境，除非實在無法忍耐下去，否則也不會向周圍的人訴說。由於在α世界線中，紅莉棲作為「機關」SERN的研究人員（不得已）研製了時光機（時光機之母），間接導致自己老爸便當，因此很討厭紅莉棲，但也表示同情她的身不由己，後期兩人趨向於和解。";
        txtCharacterContent.text += "\n 對於世間的常識非常不了解，經常使用一些正常人幾乎不使用的詞彙。";
        txtCharacterContent.text += "\n 能把雜草蟲子之類的東西很好地進行料理，看起來確實擁有很高的生存能力。而且相當擅長的格鬥技，有著在實戰中也不辱其名的實力，本人則稱之為生存技巧。她生活的中心就是騎自行車，是個狂熱的自行車愛好者。一但提到時就會性格突變，採取積極的行動，甚至還會邀請岡倫和橋田等未來道具研究所成員一起騎車去兜風。常用Mountain Bike（山地自行車），簡稱MTB。雖然剛買不久，不過已經完全喜歡上了，常能看見她在「顯像管工房」前努力維護自行車的身影。";
        txtCharacterContent.text += "\n 真實身份為來自2036年的時空旅行者，網名“約翰·提托”。回到過去的α世界線是為了繼承父親“巴雷爾·提托”（橋田至的化名）的意願、改變SERN在未來的統治下的“絕望鄉”。在得知父親的真名為橋田至後將自己改名為“橋田鈴”。 β世界線收束範圍內鈴羽的目的則是通過拯救陷入必死命運的牧瀨紅莉棲制止第三次世界大戰的爆發。 δ世界線收束範圍內的鈴羽回到過去的目的是收集各種老式儀器用以在未來解析幾十年前的數據。";
        txtCharacterContent.text += "\n 本文引自萌娘百科";
    }
    public void btnlabmem009()
    {
        TextScrollbar.value = 1;

        txtCharacterContent.text = " 身為牧瀨紅莉棲所屬大學的前輩研究員。";
        txtCharacterContent.text += "\n 祖父母和兩親都是沖繩出身的日本人，美籍日本人。";
        txtCharacterContent.text += "\n 由於其年幼的姿容，無論在美國還是日本都被誤認是孩子。";
        txtCharacterContent.text += "\n 賽車類街機遊戲高手。";
        txtCharacterContent.text += "\n 本文引自萌娘百科";
    }
    public void btnlabmem010()
    {
        TextScrollbar.value = 1;

        txtCharacterContent.text = " 2032年,在兒童孤兒院工作的真由理負責照顧一個年輕的女孩，由於戰爭無法知道她的家庭登記信息和真實姓名年齡。後來真由理將這個孩子收為養女並給了給了她新的名字——椎名篝，意思是篝火，希望篝在這個黑暗的世界線中成為人們心目中的希望之火。";
        txtCharacterContent.text += "\n 2036年，為了避免篝繼續受到戰爭帶來的傷害，真由理將篝託付給鈴羽，二人乘坐時間機器回到過去執行改變未來的任務。";  
        txtCharacterContent.text += "\n 本文引自萌娘百科";
    }
    public void btnlabmem011()
    {
        TextScrollbar.value = 1;

        txtCharacterContent.text = " 齊肩的棕色的頭髮,翠綠的眼睛，是個大美人（岡部評價：這樣的大美人將來會嫁給橋田至（桶子），到現在我都不能相信），是“以同性的人眼光來看也是個很美麗”的人，眼眸深處不是普通美女的桀驁不馴，而是親切的光芒。開朗、樂觀，一直深愛著桶子，理解並支持他所做的工作。世界線收束下，在不同的世界線以各種奇妙的方式與桶子相識。";
        txtCharacterContent.text += "\n 本文引自萌娘百科";
    }
    public void btnother1()
    {
        TextScrollbar.value = 1;

        txtCharacterContent.text = " 熱愛顯像管的肌肉男，平時顯得很堅毅的樣子，但實際上好像很喜歡調戲女孩子，在阿萬音鈴羽用衣服裹住其頭部以幫助岡部倫太郎打開電視之後，強行沒收了阿萬音鈴羽的上衣一整天。";
        txtCharacterContent.text += "\n α世界線年輕時顏值還算可以，曾受過科學家橋田鈴女士（阿萬音鈴羽）的照顧，似乎因此對愛好科學的年輕人較為看重。嘴上說討厭岡部，卻不管岡部等人怎麼鬧都不會將他們趕走。";
        txtCharacterContent.text += "\n 其實不管哪條世界線，無論有沒有橋田鈴的存在都會來到大檜山大樓開設“顯像管工房”，並把2樓租給岡部。而且不管哪條線，無辜的愛妻都會於2001年10月22日慘死。";
        txtCharacterContent.text += "\n 表面上是一個普普通通的電視機商店老闆，但實際上卻是隸屬於SERN的邪惡組織Rounder的基層特工，自名為FB，即顯像管的發明者費迪南德·布勞恩（FerdinandBraun）的名字首字母，工作為尋找存在於秋葉原的IBN5100，其手下桐生萌鬱一直認為她（FB）為女性。";
        txtCharacterContent.text += "\n 其實本性並不壞，自嘲自己只是SERN的“家畜”，代表著自己也是沒有選擇的人。然而卻和純善的妻子生出了全作最黑的“小動物”。";
        txtCharacterContent.text += "\n 本文引自萌娘百科";
    }
    public void btnother2()
    {
        TextScrollbar.value = 1;

        txtCharacterContent.text = " 天王寺綯是顯像管工房的店長天王寺裕吾的女兒。在《命運石之門》中為十一歲，在續作《機器人筆記》中為二十歲。";
        txtCharacterContent.text += "\n 小時候的綯有點害怕岡部倫太郎和橋田至，被兩人稱作“小動物”。";
        txtCharacterContent.text += "\n 非常愛乾淨，看到髒污身體會先於大腦行動，平時也會給家裡和店裡打掃衛生。很擅長打掃衛生，真由理非常佩服其技術並稱她為“清掃中士”，但是本人很牴觸“中士”這個稱呼。";
        txtCharacterContent.text += "\n 在打掃衛生時會戴上帽子，然後人格分裂“由小動物系蘿莉變成抖S中士”，自稱“指導教官天王寺中士”，非常毒舌，非常嚴厲，稱其他人為“尺蠖”，被問到只能回答“是”或“不是”，回答的時候要在頭尾加上“綯大人”。";
        txtCharacterContent.text += "\n 本文引自萌娘百科";
    }
    public void btnother3()
    {
        TextScrollbar.value = 1;

        txtCharacterContent.text = " 自稱獲得多項專利、授予諾貝爾獎的物理學家。同時也是牧瀨紅莉棲的父親。從前與紅莉棲非常親近，但因為強烈的自尊心無法接受成就超越自己的女兒而逐漸遠離紅莉棲，最後甚至被學術界除名。";
        txtCharacterContent.text += "\n 是紅莉棲遭刺殺案件的相關人物，從案發現場奪取了紅莉棲寫的有關「時間機器理論」的論文，並打算搭機到俄羅斯尋求贊助。原本該班客機會因為火災而使得放在貨艙的論文被燒毀，但卻因為先前紅莉棲無意中撿了真由理掉落的金屬烏帕放進論文的袋子中，使得中鉢在機場被金屬探測器檢測到，所以將論文隨身攜帶，論文因此沒被燒毀。並以自己的名義發表「時間機器理論」的論文，造成β世界線中各國爭奪時間機器而釀成的第三次世界大戰。 ";
        txtCharacterContent.text += "\n 於廣播劇CD（及漫畫）《哀心迷圖之巴比倫》中，透露了對時間機器的固執是為了拯救過去身亡的好友秋葉幸高及橋田教授（真正身份是為協助岡部取得IBN5100而回到過去的鈴羽，因時間旅行的副作用，身體被慢性果凍化病逝）。並於留給紅莉棲的舊式錄音帶中自白了內心其實是深愛女兒並作出道歉。";
        txtCharacterContent.text += "\n 本文引自維基百科";
    }
    public void btnother4()
    {
        TextScrollbar.value = 1;

        txtCharacterContent.text = " 菲利斯的父親。秋葉原一帶的大地主，舊式電腦的收藏家，2000年因空難身亡。菲利斯繼承家業後，引進秋葉原的萌文化。改變世界線的重要人物。";
        txtCharacterContent.text += "\n 本文引自维基百科";
    }
    public void btnother5()
    {
        TextScrollbar.value = 1;

        txtCharacterContent.text = " 漆原琉華的父親。看似是個常識人，卻會讓兒子穿上巫女服，並相信岡部的自稱「鳳凰院兇真」是他的本名等等。";
        txtCharacterContent.text += "\n 本文引自维基百科";
    }


}
