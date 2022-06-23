﻿using Google.Ads.Gax.Examples;
using Google.Ads.GoogleAds;
using Google.Ads.GoogleAds.Lib;
using Google.Ads.GoogleAds.Util;
using Google.Ads.GoogleAds.V10.Enums;
using Google.Ads.GoogleAds.V10.Errors;
using Google.Ads.GoogleAds.V10.Resources;
using Google.Ads.GoogleAds.V10.Services;

using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsAgain
{
    internal partial class Program
    {
        static void Main(string[] args)
        {

            var credCFG = (from file in Directory.GetFiles(@"C:\users\bugma\Credentials", "*.cfg") where file.Contains("trev") select file).FirstOrDefault();
            var credJSN = Path.ChangeExtension(credCFG, ".json");
            var devToken = (from line in File.ReadAllLines(credCFG) where line.StartsWith("developer.token") select line.Substring(16)).FirstOrDefault();
            var auths = AdsAuth.Auth.AuthoriseFromCFG(credCFG, "7212153394"); //  8109270380 2391116888
            CustomerServiceClient customerService = auths.Item1.GetService(Services.V10.CustomerService);
            foreach (var (client, text) in from long client in new long[] { 1006391987, 1012015988, 1017525586, 1020724037, 1049496492, 1058805376, 1067986225, 1076807899, 1080358674, 1088080539, 1092987761, 1095172321, 1098408642, 1103907837, 1106276712, 1106492894, 1111867738, 1134553920, 1137104806, 1138673728, 1141703215, 1150142184, 1153848221, 1154270184, 1172932681, 1173449362, 1186037247, 1193902583, 1211920982, 1213504972, 1217301872, 1219197184, 1220764310, 1222425721, 1224625439, 1238130827, 1240732680, 1250828080, 1251359586, 1255309782, 1257272142, 1260806188, 1269470529, 1270075884, 1272577782, 1293366698, 1311724429, 1321281837, 1321377335, 1335077761, 1336807831, 1341664551, 1347140419, 1350777129, 1351466751, 1354619523, 1359157082, 1360703402, 1362493616, 1362536086, 1377260681, 1379223874, 1381245578, 1399026449, 1413282461, 1418540321, 1440219678, 1446974912, 1447825039, 1450729177, 1451303118, 1457700823, 1457927085, 1459141072, 1463136827, 1480876276, 1481683035, 1483715805, 1483933215, 1493635802, 1494329674, 1499572776, 1518527480, 1523430505, 1532938159, 1547216353, 1547657729, 1552377882, 1552776468, 1557973663, 1561333627, 1562737189, 1566011090, 1590585140, 1596039031, 1600072376, 1603695314, 1617603895, 1618056822, 1618630888, 1625107037, 1628045363, 1633753561, 1635416988, 1648248377, 1648766531, 1664755577, 1669373181, 1678278972, 1691344725, 1692675276, 1694521477, 1697347121, 1700190024, 1701514837, 1701638780, 1704155223, 1704806270, 1710678682, 1721129585, 1729691812, 1730466579, 1732810721, 1750927672, 1766219722, 1767881153, 1784713610, 1802873929, 1803453778, 1804282121, 1805111422, 1806750476, 1815747878, 1818218139, 1834472623, 1836381172, 1853503825, 1860666572, 1868008331, 1868704404, 1868965800, 1875772984, 1879809528, 1885359925, 1894595688, 1894780203, 1900540884, 1902376004, 1905050453, 1909445922, 1911047829, 1920041629, 1926642574, 1926680569, 1928532253, 1931752786, 1933650314, 1937217325, 1937774587, 1939769462, 1944679923, 1957667332, 1972694047, 1973148372, 1976959582, 1978559813, 1982486284, 1987089085, 1989633953, 1992878361, 2003498721, 2005573683, 2013646664, 2014853772, 2017465403, 2017708839, 2024337071, 2046164929, 2052701510, 2055813988, 2056326589, 2059866278, 2076374421, 2093469882, 2094553680, 2094877131, 2098118980, 2104681232, 2104997537, 2111430688, 2126425461, 2132530251, 2143890400, 2154437276, 2155683840, 2169110729, 2174831271, 2178794729, 2194725074, 2204772739, 2222129423, 2232449139, 2246679080, 2248830610, 2263983534, 2267237197, 2268168239, 2274090125, 2279648156, 2280270180, 2285124947, 2288161027, 2288836579, 2290190690, 2295154672, 2295402323, 2296616725, 2320988323, 2321882023, 2325129665, 2328803710, 2337012155, 2341075118, 2352690239, 2356342535, 2360462931, 2360833572, 2363274425, 2375657427, 2388586978, 2394798900, 2394885423, 2403537225, 2406772933, 2408003774, 2409825970, 2418795612, 2423425780, 2424142584, 2425908693, 2435658713, 2443691955, 2464749108, 2468908227, 2479209831, 2479612679, 2494643421, 2504931888, 2524145739, 2526287789, 2526688461, 2533357527, 2533919039, 2534211806, 2536511457, 2537987002, 2553736684, 2562893933, 2579928627, 2584047157, 2588391944, 2591848189, 2592698421, 2593215014, 2606983281, 2607097839, 2614559414, 2624287895, 2627795322, 2637719669, 2643503537, 2655058151, 2655872324, 2657289876, 2660644337, 2676255083, 2679960342, 2693505606, 2696884480, 2700423276, 2705651175, 2726701482, 2731274995, 2731348574, 2739135476, 2750207915, 2764245602, 2769808388, 2777747588, 2786262750, 2789562137, 2791151740, 2811817431, 2815519786, 2818561129, 2818820764, 2825803333, 2826154021, 2836466976, 2860058289, 2867405681, 2873850476, 2876438069, 2877223772, 2884905721, 2893874778, 2894559325, 2896594576, 2907666980, 2910452130, 2912568997, 2913572825, 2921006578, 2934263772, 2937498985, 2939013621, 2941376435, 2941447325, 2944922640, 2950467279, 2953089448, 2953528625, 2954495306, 2957291682, 2964189639, 2965714878, 2971145174, 2980764935, 2981338931, 2987519086, 2988459038, 2989557151, 2993233975, 3001933007, 3016511327, 3021099988, 3025421833, 3034375572, 3035370633, 3044645039, 3054830129, 3058764274, 3064363887, 3066548372, 3102320480, 3104101239, 3105125473, 3108748431, 3114167316, 3115284129, 3124464988, 3128987174, 3134080872, 3141416733, 3143378135, 3145529535, 3147961931, 3154124927, 3155017724, 3159625723, 3168876021, 3198600384, 3199932296, 3200935221, 3208051686, 3214065473, 3216018288, 3225198279, 3225434639, 3231951227, 3233122316, 3241374434, 3244721231, 3265653791, 3266766937, 3267848221, 3282721467, 3291410376, 3295243265, 3319232821, 3321099683, 3329782331, 3331473235, 3340657916, 3340948252, 3351427425, 3357821333, 3369710739, 3378801688, 3387539878, 3392361127, 3395743503, 3403493933, 3418696531, 3420170225, 3421120825, 3424903680, 3441338772, 3455020433, 3456230458, 3460027808, 3460692737, 3464182272, 3469203074, 3478660029, 3486596530, 3505225782, 3506072182, 3510079078, 3510971960, 3511113540, 3516401611, 3523021018, 3527140476, 3540190028, 3541332472, 3551925520, 3554838235, 3564159936, 3564891035, 3566786022, 3579033935, 3585687973, 3604597676, 3609238637, 3615053839, 3620266535, 3635935347, 3646135127, 3646530754, 3648357657, 3650676208, 3664523329, 3671806925, 3685030914, 3689901334, 3697567825, 3701508786, 3705414476, 3707896033, 3709687235, 3710586638, 3711574623, 3732435825, 3742035778, 3748386711, 3751361874, 3758683012, 3761222182, 3770842761, 3777490088, 3779896085, 3784037965, 3792613674, 3806251702, 3808571616, 3814355224, 3822961089, 3833418778, 3837976978, 3846945307, 3848623857, 3849963778, 3854075782, 3856563825, 3858153708, 3859046380, 3860114187, 3868886485, 3872077237, 3880697725, 3882820327, 3900646907, 3917582226, 3920179797, 3921263137, 3922293044, 3929220139, 3929548778, 3932527225, 3953714352, 3959060651, 3969481078, 3969506929, 3969655555, 3976211206, 3978614234, 3978866680, 3986678025, 3992271022, 3995308478, 3996886720, 3998547178, 4006120782, 4012865533, 4014220672, 4017281433, 4023472486, 4023892388, 4024029613, 4037114121, 4038076037, 4042483480, 4047115939, 4048418235, 4057285173, 4057848621, 4065504076, 4065933378, 4067324681, 4070994939, 4075930531, 4079904172, 4090794925, 4091426629, 4093113931, 4094091773, 4106741516, 4109484829, 4109924639, 4119300849, 4125466221, 4128382778, 4129089174, 4131614229, 4135805680, 4148863829, 4152893472, 4157715724, 4164355437, 4165421123, 4166463837, 4170532798, 4174829990, 4178959821, 4182082357, 4182202463, 4182345486, 4182709421, 4194003865, 4203603823, 4207533038, 4212115088, 4215407116, 4217729574, 4218635623, 4225228021, 4229760082, 4235001053, 4236983336, 4237372982, 4240405893, 4244166419, 4245992872, 4272932255, 4298251274, 4308394827, 4319869674, 4322540886, 4328686728, 4329675951, 4331329320, 4335739527, 4341353680, 4347400017, 4347962239, 4348783421, 4356062224, 4356477391, 4357205516, 4358585178, 4361351488, 4363619237, 4368168435, 4382378180, 4394068028, 4404034735, 4404816831, 4405585655, 4407442124, 4412729327, 4420353718, 4437542676, 4440886784, 4447347335, 4460866325, 4461450409, 4473482713, 4477290091, 4477506658, 4491541078, 4493845929, 4495408290, 4503142129, 4523697084, 4524421372, 4535841785, 4536936839, 4538541690, 4543193527, 4553076137, 4562452832, 4568199833, 4570353004, 4572567057, 4575131723, 4592376996, 4603724135, 4608359821, 4612017880, 4613321084, 4614307433, 4628169567, 4630699267, 4630827880, 4642475936, 4645959140, 4646178974, 4656434521, 4659839904, 4662485025, 4670495978, 4678251886, 4684363102, 4686376907, 4688132630, 4703964588, 4712408785, 4724185074, 4726409620, 4731567677, 4735353794, 4738335080, 4739881180, 4740302230, 4747307409, 4750623607, 4765502186, 4775018885, 4776059778, 4777769837, 4793460055, 4805196135, 4805840218, 4813389572, 4816103727, 4824192176, 4831357937, 4837039686, 4850031780, 4854522044, 4861545235, 4882748125, 4904465835, 4909325174, 4922563233, 4927658742, 4928864437, 4934231227, 4939070911, 4945541772, 4947954833, 4951541329, 4951615023, 4967118990, 4968974321, 4973223480, 4974111427, 4974709876, 4977158941, 4982070868, 4983023309, 4990325587, 5001216275, 5018583825, 5020897183, 5023331185, 5024728036, 5028371112, 5037259639, 5039398890, 5039993737, 5044238874, 5049247382, 5051804584, 5052408676, 5052971954, 5061387278, 5072566376, 5073721139, 5076461343, 5079776886, 5098917378, 5105412602, 5110178627, 5114522236, 5118052780, 5137629523, 5171630980, 5177261607, 5180323278, 5191890979, 5218142886, 5223169281, 5230749071, 5241474289, 5242513321, 5257820229, 5260423080, 5289861507, 5291949876, 5292964790, 5306297364, 5322040390, 5339826131, 5340180721, 5353188421, 5373272627, 5379713890, 5387411325, 5391376261, 5391892194, 5403339471, 5407586039, 5413031398, 5413799729, 5420290208, 5426352776, 5426691525, 5445384711, 5445792729, 5453195863, 5454023178, 5455739688, 5456586018, 5463899287, 5466021384, 5467902176, 5470067986, 5483537635, 5485698100, 5488770074, 5489324327, 5493666155, 5507886141, 5512579072, 5513257951, 5530273287, 5531590586, 5533263308, 5533346627, 5544054936, 5559201319, 5561826287, 5563399281, 5564707908, 5566048029, 5573644818, 5575867403, 5576363583, 5576410578, 5602397980, 5602716726, 5605129662, 5607677674, 5631263699, 5632062639, 5641163078, 5686383779, 5687823025, 5710411265, 5719196250, 5720973672, 5727305127, 5732552829, 5735912723, 5741510325, 5749627009, 5759438271, 5769918457, 5773365372, 5774007574, 5774227090, 5780097924, 5782571827, 5791736245, 5796609814, 5798181580, 5806461025, 5806978476, 5812227136, 5822153059, 5828161308, 5829578890, 5830046980, 5833321774, 5836591055, 5845871897, 5848862753, 5852480721, 5857180078, 5875836882, 5879421027, 5892155445, 5901027573, 5915990469, 5928080306, 5928146321, 5930925403, 5942301680, 5947432025, 5951997874, 5955239723, 5964120886, 5981796071, 5982823872, 5987696123, 5998111282, 5998471630, 6011822829, 6020760857, 6027441927, 6050785899, 6057354027, 6058306778, 6077057459, 6081362125, 6090153508, 6100192546, 6108887688, 6115319251, 6115589081, 6121413648, 6121955532, 6124804751, 6125997464, 6127752677, 6128011639, 6134570184, 6145764495, 6159649231, 6159777674, 6178469539, 6180172727, 6183221639, 6204023382, 6206050729, 6217274378, 6223523237, 6233163719, 6239766925, 6239854509, 6253030355, 6260013322, 6272020175, 6277310272, 6288850831, 6290494390, 6294300880, 6298077982, 6304088725, 6315069433, 6316700628, 6320576127, 6324249324, 6325092950, 6326270280, 6328283457, 6337218576, 6345518124, 6359918280, 6377739990, 6378566642, 6390791578, 6395492256, 6400663835, 6405743961, 6430638158, 6437943330, 6445896690, 6450180625, 6451331131, 6451409182, 6461139439, 6465759239, 6466488382, 6478241056, 6488006729, 6494199273, 6505768087, 6513452780, 6515729929, 6519627322, 6527797169, 6528640680, 6529024753, 6529877474, 6532605584, 6533703982, 6534230788, 6546344703, 6552301102, 6553458784, 6554841335, 6558662883, 6573371382, 6577694185, 6582474625, 6583346521, 6589077626, 6603042672, 6604098210, 6607624762, 6616417581, 6632812329, 6635927476, 6638047727, 6650339976, 6653502533, 6654684663, 6655193432, 6659522576, 6660071406, 6663613006, 6668053509, 6675471153, 6676221535, 6677735878, 6678574774, 6687309272, 6690727004, 6692601320, 6697853089, 6700385588, 6702356240, 6704102123, 6706209725, 6709407473, 6711423904, 6739085379, 6739103476, 6750450433, 6755529473, 6770731533, 6772582354, 6772950649, 6778913784, 6779348759, 6805391378, 6808541671, 6826019547, 6827976629, 6829464288, 6837905631, 6843294878, 6848118078, 6854099688, 6860402653, 6868257886, 6870595697, 6873424978, 6876130721, 6879519973, 6885719288, 6889138771, 6890329976, 6893273437, 6896923054, 6898639374, 6900443678, 6901922975, 6921489325, 6932886976, 6933016427, 6941207055, 6941299096, 6941888275, 6969040038, 6970639461, 6975692280, 6979584838, 6981760721, 6999258127, 7000331092, 7004697833, 7015631974, 7017803172, 7030599425, 7034859490, 7043332372, 7048980308, 7054843133, 7063652788, 7069425380, 7070642386, 7074727991, 7079838408, 7089846812, 7090185466, 7091917827, 7094578644, 7113906390, 7127660622, 7130812211, 7143413691, 7144296255, 7154197032, 7161123404, 7164376589, 7164661072, 7165920833, 7168815726, 7170525480, 7173789133, 7181840865, 7183635254, 7184974342, 7196743089, 7197628172, 7200906823, 7204946161, 7205072888, 7208025384, 7211517838, 7212172129, 7222098172, 7233879676, 7239308974, 7242065629, 7252686987, 7258074003, 7262719829, 7265724868, 7268585190, 7273576109, 7274326593, 7274933529, 7280534090, 7280735539, 7285473429, 7298270785, 7309283465, 7319873419, 7319967884, 7326609483, 7327844631, 7353840030, 7370906078, 7373105886, 7378454739, 7379722014, 7379767388, 7381763716, 7386791972, 7387742272, 7388840280, 7393681502, 7400383673, 7404479001, 7413635782, 7416024580, 7424406359, 7427703980, 7431412586, 7450715674, 7452231733, 7459009997, 7461787778, 7463319978, 7473533523, 7489545121, 7492281180, 7492564002, 7492975337, 7498184186, 7502356527, 7505823635, 7507012176, 7511692628, 7516529778, 7528412418, 7531944788, 7532424977, 7538632729, 7547507121, 7557238994, 7565699522, 7571450490, 7571780537, 7605400072, 7608418873, 7614296288, 7621551729, 7623629380, 7631590439, 7634860438, 7640331603, 7648221577, 7662922172, 7663594875, 7666051529, 7668259454, 7670520184, 7670966425, 7672801275, 7680157782, 7684624276, 7685702516, 7687303365, 7688474169, 7689844616, 7694598732, 7703133147, 7704379921, 7707240851, 7707761774, 7708520280, 7709951134, 7711020477, 7724611325, 7727732295, 7729001426, 7752407216, 7756348980, 7761559825, 7766782574, 7776069354, 7777702167, 7779433525, 7794304775, 7798813329, 7805361716, 7821353606, 7821835816, 7839778835, 7842604644, 7849116637, 7852390423, 7855831202, 7856495821, 7857412846, 7878677276, 7880223631, 7923129023, 7943430439, 7949614386, 7956093384, 7966272821, 7983745574, 7990299229, 7996156986, 8006004580, 8010632672, 8010979878, 8015665883, 8018577625, 8021459231, 8022405914, 8029614988, 8043975433, 8055869559, 8056868027, 8061316734, 8066548415, 8068292980, 8076237493, 8091202765, 8099526706, 8118806832, 8124112187, 8134455223, 8136899933, 8139207831, 8139748459, 8140410329, 8144711178, 8166225090, 8171924931, 8195371540, 8197690984, 8199738026, 8200942313, 8207744284, 8220979359, 8222857372, 8223941125, 8242135372, 8242379476, 8243912119, 8244830622, 8245145321, 8245389790, 8256214178, 8267974876, 8271930835, 8282909427, 8302645189, 8313705354, 8315759803, 8322972021, 8342044027, 8346327184, 8346409555, 8347608574, 8361003066, 8361627771, 8363489678, 8364388916, 8365590186, 8384640323, 8386741669, 8391523072, 8392050736, 8394689386, 8398424038, 8404374324, 8413932285, 8414000671, 8421261425, 8431427097, 8435457633, 8444673463, 8451610188, 8456835188, 8462545232, 8470496676, 8502382872, 8504401827, 8508988722, 8513197825, 8517725494, 8519343029, 8525806051, 8528835613, 8532794576, 8535329076, 8540984476, 8543425329, 8544157126, 8546557380, 8546936538, 8547843625, 8557517237, 8583164687, 8583502078, 8586662729, 8588650680, 8591395829, 8605857245, 8607018989, 8607635590, 8608413829, 8608423229, 8629033103, 8630878814, 8632254166, 8632545390, 8637399684, 8638148715, 8644321176, 8654053374, 8659248038, 8665262578, 8682093469, 8685551390, 8687886602, 8689044847, 8689220282, 8700976175, 8703493476, 8706099136, 8707166623, 8710351857, 8710440729, 8713269337, 8730868827, 8732598529, 8747224782, 8753454193, 8755812765, 8757009878, 8764557516, 8778487686, 8779496727, 8783595429, 8786122410, 8786230695, 8795784521, 8796788982, 8817278575, 8820837214, 8823868204, 8844072874, 8847626988, 8856794610, 8856878527, 8858829521, 8865852054, 8868429559, 8869191727, 8871790336, 8877285086, 8883735264, 8884581186, 8887873029, 8892462158, 8892692482, 8893933273, 8913202786, 8918619840, 8919925753, 8922821539, 8927921623, 8941903888, 8944689966, 8945742475, 8947399121, 8960187550, 8963952723, 8967648682, 8971214975, 8978570429, 8988629925, 8997093082, 9006265224, 9013198402, 9020498872, 9020657546, 9034776438, 9036598739, 9041154878, 9041470082, 9043820027, 9046968384, 9056465140, 9069685990, 9088039904, 9088201837, 9112113827, 9126121478, 9131249607, 9136225465, 9147646621, 9150991637, 9161005529, 9192106935, 9201441838, 9202396080, 9202832871, 9202952204, 9209211786, 9217141421, 9239000253, 9242554272, 9247014235, 9253380686, 9254714171, 9259863531, 9263745426, 9264641670, 9272983688, 9296985155, 9312711925, 9323835321, 9330994849, 9344906329, 9345730072, 9350110303, 9362043637, 9374091772, 9379227890, 9380332054, 9380694688, 9405324958, 9412079219, 9412865372, 9416131874, 9421166886, 9423570417, 9430074223, 9438185674, 9440446967, 9446383921, 9446819929, 9465961024, 9470356478, 9470653490, 9478811961, 9483070590, 9489338574, 9493269037, 9501309223, 9503681660, 9509762082, 9518783124, 9533724076, 9548679976, 9555704182, 9560217921, 9566078427, 9577219725, 9578808340, 9588464578, 9589031868, 9594156407, 9596604739, 9603330115, 9617404276, 9622227581, 9630092472, 9632399304, 9632511441, 9636778169, 9651468376, 9652766187, 9658751484, 9662672127, 9664957613, 9665914271, 9685755031, 9690704333, 9691960532, 9692666190, 9700393423, 9701971940, 9707129637, 9716086320, 9716979182, 9733971476, 9744758234, 9747895568, 9751177523, 9753550255, 9754829409, 9759401176, 9761342775, 9762803137, 9776622476, 9777869080, 9782240974, 9782830233, 9790257735, 9800114629, 9807746359, 9808614678, 9821369129, 9831157274, 9843325525, 9846305683, 9870952374, 9872671293, 9884395947, 9890155882, 9899489837, 9924720344, 9925317965, 9929804382, 9930592021, 9942538287, 9942610808, 9943133982, 9943439829, 9950816674, 9951023776, 9952425427, 9953204674, 9962083033, 9966629827, 9967990574, 9968631413, 9986307586, 9989820323 }
                                           let text = Path.Combine(Path.GetTempPath(), $"GoogleTrace_{DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'-'HH'-'mm'-'ss'-'ffff")}_{client}.log")
                                           select (client, text))
            {
                TraceUtilities.Configure(TraceUtilities.DETAILED_REQUEST_LOGS_SOURCE,
                                text, SourceLevels.All);
                var specific = GetAccountInformation(auths.Item1, client);
                dynamic s = JsonConvert.DeserializeObject(specific);
                if (s.Error != null)
                {
                    //Console.WriteLine(s.Error.Value);
                }
                else
                {
                    Console.WriteLine($"{client} {s.Cargo.DescriptiveName.Value}");
                    var splan = GenerateHistoricalMetrics(auths.Item1, client, false);
                }
            }
        }

        private static object GenerateHistoricalMetrics(GoogleAdsClient client, long customerId, bool debug = false)
        {
            var kp = new KPlan(client, customerId);

            var plan = kp.CreateKeywordPlan("Keyword plan " + System.Guid.NewGuid().ToString(), 
                KeywordPlanForecastIntervalEnum.Types.KeywordPlanForecastInterval.NextQuarter);
            dynamic decodedPlan = JsonConvert.DeserializeObject(plan);
            if (decodedPlan.Error == null)
            {
                plan = decodedPlan.Cargo.Results[0].ResourceName.Value;
                Console.WriteLine($"Keyword plan: {plan}");
                var rep = Report(client, customerId, long.Parse(plan.Split('/').Last()));
                dynamic decodedRep = JsonConvert.DeserializeObject(rep);
                Console.WriteLine($"Keyword report: {JsonConvert.SerializeObject(decodedRep.Cargo)}");
            }
            return plan;
        }

        internal static string Report(GoogleAdsClient client, long customerId, long keywordPlanId)
        {
            KeywordPlanServiceClient kpServiceClient = client.GetService(Services.V10.KeywordPlanService);
            string keywordPlanResource = ResourceNames.KeywordPlan(customerId, keywordPlanId);

            try
            {
                var response = kpServiceClient.GenerateHistoricalMetrics(keywordPlanResource);
                return JsonConvert.SerializeObject(new JSON() { Cargo = response });
            }
            catch (GoogleAdsException e)
            {
                return JsonConvert.SerializeObject(new JSON() { Error = (e.Message, e.Failure, e.RequestId) });
            }
        }
    }
}